using System;
using System.IO;
using System.Windows.Forms;

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
            this.Load += (s, e) => { LoadSettings(); LoadPersonnel(); };
            btnSaveSettings.Click += BtnSaveSettings_Click;
            btnAddPersonnel.Click += BtnAddPersonnel_Click;
            btnRemovePersonnel.Click += BtnRemovePersonnel_Click;
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
            }
        }

        private void BtnSaveSettings_Click(object sender, EventArgs e)
        {
            File.WriteAllLines(settingsPath, new string[]
            {
                txtStoreName.Text,
                txtStorePhone.Text,
                txtStoreAddress.Text,
                numDefaultVat.Value.ToString()
            });
            MessageBox.Show("Ayarlar kaydedildi! Uygulama yeniden başlatıldığında aktif olacaktır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
