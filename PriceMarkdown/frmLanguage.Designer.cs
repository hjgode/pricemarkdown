namespace PriceMarkdown
{
    partial class frmLanguage
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
            this.btnLangDE = new System.Windows.Forms.Button();
            this.btnLangEN = new System.Windows.Forms.Button();
            this.btnLangES = new System.Windows.Forms.Button();
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
            // btnLangDE
            // 
            this.btnLangDE.BackColor = System.Drawing.Color.Red;
            this.btnLangDE.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular);
            this.btnLangDE.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLangDE.Location = new System.Drawing.Point(19, 21);
            this.btnLangDE.Name = "btnLangDE";
            this.btnLangDE.Size = new System.Drawing.Size(205, 62);
            this.btnLangDE.TabIndex = 0;
            this.btnLangDE.Text = "Deutsch";
            this.btnLangDE.Click += new System.EventHandler(this.btnLangDE_Click);
            // 
            // btnLangEN
            // 
            this.btnLangEN.BackColor = System.Drawing.Color.Red;
            this.btnLangEN.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular);
            this.btnLangEN.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLangEN.Location = new System.Drawing.Point(19, 89);
            this.btnLangEN.Name = "btnLangEN";
            this.btnLangEN.Size = new System.Drawing.Size(205, 62);
            this.btnLangEN.TabIndex = 0;
            this.btnLangEN.Text = "English";
            this.btnLangEN.Click += new System.EventHandler(this.btnLangEN_Click);
            // 
            // btnLangES
            // 
            this.btnLangES.BackColor = System.Drawing.Color.Red;
            this.btnLangES.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular);
            this.btnLangES.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLangES.Location = new System.Drawing.Point(19, 157);
            this.btnLangES.Name = "btnLangES";
            this.btnLangES.Size = new System.Drawing.Size(205, 62);
            this.btnLangES.TabIndex = 0;
            this.btnLangES.Text = "Espanol";
            this.btnLangES.Click += new System.EventHandler(this.btnLangES_Click);
            // 
            // frmLanguage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.ControlBox = false;
            this.Controls.Add(this.btnLangES);
            this.Controls.Add(this.btnLangEN);
            this.Controls.Add(this.btnLangDE);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "frmLanguage";
            this.Text = "Select Language";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem mnuBack;
        private System.Windows.Forms.Button btnLangDE;
        private System.Windows.Forms.Button btnLangEN;
        private System.Windows.Forms.Button btnLangES;
    }
}