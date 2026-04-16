using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ÜrünTakip
{
    internal static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Npgsql 6.0+ için yerel saat sorunlarını gideren eski tip çalışma modu
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            // Veritabanı foreign key (ürün silme) constraint'ini otomatik düzeltme
            try
            {
                using (var db = new ÜrünTakip.Data.AppDbContext())
                {
                    Microsoft.EntityFrameworkCore.RelationalDatabaseFacadeExtensions.ExecuteSqlRaw(db.Database, @"
                        ALTER TABLE ""SaleItems"" ALTER COLUMN ""ProductId"" DROP NOT NULL;

                        DO $$
                        DECLARE
                            fk_name TEXT;
                        BEGIN
                            SELECT tc.constraint_name INTO fk_name
                            FROM information_schema.table_constraints tc
                            JOIN information_schema.key_column_usage kcu ON tc.constraint_name = kcu.constraint_name
                            WHERE tc.table_name = 'SaleItems' AND tc.constraint_type = 'FOREIGN KEY' AND kcu.column_name = 'ProductId'
                            LIMIT 1;

                            IF fk_name IS NOT NULL THEN
                                EXECUTE format('ALTER TABLE ""SaleItems"" DROP CONSTRAINT %I', fk_name);
                                EXECUTE format('ALTER TABLE ""SaleItems"" ADD CONSTRAINT %I FOREIGN KEY (""ProductId"") REFERENCES ""Products""(""Id"") ON DELETE SET NULL', fk_name);
                            END IF;

                            -- RegisterId sütunu yoksa ekle
                            IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name='Sales' AND column_name='RegisterId') THEN
                                ALTER TABLE ""Sales"" ADD COLUMN ""RegisterId"" INTEGER NOT NULL DEFAULT 0;
                            END IF;
                        END $$;
                    ");
                }
            }
            catch { /* Zaten uygulanmışsa veya tablo yoksa sessizce geç */ }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
