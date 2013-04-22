namespace PriceMarkdown
{
    partial class frmPrint
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.mnuBack = new System.Windows.Forms.MenuItem();
            this.lblOldPrice = new System.Windows.Forms.Label();
            this.lblNewPrice = new System.Windows.Forms.Label();
            this.txtPriceOld = new Intermec.Windows.Forms.FormattedNumericValue();
            this.txtPriceNew = new Intermec.Windows.Forms.FormattedNumericValue();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblCurrencyOld = new System.Windows.Forms.Label();
            this.lblCurrencyNew = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mnuBack);
            // 
            // mnuBack
            // 
            this.mnuBack.Text = "Back";
            this.mnuBack.Click += new System.EventHandler(this.mnuBack_Click);
            // 
            // lblOldPrice
            // 
            this.lblOldPrice.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular);
            this.lblOldPrice.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblOldPrice.Location = new System.Drawing.Point(16, 10);
            this.lblOldPrice.Name = "lblOldPrice";
            this.lblOldPrice.Size = new System.Drawing.Size(210, 33);
            this.lblOldPrice.Text = "Alter Preis";
            this.lblOldPrice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblNewPrice
            // 
            this.lblNewPrice.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular);
            this.lblNewPrice.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNewPrice.Location = new System.Drawing.Point(16, 97);
            this.lblNewPrice.Name = "lblNewPrice";
            this.lblNewPrice.Size = new System.Drawing.Size(210, 32);
            this.lblNewPrice.Text = "Neuer Preis";
            this.lblNewPrice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtPriceOld
            // 
            this.txtPriceOld.BackColor = System.Drawing.Color.White;
            this.txtPriceOld.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold);
            this.txtPriceOld.ForeColor = System.Drawing.Color.Black;
            this.txtPriceOld.InitializeValue = 0;
            this.txtPriceOld.Location = new System.Drawing.Point(45, 46);
            this.txtPriceOld.Name = "txtPriceOld";
            this.txtPriceOld.NumberofDecimals = 2;
            this.txtPriceOld.NumberofIntegers = 4;
            this.txtPriceOld.OverwriteBackColor = System.Drawing.Color.Red;
            this.txtPriceOld.Size = new System.Drawing.Size(158, 45);
            this.txtPriceOld.TabIndex = 1;
            // 
            // txtPriceNew
            // 
            this.txtPriceNew.BackColor = System.Drawing.Color.White;
            this.txtPriceNew.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold);
            this.txtPriceNew.ForeColor = System.Drawing.Color.Black;
            this.txtPriceNew.InitializeValue = 0;
            this.txtPriceNew.Location = new System.Drawing.Point(45, 132);
            this.txtPriceNew.Name = "txtPriceNew";
            this.txtPriceNew.NumberofDecimals = 2;
            this.txtPriceNew.NumberofIntegers = 4;
            this.txtPriceNew.OverwriteBackColor = System.Drawing.Color.Red;
            this.txtPriceNew.Size = new System.Drawing.Size(158, 45);
            this.txtPriceNew.TabIndex = 2;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Red;
            this.btnPrint.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular);
            this.btnPrint.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPrint.Location = new System.Drawing.Point(21, 198);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(205, 62);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "Drucken";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblCurrencyOld
            // 
            this.lblCurrencyOld.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.lblCurrencyOld.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCurrencyOld.Location = new System.Drawing.Point(205, 46);
            this.lblCurrencyOld.Name = "lblCurrencyOld";
            this.lblCurrencyOld.Size = new System.Drawing.Size(35, 44);
            this.lblCurrencyOld.Text = "€";
            this.lblCurrencyOld.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCurrencyNew
            // 
            this.lblCurrencyNew.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.lblCurrencyNew.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCurrencyNew.Location = new System.Drawing.Point(205, 132);
            this.lblCurrencyNew.Name = "lblCurrencyNew";
            this.lblCurrencyNew.Size = new System.Drawing.Size(35, 44);
            this.lblCurrencyNew.Text = "£";
            this.lblCurrencyNew.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.ControlBox = false;
            this.Controls.Add(this.lblCurrencyNew);
            this.Controls.Add(this.lblCurrencyOld);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtPriceNew);
            this.Controls.Add(this.txtPriceOld);
            this.Controls.Add(this.lblNewPrice);
            this.Controls.Add(this.lblOldPrice);
            this.Menu = this.mainMenu1;
            this.Name = "frmPrint";
            this.Text = "Drucken";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmPrint_Paint);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmPrint_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem mnuBack;
        private System.Windows.Forms.Label lblOldPrice;
        private System.Windows.Forms.Label lblNewPrice;
        private Intermec.Windows.Forms.FormattedNumericValue txtPriceOld;
        private Intermec.Windows.Forms.FormattedNumericValue txtPriceNew;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblCurrencyOld;
        private System.Windows.Forms.Label lblCurrencyNew;
    }
}