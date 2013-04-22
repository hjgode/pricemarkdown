namespace CommAppCF
{
    partial class BluetoothConnect
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
            this.mnuCancel = new System.Windows.Forms.MenuItem();
            this.mnuOK = new System.Windows.Forms.MenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBTAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.radioSocketConnect = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mnuCancel);
            this.mainMenu1.MenuItems.Add(this.mnuOK);
            // 
            // mnuCancel
            // 
            this.mnuCancel.Text = "Cancel";
            this.mnuCancel.Click += new System.EventHandler(this.mnuCancel_Click);
            // 
            // mnuOK
            // 
            this.mnuOK.Text = "OK";
            this.mnuOK.Click += new System.EventHandler(this.mnuOK_Click);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 21);
            this.label1.Text = "Scan or type BT MAC address:";
            // 
            // txtBTAddress
            // 
            this.txtBTAddress.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.txtBTAddress.Location = new System.Drawing.Point(12, 39);
            this.txtBTAddress.Name = "txtBTAddress";
            this.txtBTAddress.Size = new System.Drawing.Size(215, 29);
            this.txtBTAddress.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(11, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 21);
            this.label2.Text = "Example: \"0006660309E8\"";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Red;
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSearch.Location = new System.Drawing.Point(52, 133);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(137, 45);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.comboBox1.Location = new System.Drawing.Point(12, 184);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(212, 30);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // radioSocketConnect
            // 
            this.radioSocketConnect.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.radioSocketConnect.Location = new System.Drawing.Point(11, 246);
            this.radioSocketConnect.Name = "radioSocketConnect";
            this.radioSocketConnect.Size = new System.Drawing.Size(215, 19);
            this.radioSocketConnect.TabIndex = 9;
            this.radioSocketConnect.Text = "direct Socket";
            this.radioSocketConnect.Visible = false;
            this.radioSocketConnect.CheckStateChanged += new System.EventHandler(this.radioSerialPort_CheckedChanged);
            // 
            // BluetoothConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.ControlBox = false;
            this.Controls.Add(this.radioSocketConnect);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtBTAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Menu = this.mainMenu1;
            this.Name = "BluetoothConnect";
            this.Text = "BluetoothConnect";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem mnuCancel;
        private System.Windows.Forms.MenuItem mnuOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBTAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox radioSocketConnect;
    }
}