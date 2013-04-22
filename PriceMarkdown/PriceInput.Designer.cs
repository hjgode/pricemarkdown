namespace PriceMarkdown
{
    partial class PriceInput
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtPrice = new Intermec.Windows.Forms.FormattedNumericValue();
            this.SuspendLayout();
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular);
            this.txtPrice.ForeColor = System.Drawing.Color.Red;
            this.txtPrice.InitializeValue = 0;
            this.txtPrice.Location = new System.Drawing.Point(11, 18);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.NumberofDecimals = 2;
            this.txtPrice.NumberofIntegers = 4;
            this.txtPrice.Size = new System.Drawing.Size(180, 37);
            this.txtPrice.TabIndex = 1;
            this.txtPrice.Paint += new System.Windows.Forms.PaintEventHandler(this.txtPrice_Paint);
            // 
            // PriceInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.txtPrice);
            this.Name = "PriceInput";
            this.Size = new System.Drawing.Size(202, 82);
            this.Resize += new System.EventHandler(this.PriceInput_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private Intermec.Windows.Forms.FormattedNumericValue txtPrice;
    }
}
