namespace PriceMarkdown
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.mnuExit = new System.Windows.Forms.MenuItem();
            this.mnuNext = new System.Windows.Forms.MenuItem();
            this.mnuConnectSer = new System.Windows.Forms.MenuItem();
            this.mnuConnectBT = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(0, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 108);
            this.label1.Text = "Price Mark Down Demo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 130);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mnuExit);
            this.mainMenu1.MenuItems.Add(this.mnuNext);
            // 
            // mnuExit
            // 
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuNext
            // 
            this.mnuNext.MenuItems.Add(this.mnuConnectSer);
            this.mnuNext.MenuItems.Add(this.mnuConnectBT);
            this.mnuNext.Text = "Next";
            this.mnuNext.Click += new System.EventHandler(this.mnuNext_Click);
            // 
            // mnuConnectSer
            // 
            this.mnuConnectSer.Text = "Serial";
            this.mnuConnectSer.Click += new System.EventHandler(this.mnuConnectSer_Click);
            // 
            // mnuConnectBT
            // 
            this.mnuConnectBT.Text = "Bluetooth";
            this.mnuConnectBT.Click += new System.EventHandler(this.mnuConnectBT_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Price Markdown";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem mnuExit;
        private System.Windows.Forms.MenuItem mnuNext;
        private System.Windows.Forms.MenuItem mnuConnectSer;
        private System.Windows.Forms.MenuItem mnuConnectBT;
        private System.Windows.Forms.Label label1;
    }
}

