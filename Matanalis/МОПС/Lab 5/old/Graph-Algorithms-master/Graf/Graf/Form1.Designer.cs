namespace Graf
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnDijkstra = new DevExpress.XtraEditors.SimpleButton();
            this.btnBfs = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrim = new DevExpress.XtraEditors.SimpleButton();
            this.btnKruskal = new DevExpress.XtraEditors.SimpleButton();
            this.btnFord = new DevExpress.XtraEditors.SimpleButton();
            this.btnKarp = new DevExpress.XtraEditors.SimpleButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lboxKoseler = new System.Windows.Forms.ListBox();
            this.btnSosyal = new DevExpress.XtraEditors.SimpleButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDijkstra
            // 
            this.btnDijkstra.Location = new System.Drawing.Point(110, 12);
            this.btnDijkstra.Name = "btnDijkstra";
            this.btnDijkstra.Size = new System.Drawing.Size(159, 56);
            this.btnDijkstra.TabIndex = 0;
            this.btnDijkstra.Text = "Dijkstra Algoritması";
            this.btnDijkstra.Click += new System.EventHandler(this.btnDijkstra_Click);
            // 
            // btnBfs
            // 
            this.btnBfs.Location = new System.Drawing.Point(110, 87);
            this.btnBfs.Name = "btnBfs";
            this.btnBfs.Size = new System.Drawing.Size(159, 56);
            this.btnBfs.TabIndex = 1;
            this.btnBfs.Text = "Breadth First Search";
            this.btnBfs.Click += new System.EventHandler(this.btnBfs_Click);
            // 
            // btnPrim
            // 
            this.btnPrim.Location = new System.Drawing.Point(110, 164);
            this.btnPrim.Name = "btnPrim";
            this.btnPrim.Size = new System.Drawing.Size(159, 56);
            this.btnPrim.TabIndex = 2;
            this.btnPrim.Text = "Prims Algortiması";
            this.btnPrim.Click += new System.EventHandler(this.btnPrim_Click);
            // 
            // btnKruskal
            // 
            this.btnKruskal.Location = new System.Drawing.Point(110, 239);
            this.btnKruskal.Name = "btnKruskal";
            this.btnKruskal.Size = new System.Drawing.Size(159, 56);
            this.btnKruskal.TabIndex = 3;
            this.btnKruskal.Text = "Kruskal";
            this.btnKruskal.Click += new System.EventHandler(this.btnKruskal_Click);
            // 
            // btnFord
            // 
            this.btnFord.Location = new System.Drawing.Point(110, 317);
            this.btnFord.Name = "btnFord";
            this.btnFord.Size = new System.Drawing.Size(159, 56);
            this.btnFord.TabIndex = 4;
            this.btnFord.Text = "Ford Fulkerson";
            // 
            // btnKarp
            // 
            this.btnKarp.Location = new System.Drawing.Point(110, 396);
            this.btnKarp.Name = "btnKarp";
            this.btnKarp.Size = new System.Drawing.Size(159, 56);
            this.btnKarp.TabIndex = 5;
            this.btnKarp.Text = "Edmonds Karp";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(288, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(485, 341);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // lboxKoseler
            // 
            this.lboxKoseler.FormattingEnabled = true;
            this.lboxKoseler.ItemHeight = 16;
            this.lboxKoseler.Location = new System.Drawing.Point(779, 22);
            this.lboxKoseler.Name = "lboxKoseler";
            this.lboxKoseler.Size = new System.Drawing.Size(463, 340);
            this.lboxKoseler.TabIndex = 7;
            // 
            // btnSosyal
            // 
            this.btnSosyal.Location = new System.Drawing.Point(110, 466);
            this.btnSosyal.Name = "btnSosyal";
            this.btnSosyal.Size = new System.Drawing.Size(159, 56);
            this.btnSosyal.TabIndex = 8;
            this.btnSosyal.Text = "Sosyal Ağ Problemi";
            this.btnSosyal.Click += new System.EventHandler(this.btnSosyal_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(288, 21);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(485, 341);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 534);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnSosyal);
            this.Controls.Add(this.lboxKoseler);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnKarp);
            this.Controls.Add(this.btnFord);
            this.Controls.Add(this.btnKruskal);
            this.Controls.Add(this.btnPrim);
            this.Controls.Add(this.btnBfs);
            this.Controls.Add(this.btnDijkstra);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnDijkstra;
        private DevExpress.XtraEditors.SimpleButton btnBfs;
        private DevExpress.XtraEditors.SimpleButton btnPrim;
        private DevExpress.XtraEditors.SimpleButton btnKruskal;
        private DevExpress.XtraEditors.SimpleButton btnFord;
        private DevExpress.XtraEditors.SimpleButton btnKarp;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox lboxKoseler;
        private DevExpress.XtraEditors.SimpleButton btnSosyal;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

