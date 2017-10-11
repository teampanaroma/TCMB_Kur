namespace tcmb_kurlari
{
    partial class FrmTcmbKurlari
    {
        /// <summary>
        ///Gerekli designer değişkeni.
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
        ///Designer desteği için gerekli metottur; bu metodun
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTcmbKurlari));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.dosyaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dovizKurlariIndir = new System.Windows.Forms.ToolStripMenuItem();
            this.TCMBSayfasinaGit = new System.Windows.Forms.ToolStripMenuItem();
            this.cikis = new System.Windows.Forms.ToolStripMenuItem();
            this.hakkindaTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tsDurum = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridGorunumu = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.menu.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGorunumu)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dosyaToolStripMenuItem,
            this.hakkindaTSM});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(724, 24);
            this.menu.TabIndex = 0;
            // 
            // dosyaToolStripMenuItem
            // 
            this.dosyaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dovizKurlariIndir,
            this.TCMBSayfasinaGit,
            this.cikis});
            this.dosyaToolStripMenuItem.Name = "dosyaToolStripMenuItem";
            this.dosyaToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.dosyaToolStripMenuItem.Text = "Dosya";
            // 
            // dovizKurlariIndir
            // 
            this.dovizKurlariIndir.Name = "dovizKurlariIndir";
            this.dovizKurlariIndir.Size = new System.Drawing.Size(245, 22);
            this.dovizKurlariIndir.Text = "TCMB Döviz Kurlarını İndir";
            this.dovizKurlariIndir.Click += new System.EventHandler(this.dovizKurlariIndir_Click);
            // 
            // TCMBSayfasinaGit
            // 
            this.TCMBSayfasinaGit.Name = "TCMBSayfasinaGit";
            this.TCMBSayfasinaGit.Size = new System.Drawing.Size(245, 22);
            this.TCMBSayfasinaGit.Text = "TCMB Döviz Kurları Sayfasına Git";
            this.TCMBSayfasinaGit.Click += new System.EventHandler(this.TCMBSayfasinaGit_Click);
            // 
            // cikis
            // 
            this.cikis.Name = "cikis";
            this.cikis.Size = new System.Drawing.Size(245, 22);
            this.cikis.Text = "Çıkış";
            this.cikis.Click += new System.EventHandler(this.cikis_Click);
            // 
            // hakkindaTSM
            // 
            this.hakkindaTSM.Name = "hakkindaTSM";
            this.hakkindaTSM.Size = new System.Drawing.Size(69, 20);
            this.hakkindaTSM.Text = "Hakkında";
            this.hakkindaTSM.Click += new System.EventHandler(this.hakkindaTSM_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsDurum});
            this.statusStrip.Location = new System.Drawing.Point(0, 421);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(724, 22);
            this.statusStrip.TabIndex = 1;
            // 
            // tsDurum
            // 
            this.tsDurum.Name = "tsDurum";
            this.tsDurum.Size = new System.Drawing.Size(0, 17);
            // 
            // dataGridGorunumu
            // 
            this.dataGridGorunumu.AllowUserToAddRows = false;
            this.dataGridGorunumu.AllowUserToDeleteRows = false;
            this.dataGridGorunumu.AllowUserToOrderColumns = true;
            this.dataGridGorunumu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridGorunumu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridGorunumu.Location = new System.Drawing.Point(1, 63);
            this.dataGridGorunumu.Name = "dataGridGorunumu";
            this.dataGridGorunumu.ReadOnly = true;
            this.dataGridGorunumu.Size = new System.Drawing.Size(722, 355);
            this.dataGridGorunumu.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimePicker1.Location = new System.Drawing.Point(15, 30);
            this.dateTimePicker1.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(547, 27);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(568, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 27);
            this.button1.TabIndex = 4;
            this.button1.Text = "Getir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmTcmbKurlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 443);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dataGridGorunumu);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menu);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menu;
            this.MaximizeBox = false;
            this.Name = "FrmTcmbKurlari";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Türkiye Cumhuriyeti Merkez Bankası (TCMB) Kurları   @Panaroma Bilişim";
            this.Load += new System.EventHandler(this.FrmTcmbKurlari_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmTcmbKurlari_KeyDown);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGorunumu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem dosyaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dovizKurlariIndir;
        private System.Windows.Forms.ToolStripMenuItem TCMBSayfasinaGit;
        private System.Windows.Forms.ToolStripMenuItem cikis;
        private System.Windows.Forms.ToolStripMenuItem hakkindaTSM;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tsDurum;
        private System.Windows.Forms.DataGridView dataGridGorunumu;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button1;
    }
}

