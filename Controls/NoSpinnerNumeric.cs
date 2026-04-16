using System.Windows.Forms;

namespace ÜrünTakip.Controls
{
    /// <summary>
    /// Yukarı/aşağı ok (spinner) düğmesi olmayan, yalnızca klavye girişli NumericUpDown.
    /// </summary>
    public class NoSpinnerNumeric : NumericUpDown
    {
        public NoSpinnerNumeric()
        {
            // Spinner butonlarını gizle ve metin alanı tüm genişliği kaplasın
            this.Controls[0].Hide(); // UpDownButtons
        }

        protected override void OnHandleCreated(System.EventArgs e)
        {
            base.OnHandleCreated(e);
            // Handle oluşturulduktan sonra da gizle (bazı durumlarda gerekli)
            if (this.Controls.Count > 0)
                this.Controls[0].Hide();
        }
    }
}
