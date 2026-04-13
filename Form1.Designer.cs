namespace ÜrünTakip
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnListCategories = new System.Windows.Forms.Button();
            this.btnListProducts = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(50, 150);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(800, 500);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Location = new System.Drawing.Point(50, 100);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(160, 30);
            this.btnAddCategory.TabIndex = 4;
            this.btnAddCategory.Text = "Örnek Kategori Ekle";
            this.btnAddCategory.UseVisualStyleBackColor = true;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(220, 100);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(160, 30);
            this.btnAddProduct.TabIndex = 5;
            this.btnAddProduct.Text = "Örnek Ürün Ekle";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnListCategories
            // 
            this.btnListCategories.Location = new System.Drawing.Point(390, 100);
            this.btnListCategories.Name = "btnListCategories";
            this.btnListCategories.Size = new System.Drawing.Size(160, 30);
            this.btnListCategories.TabIndex = 6;
            this.btnListCategories.Text = "Kategorileri Listele";
            this.btnListCategories.UseVisualStyleBackColor = true;
            this.btnListCategories.Click += new System.EventHandler(this.btnListCategories_Click);
            // 
            // btnListProducts
            // 
            this.btnListProducts.Location = new System.Drawing.Point(560, 100);
            this.btnListProducts.Name = "btnListProducts";
            this.btnListProducts.Size = new System.Drawing.Size(160, 30);
            this.btnListProducts.TabIndex = 7;
            this.btnListProducts.Text = "Ürünleri Listele";
            this.btnListProducts.UseVisualStyleBackColor = true;
            this.btnListProducts.Click += new System.EventHandler(this.btnListProducts_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1376, 734);
            this.Controls.Add(this.btnListProducts);
            this.Controls.Add(this.btnListCategories);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.btnAddCategory);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnListCategories;
        private System.Windows.Forms.Button btnListProducts;
    }
}

