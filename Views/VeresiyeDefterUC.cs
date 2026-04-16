using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ÜrünTakip.Controls;
using ÜrünTakip.Data;
using ÜrünTakip.Models;

namespace ÜrünTakip.Views
{
    public partial class VeresiyeDefterUC : UserControl
    {
        private int _selectedCustomerId = 0;

        public VeresiyeDefterUC()
        {
            InitializeComponent();
            this.Load += (s, e) => { LoadCustomers(); };
            btnSaveCustomer.Click += BtnSaveCustomer_Click;
            btnDeleteCustomer.Click += BtnDeleteCustomer_Click;
            btnClearCustomer.Click += BtnClearCustomer_Click;
            btnTakePayment.Click += BtnTakePayment_Click;
            dgvCustomers.CellClick += DgvCustomers_CellClick;
        }

        private void LoadCustomers()
        {
            using (var db = new AppDbContext())
            {
                var list = db.Customers.Where(c => c.IsActive).Select(c => new
                {
                    c.Id, c.FullName, c.Phone, Borç = c.TotalDebt
                }).ToList();
                dgvCustomers.DataSource = list;
            }
        }

        private void DgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int id = Convert.ToInt32(dgvCustomers.Rows[e.RowIndex].Cells[0].Value);
            _selectedCustomerId = id;
            using (var db = new AppDbContext())
            {
                var c = db.Customers.Find(id);
                if (c != null)
                {
                    txtName.Text = c.FullName;
                    txtPhone.Text = c.Phone;
                    txtAddress.Text = c.Address;
                    lblDebtInfo.Text = $"Toplam Borç: {c.TotalDebt:C2}";
                }
                // Veresiye geçmişi
                var historySales = db.Sales.Where(s => s.CustomerId == id && s.PaymentType == "Veresiye")
                    .OrderByDescending(s => s.SaleDate)
                    .ToList(); // Veriyi önce çekiyoruz
                
                var historyProjection = historySales.Select(s => new { 
                    s.Id, 
                    Tarih = s.SaleDate.ToString("dd.MM.yyyy HH:mm:ss"), // Milisaniyeler kaldırıldı
                    Tutar = s.TotalAmount, 
                    Kasiyer = s.CashierName 
                }).ToList();
                
                dgvHistory.DataSource = historyProjection;
            }
        }

        private void BtnSaveCustomer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text)) { MessageBox.Show("Ad Soyad zorunludur!"); return; }
            try
            {
                using (var db = new AppDbContext())
                {
                    if (_selectedCustomerId > 0)
                    {
                        var c = db.Customers.Find(_selectedCustomerId);
                        if (c != null) { c.FullName = txtName.Text; c.Phone = txtPhone.Text; c.Address = txtAddress.Text; db.SaveChanges(); }
                    }
                    else
                    {
                        var c = new Customer { FullName = txtName.Text, Phone = txtPhone.Text, Address = txtAddress.Text };
                        db.Customers.Add(c); db.SaveChanges();
                    }
                }
                MessageBox.Show("Müşteri kaydedildi!"); LoadCustomers(); BtnClearCustomer_Click(null, null);
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
        }

        private void BtnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (_selectedCustomerId == 0) return;
            if (MessageBox.Show("Bu müşteriyi silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var db = new AppDbContext())
                {
                    var c = db.Customers.Find(_selectedCustomerId);
                    if (c != null) { db.Customers.Remove(c); db.SaveChanges(); }
                }
                LoadCustomers(); BtnClearCustomer_Click(null, null);
            }
        }

        private void BtnTakePayment_Click(object sender, EventArgs e)
        {
            if (_selectedCustomerId == 0) { MessageBox.Show("Önce müşteri seçin!"); return; }
            Form payForm = new Form() { Width = 350, Height = 180, Text = "Ödeme Al", StartPosition = FormStartPosition.CenterParent, FormBorderStyle = FormBorderStyle.FixedDialog };
            Label lbl = new Label() { Text = "Ödeme Tutarı (₺):", Left = 20, Top = 25, Width = 140, Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold) };
            NoSpinnerNumeric num = new NoSpinnerNumeric() { Left = 160, Top = 23, Width = 150, DecimalPlaces = 2, Maximum = 999999, Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold) };
            Button ok = new Button() { Text = "ÖDEMEYİ AL", Left = 160, Top = 70, Width = 150, Height = 40, DialogResult = DialogResult.OK, BackColor = System.Drawing.Color.MediumSeaGreen, ForeColor = System.Drawing.Color.White, FlatStyle = FlatStyle.Flat, Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold) };
            payForm.Controls.Add(lbl); payForm.Controls.Add(num); payForm.Controls.Add(ok);
            payForm.AcceptButton = ok;

            if (payForm.ShowDialog() == DialogResult.OK && num.Value > 0)
            {
                using (var db = new AppDbContext())
                {
                    var c = db.Customers.Find(_selectedCustomerId);
                    if (c != null)
                    {
                        c.TotalDebt -= num.Value;
                        if (c.TotalDebt < 0) c.TotalDebt = 0;
                        db.SaveChanges();
                        lblDebtInfo.Text = $"Toplam Borç: {c.TotalDebt:C2}";
                    }
                }
                MessageBox.Show($"{num.Value:C2} ödeme alındı!");
                LoadCustomers();
            }
        }

        private void BtnClearCustomer_Click(object sender, EventArgs e)
        {
            _selectedCustomerId = 0;
            txtName.Clear(); txtPhone.Clear(); txtAddress.Clear();
            lblDebtInfo.Text = "Toplam Borç: 0,00 ₺";
            dgvHistory.DataSource = null;
        }
    }
}
