using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ÜrünTakip.Data;
using ÜrünTakip.Models;

namespace ÜrünTakip.Views
{
    public partial class AyarlarUC : UserControl
    {
        // Basit ayar ve personel verileri dosya olarak tutulur
        private static string settingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.ini");
        private static string personnelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "personnel.txt");

        public AyarlarUC()
        {
            InitializeComponent();
            this.Load += (s, e) => { LoadSettings(); LoadPersonnel(); LoadCategories(); };
            btnSaveSettings.Click += BtnSaveSettings_Click;
            btnAddPersonnel.Click += BtnAddPersonnel_Click;
            btnRemovePersonnel.Click += BtnRemovePersonnel_Click;
            btnRemoveCategory.Click += BtnRemoveCategory_Click;
            btnRefreshCategories.Click += (s, e) => LoadCategories();
            btnBrowseBackup.Click += BtnBrowseBackup_Click;
            btnRestore.Click += BtnRestore_Click;
        }

        private void LoadSettings()
        {
            if (File.Exists(settingsPath))
            {
                var lines = File.ReadAllLines(settingsPath);
                if (lines.Length >= 4)
                {
                    txtStoreName.Text = lines[0];
                    txtStorePhone.Text = lines[1];
                    txtStoreAddress.Text = lines[2];
                    numDefaultVat.Value = int.TryParse(lines[3], out int v) ? v : 18;
                }
                if (lines.Length >= 5 && !string.IsNullOrWhiteSpace(lines[4]))
                {
                    txtBackupPath.Text = lines[4];
                }
                else
                {
                    txtBackupPath.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backups");
                }
            }
            else
            {
                txtBackupPath.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backups");
            }
        }

        private void BtnSaveSettings_Click(object sender, EventArgs e)
        {
            SaveAllSettings();
            MessageBox.Show("Ayarlar kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveAllSettings()
        {
            File.WriteAllLines(settingsPath, new string[]
            {
                txtStoreName.Text,
                txtStorePhone.Text,
                txtStoreAddress.Text,
                numDefaultVat.Value.ToString(),
                txtBackupPath.Text
            });
        }

        private void BtnBrowseBackup_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Yedek dosyalarının kaydedileceği klasörü seçin";
                if (!string.IsNullOrWhiteSpace(txtBackupPath.Text) && Directory.Exists(txtBackupPath.Text))
                    fbd.SelectedPath = txtBackupPath.Text;
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtBackupPath.Text = fbd.SelectedPath;
                    // Hemen kaydet
                    SaveAllSettings();
                }
            }
        }

        private void LoadPersonnel()
        {
            lstPersonnel.Items.Clear();
            if (File.Exists(personnelPath))
            {
                var lines = File.ReadAllLines(personnelPath);
                foreach (var line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                        lstPersonnel.Items.Add(line.Trim());
                }
            }
            else
            {
                // Varsayılan personel
                lstPersonnel.Items.Add("Ahmet Yılmaz");
                SavePersonnel();
            }
        }

        private void BtnAddPersonnel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNewPersonnel.Text))
            {
                lstPersonnel.Items.Add(txtNewPersonnel.Text.Trim());
                txtNewPersonnel.Clear();
                SavePersonnel();
            }
        }

        private void BtnRemovePersonnel_Click(object sender, EventArgs e)
        {
            if (lstPersonnel.SelectedIndex >= 0)
            {
                lstPersonnel.Items.RemoveAt(lstPersonnel.SelectedIndex);
                SavePersonnel();
            }
        }

        private void SavePersonnel()
        {
            var items = new string[lstPersonnel.Items.Count];
            for (int i = 0; i < lstPersonnel.Items.Count; i++)
                items[i] = lstPersonnel.Items[i].ToString();
            File.WriteAllLines(personnelPath, items);
        }

        /// <summary>Dışarıdan (Form1'den) personel listesini almak için</summary>
        public static string[] GetPersonnelList()
        {
            if (File.Exists(personnelPath))
                return File.ReadAllLines(personnelPath);
            return new string[] { "Ahmet Yılmaz" };
        }

        /// <summary>Dışarıdan mağaza adını almak için</summary>
        public static string GetStoreName()
        {
            if (File.Exists(settingsPath))
            {
                var lines = File.ReadAllLines(settingsPath);
                if (lines.Length > 0) return lines[0];
            }
            return "Örnek Market";
        }

        /// <summary>Dışarıdan yedek klasör yolunu almak için</summary>
        public static string GetBackupPath()
        {
            if (File.Exists(settingsPath))
            {
                var lines = File.ReadAllLines(settingsPath);
                if (lines.Length >= 5 && !string.IsNullOrWhiteSpace(lines[4]))
                    return lines[4];
            }
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backups");
        }
        public void LoadCategories()
        {
            lstCategories.Items.Clear();
            using (var db = new AppDbContext())
            {
                var categories = db.Categories.OrderBy(c => c.Name).ToList();
                foreach (var cat in categories)
                {
                    lstCategories.Items.Add(cat);
                }
            }
            lstCategories.DisplayMember = "Name";
        }

        private void BtnRemoveCategory_Click(object sender, EventArgs e)
        {
            if (lstCategories.SelectedItem == null) return;
            var cat = (Category)lstCategories.SelectedItem;

            if (MessageBox.Show($"'{cat.Name}' kategorisini silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            using (var db = new AppDbContext())
            {
                // Kategoride ürün var mı kontrol et
                bool hasProducts = db.Products.Any(p => p.CategoryId == cat.Id);
                if (hasProducts)
                {
                    MessageBox.Show("Bu kategoride kayıtlı ürünler bulunmaktadır. Kategoriyi silmeden önce ürünleri başka bir kategoriye taşımalı veya silmelisiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var dbCat = db.Categories.Find(cat.Id);
                if (dbCat != null)
                {
                    db.Categories.Remove(dbCat);
                    db.SaveChanges();
                    MessageBox.Show("Kategori başarıyla silindi.");
                    LoadCategories();
                }
            }
        }

        // ——————————————— YEDEKTEN GERİ YÜKLEME ———————————————

        /// <summary>PostgreSQL kurulum dizinlerinden pg_restore.exe yolunu otomatik bulur</summary>
        private string FindPgRestore()
        {
            string[] searchRoots = new string[]
            {
                @"C:\Program Files\PostgreSQL",
                @"C:\Program Files (x86)\PostgreSQL"
            };

            foreach (string root in searchRoots)
            {
                if (Directory.Exists(root))
                {
                    var versionDirs = Directory.GetDirectories(root)
                        .OrderByDescending(d => d)
                        .ToArray();

                    foreach (var dir in versionDirs)
                    {
                        string pgRestorePath = Path.Combine(dir, "bin", "pg_restore.exe");
                        if (File.Exists(pgRestorePath))
                            return pgRestorePath;
                    }
                }
            }
            return "pg_restore";
        }

        private void BtnRestore_Click(object sender, EventArgs e)
        {
            string backupFolder = GetBackupPath();

            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Geri yüklenecek yedek dosyasını seçin";
                ofd.Filter = "Yedek Dosyaları (*.backup)|*.backup|Tüm Dosyalar (*.*)|*.*";
                ofd.FilterIndex = 1;

                // Yedek klasörü varsa oradan başlat
                if (Directory.Exists(backupFolder))
                    ofd.InitialDirectory = backupFolder;

                if (ofd.ShowDialog() != DialogResult.OK)
                    return;

                string selectedFile = ofd.FileName;

                // Ciddi uyarı göster
                var result = MessageBox.Show(
                    "⚠️ DİKKAT!\n\n" +
                    "Bu işlem mevcut veritabanınızı tamamen silip seçilen yedekle değiştirecektir.\n\n" +
                    $"Seçilen yedek: {Path.GetFileName(selectedFile)}\n\n" +
                    "Devam etmek istediğinize emin misiniz?",
                    "Geri Yükleme Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                    return;

                // İkinci onay
                var result2 = MessageBox.Show(
                    "Son kez onaylayın!\n\n" +
                    "Tüm mevcut veriler (ürünler, satışlar, müşteriler) kaybedilecektir.\n" +
                    "Geri yükleme işlemini başlatmak istiyor musunuz?",
                    "Son Onay",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation);

                if (result2 != DialogResult.Yes)
                    return;

                try
                {
                    Cursor = Cursors.WaitCursor;

                    string pgRestoreExe = FindPgRestore();

                    // pg_restore ile geri yükleme (--clean: önce mevcut objeleri sil, --if-exists: yoksa hata verme)
                    var psi = new System.Diagnostics.ProcessStartInfo();
                    psi.FileName = pgRestoreExe;
                    psi.Arguments = $"-h localhost -p 5432 -U postgres -d UrunTakipDB --clean --if-exists -v \"{selectedFile}\"";
                    psi.UseShellExecute = false;
                    psi.CreateNoWindow = true;
                    psi.RedirectStandardOutput = true;
                    psi.RedirectStandardError = true;
                    psi.EnvironmentVariables["PGPASSWORD"] = "123456";

                    using (var process = System.Diagnostics.Process.Start(psi))
                    {
                        string error = process.StandardError.ReadToEnd();
                        process.WaitForExit();

                        Cursor = Cursors.Default;

                        if (process.ExitCode == 0)
                        {
                            MessageBox.Show(
                                $"Veritabanı başarıyla geri yüklendi!\n\n" +
                                $"Dosya: {Path.GetFileName(selectedFile)}\n\n" +
                                "Değişikliklerin tam olarak yansıması için uygulamayı yeniden başlatmanız önerilir.",
                                "Geri Yükleme Başarılı",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        else
                        {
                            // pg_restore bazı uyarılar verse bile veriyi yükleyebilir
                            // Exit code 1 genelde uyarı anlamına gelir
                            if (process.ExitCode == 1 && !error.Contains("FATAL") && !error.Contains("could not connect"))
                            {
                                MessageBox.Show(
                                    $"Geri yükleme tamamlandı (bazı uyarılar oluştu).\n\n" +
                                    "Uygulamayı yeniden başlatmanız önerilir.",
                                    "Geri Yükleme",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show(
                                    $"Geri yükleme sırasında hata oluştu:\n{error}",
                                    "Geri Yükleme Hatası",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show(
                        $"Geri yükleme başlatılamadı:\n{ex.Message}\n\npg_restore bulunamadı. PostgreSQL kurulu olduğundan emin olun.",
                        "Hata",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}
