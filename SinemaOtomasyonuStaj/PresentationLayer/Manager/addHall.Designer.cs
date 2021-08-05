
namespace SinemaOtomasyonuStaj.PresentationLayer
{
    partial class addHall
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addHall));
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.hallNameTxtbox = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.hallseat = new Bunifu.Framework.UI.BunifuDropdown();
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel2 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuTileButton5 = new Bunifu.Framework.UI.BunifuTileButton();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.Image = global::SinemaOtomasyonuStaj.Properties.Resources.close_window_48px;
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(400, 0);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(43, 38);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton1.TabIndex = 17;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 10;
            this.bunifuImageButton1.Click += new System.EventHandler(this.bunifuImageButton1_Click);
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.Enabled = false;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(-191, 44);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(866, 12);
            this.bunifuSeparator1.TabIndex = 18;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // hallNameTxtbox
            // 
            this.hallNameTxtbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.hallNameTxtbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.hallNameTxtbox.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.hallNameTxtbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.hallNameTxtbox.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.hallNameTxtbox.ForeColor = System.Drawing.Color.White;
            this.hallNameTxtbox.HintForeColor = System.Drawing.Color.White;
            this.hallNameTxtbox.HintText = "Salon Adı Giriniz";
            this.hallNameTxtbox.isPassword = false;
            this.hallNameTxtbox.LineFocusedColor = System.Drawing.Color.Blue;
            this.hallNameTxtbox.LineIdleColor = System.Drawing.Color.Gray;
            this.hallNameTxtbox.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.hallNameTxtbox.LineThickness = 3;
            this.hallNameTxtbox.Location = new System.Drawing.Point(23, 137);
            this.hallNameTxtbox.Margin = new System.Windows.Forms.Padding(4);
            this.hallNameTxtbox.MaxLength = 32767;
            this.hallNameTxtbox.Name = "hallNameTxtbox";
            this.hallNameTxtbox.Size = new System.Drawing.Size(379, 33);
            this.hallNameTxtbox.TabIndex = 19;
            this.hallNameTxtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // hallseat
            // 
            this.hallseat.BackColor = System.Drawing.Color.Transparent;
            this.hallseat.BorderRadius = 3;
            this.hallseat.DisabledColor = System.Drawing.Color.Gray;
            this.hallseat.ForeColor = System.Drawing.Color.White;
            this.hallseat.items = new string[] {
        "0",
        "10",
        "15",
        "20",
        "25",
        "30",
        "35",
        "40",
        "45",
        "50",
        "55",
        "60",
        "65"};
            this.hallseat.Location = new System.Drawing.Point(23, 256);
            this.hallseat.Name = "hallseat";
            this.hallseat.NomalColor = System.Drawing.Color.LightBlue;
            this.hallseat.onHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.hallseat.selectedIndex = -1;
            this.hallseat.Size = new System.Drawing.Size(379, 35);
            this.hallseat.TabIndex = 20;
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.CursorType = null;
            this.bunifuLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bunifuLabel1.ForeColor = System.Drawing.Color.White;
            this.bunifuLabel1.Location = new System.Drawing.Point(23, 195);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(337, 40);
            this.bunifuLabel1.TabIndex = 21;
            this.bunifuLabel1.Text = "Salon Kapasitesi Seçin";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel2
            // 
            this.bunifuLabel2.AutoEllipsis = false;
            this.bunifuLabel2.CursorType = null;
            this.bunifuLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bunifuLabel2.ForeColor = System.Drawing.Color.White;
            this.bunifuLabel2.Location = new System.Drawing.Point(23, 90);
            this.bunifuLabel2.Name = "bunifuLabel2";
            this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel2.Size = new System.Drawing.Size(232, 40);
            this.bunifuLabel2.TabIndex = 22;
            this.bunifuLabel2.Text = "Salon İsmi Girin";
            this.bunifuLabel2.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel2.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuTileButton5
            // 
            this.bunifuTileButton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(168)))), ((int)(((byte)(1)))));
            this.bunifuTileButton5.color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(168)))), ((int)(((byte)(1)))));
            this.bunifuTileButton5.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(168)))), ((int)(((byte)(1)))));
            this.bunifuTileButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTileButton5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bunifuTileButton5.ForeColor = System.Drawing.Color.White;
            this.bunifuTileButton5.Image = ((System.Drawing.Image)(resources.GetObject("bunifuTileButton5.Image")));
            this.bunifuTileButton5.ImagePosition = 18;
            this.bunifuTileButton5.ImageZoom = 50;
            this.bunifuTileButton5.LabelPosition = 36;
            this.bunifuTileButton5.LabelText = "Salon Ekle";
            this.bunifuTileButton5.Location = new System.Drawing.Point(126, 325);
            this.bunifuTileButton5.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.bunifuTileButton5.Name = "bunifuTileButton5";
            this.bunifuTileButton5.Size = new System.Drawing.Size(161, 51);
            this.bunifuTileButton5.TabIndex = 25;
            this.bunifuTileButton5.Click += new System.EventHandler(this.bunifuTileButton5_Click);
            // 
            // addHall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(443, 394);
            this.Controls.Add(this.bunifuTileButton5);
            this.Controls.Add(this.bunifuLabel2);
            this.Controls.Add(this.bunifuLabel1);
            this.Controls.Add(this.hallseat);
            this.Controls.Add(this.hallNameTxtbox);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.bunifuImageButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "addHall";
            this.Text = "addHall";
            this.Load += new System.EventHandler(this.addHall_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox hallNameTxtbox;
        private Bunifu.Framework.UI.BunifuDropdown hallseat;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel2;
        private Bunifu.Framework.UI.BunifuTileButton bunifuTileButton5;
    }
}