namespace WindowsFormsApp1
{
    partial class Form5
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuDropdown2 = new Bunifu.UI.WinForms.BunifuDropdown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuThinButton21 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bunifuThinButton22 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bunifuImageButton2 = new Bunifu.Framework.UI.BunifuImageButton();
            this.kuponid = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox();
            this.kuponadet = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuDropdown2
            // 
            this.bunifuDropdown2.BackColor = System.Drawing.SystemColors.Control;
            this.bunifuDropdown2.BorderRadius = 1;
            this.bunifuDropdown2.Color = System.Drawing.Color.Blue;
            this.bunifuDropdown2.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.bunifuDropdown2.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuDropdown2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.bunifuDropdown2.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thick;
            this.bunifuDropdown2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bunifuDropdown2.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.bunifuDropdown2.FillDropDown = false;
            this.bunifuDropdown2.FillIndicator = false;
            this.bunifuDropdown2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bunifuDropdown2.ForeColor = System.Drawing.Color.Blue;
            this.bunifuDropdown2.FormattingEnabled = true;
            this.bunifuDropdown2.Icon = null;
            this.bunifuDropdown2.IndicatorColor = System.Drawing.Color.Blue;
            this.bunifuDropdown2.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.bunifuDropdown2.ItemBackColor = System.Drawing.Color.White;
            this.bunifuDropdown2.ItemBorderColor = System.Drawing.Color.White;
            this.bunifuDropdown2.ItemForeColor = System.Drawing.Color.Blue;
            this.bunifuDropdown2.ItemHeight = 26;
            this.bunifuDropdown2.ItemHighLightColor = System.Drawing.Color.Silver;
            this.bunifuDropdown2.Items.AddRange(new object[] {
            "10",
            "20",
            "50",
            "100"});
            this.bunifuDropdown2.Location = new System.Drawing.Point(238, 340);
            this.bunifuDropdown2.Name = "bunifuDropdown2";
            this.bunifuDropdown2.Size = new System.Drawing.Size(208, 32);
            this.bunifuDropdown2.TabIndex = 26;
            this.bunifuDropdown2.Text = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(105, 347);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 23);
            this.label2.TabIndex = 24;
            this.label2.Text = "İndirim Miktarı";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(105, 305);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 23);
            this.label1.TabIndex = 23;
            this.label1.Text = "Kupon Adı";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApp1.Properties.Resources.raffleticket1;
            this.pictureBox1.Location = new System.Drawing.Point(179, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(214, 212);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // bunifuThinButton21
            // 
            this.bunifuThinButton21.ActiveBorderThickness = 1;
            this.bunifuThinButton21.ActiveCornerRadius = 20;
            this.bunifuThinButton21.ActiveFillColor = System.Drawing.Color.Blue;
            this.bunifuThinButton21.ActiveForecolor = System.Drawing.Color.White;
            this.bunifuThinButton21.ActiveLineColor = System.Drawing.Color.Blue;
            this.bunifuThinButton21.BackColor = System.Drawing.SystemColors.Control;
            this.bunifuThinButton21.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuThinButton21.BackgroundImage")));
            this.bunifuThinButton21.ButtonText = "Kuponu Tanımla";
            this.bunifuThinButton21.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuThinButton21.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.bunifuThinButton21.ForeColor = System.Drawing.Color.Blue;
            this.bunifuThinButton21.IdleBorderThickness = 1;
            this.bunifuThinButton21.IdleCornerRadius = 20;
            this.bunifuThinButton21.IdleFillColor = System.Drawing.Color.White;
            this.bunifuThinButton21.IdleForecolor = System.Drawing.Color.Blue;
            this.bunifuThinButton21.IdleLineColor = System.Drawing.Color.Blue;
            this.bunifuThinButton21.Location = new System.Drawing.Point(104, 440);
            this.bunifuThinButton21.Margin = new System.Windows.Forms.Padding(5);
            this.bunifuThinButton21.Name = "bunifuThinButton21";
            this.bunifuThinButton21.Size = new System.Drawing.Size(164, 68);
            this.bunifuThinButton21.TabIndex = 28;
            this.bunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuThinButton21.Click += new System.EventHandler(this.bunifuThinButton21_Click);
            // 
            // bunifuThinButton22
            // 
            this.bunifuThinButton22.ActiveBorderThickness = 1;
            this.bunifuThinButton22.ActiveCornerRadius = 20;
            this.bunifuThinButton22.ActiveFillColor = System.Drawing.Color.Blue;
            this.bunifuThinButton22.ActiveForecolor = System.Drawing.Color.White;
            this.bunifuThinButton22.ActiveLineColor = System.Drawing.Color.Blue;
            this.bunifuThinButton22.BackColor = System.Drawing.SystemColors.Control;
            this.bunifuThinButton22.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuThinButton22.BackgroundImage")));
            this.bunifuThinButton22.ButtonText = "Güncelle";
            this.bunifuThinButton22.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuThinButton22.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.bunifuThinButton22.ForeColor = System.Drawing.Color.Blue;
            this.bunifuThinButton22.IdleBorderThickness = 1;
            this.bunifuThinButton22.IdleCornerRadius = 20;
            this.bunifuThinButton22.IdleFillColor = System.Drawing.Color.White;
            this.bunifuThinButton22.IdleForecolor = System.Drawing.Color.Blue;
            this.bunifuThinButton22.IdleLineColor = System.Drawing.Color.Blue;
            this.bunifuThinButton22.Location = new System.Drawing.Point(287, 440);
            this.bunifuThinButton22.Margin = new System.Windows.Forms.Padding(5);
            this.bunifuThinButton22.Name = "bunifuThinButton22";
            this.bunifuThinButton22.Size = new System.Drawing.Size(164, 68);
            this.bunifuThinButton22.TabIndex = 27;
            this.bunifuThinButton22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bunifuImageButton2
            // 
            this.bunifuImageButton2.Image = global::WindowsFormsApp1.Properties.Resources.carpi;
            this.bunifuImageButton2.ImageActive = global::WindowsFormsApp1.Properties.Resources.carpi;
            this.bunifuImageButton2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bunifuImageButton2.Location = new System.Drawing.Point(530, 12);
            this.bunifuImageButton2.Name = "bunifuImageButton2";
            this.bunifuImageButton2.Size = new System.Drawing.Size(23, 26);
            this.bunifuImageButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton2.TabIndex = 21;
            this.bunifuImageButton2.TabStop = false;
            this.bunifuImageButton2.Zoom = 10;
            this.bunifuImageButton2.Click += new System.EventHandler(this.bunifuImageButton2_Click);
            // 
            // kuponid
            // 
            this.kuponid.AcceptsReturn = false;
            this.kuponid.AcceptsTab = false;
            this.kuponid.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.kuponid.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.kuponid.BackColor = System.Drawing.Color.Transparent;
            this.kuponid.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("kuponid.BackgroundImage")));
            this.kuponid.BorderColorActive = System.Drawing.Color.Blue;
            this.kuponid.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.kuponid.BorderColorHover = System.Drawing.Color.RoyalBlue;
            this.kuponid.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.kuponid.BorderRadius = 1;
            this.kuponid.BorderThickness = 2;
            this.kuponid.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.kuponid.DefaultFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kuponid.DefaultText = "";
            this.kuponid.FillColor = System.Drawing.Color.White;
            this.kuponid.HideSelection = true;
            this.kuponid.IconLeft = null;
            this.kuponid.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.kuponid.IconPadding = 10;
            this.kuponid.IconRight = null;
            this.kuponid.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.kuponid.Location = new System.Drawing.Point(237, 299);
            this.kuponid.MaxLength = 32767;
            this.kuponid.MinimumSize = new System.Drawing.Size(100, 35);
            this.kuponid.Modified = false;
            this.kuponid.Name = "kuponid";
            this.kuponid.PasswordChar = '\0';
            this.kuponid.ReadOnly = false;
            this.kuponid.SelectedText = "";
            this.kuponid.SelectionLength = 0;
            this.kuponid.SelectionStart = 0;
            this.kuponid.ShortcutsEnabled = true;
            this.kuponid.Size = new System.Drawing.Size(209, 35);
            this.kuponid.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Bunifu;
            this.kuponid.TabIndex = 36;
            this.kuponid.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.kuponid.TextMarginLeft = 1;
            this.kuponid.TextPlaceholder = "";
            this.kuponid.UseSystemPasswordChar = false;
            // 
            // kuponadet
            // 
            this.kuponadet.AcceptsReturn = false;
            this.kuponadet.AcceptsTab = false;
            this.kuponadet.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.kuponadet.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.kuponadet.BackColor = System.Drawing.Color.Transparent;
            this.kuponadet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("kuponadet.BackgroundImage")));
            this.kuponadet.BorderColorActive = System.Drawing.Color.Blue;
            this.kuponadet.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.kuponadet.BorderColorHover = System.Drawing.Color.RoyalBlue;
            this.kuponadet.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.kuponadet.BorderRadius = 1;
            this.kuponadet.BorderThickness = 2;
            this.kuponadet.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.kuponadet.DefaultFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kuponadet.DefaultText = "";
            this.kuponadet.FillColor = System.Drawing.Color.White;
            this.kuponadet.HideSelection = true;
            this.kuponadet.IconLeft = null;
            this.kuponadet.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.kuponadet.IconPadding = 10;
            this.kuponadet.IconRight = null;
            this.kuponadet.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.kuponadet.Location = new System.Drawing.Point(238, 379);
            this.kuponadet.MaxLength = 32767;
            this.kuponadet.MinimumSize = new System.Drawing.Size(100, 35);
            this.kuponadet.Modified = false;
            this.kuponadet.Name = "kuponadet";
            this.kuponadet.PasswordChar = '\0';
            this.kuponadet.ReadOnly = false;
            this.kuponadet.SelectedText = "";
            this.kuponadet.SelectionLength = 0;
            this.kuponadet.SelectionStart = 0;
            this.kuponadet.ShortcutsEnabled = true;
            this.kuponadet.Size = new System.Drawing.Size(209, 35);
            this.kuponadet.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Bunifu;
            this.kuponadet.TabIndex = 38;
            this.kuponadet.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.kuponadet.TextMarginLeft = 1;
            this.kuponadet.TextPlaceholder = "";
            this.kuponadet.UseSystemPasswordChar = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(106, 384);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 23);
            this.label3.TabIndex = 37;
            this.label3.Text = "Kupon Adeti";
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 527);
            this.Controls.Add(this.kuponadet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.kuponid);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bunifuThinButton21);
            this.Controls.Add(this.bunifuThinButton22);
            this.Controls.Add(this.bunifuDropdown2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bunifuImageButton2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form5";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton21;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton22;
        private Bunifu.UI.WinForms.BunifuDropdown bunifuDropdown2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox kuponadet;
        private System.Windows.Forms.Label label3;
        private Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox kuponid;
    }
}