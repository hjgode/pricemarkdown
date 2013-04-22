using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PriceMarkdown
{
    public partial class PriceInput : UserControl
    {
        char cDecimal = ResClass.getDecimalChar;
        public PriceInput()
        {
            InitializeComponent();
            //txtPrice.Text = "0" + cDecimal +  "00";
            //w32native.SetControlDirection(txtPrice, true);
        }
        public override string Text
        {
            get{ return txtPrice.Text; }
            set { txtPrice.Text = value; }
        }
        
        char cDec = ResClass.getDecimalChar;

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {            
            //if ( (e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar!=cDec)
            //    e.Handled = true;
        }

        private void PriceInput_Resize(object sender, EventArgs e)
        {
            //center text box
            Size sizeT = txtPrice.Size;
            Size sizeP = this.Size;

            txtPrice.Size = new Size(sizeP.Width - 4, sizeP.Height - 4);
            //Point newOrigin = new Point(sizeP.Height / 2 - sizeT.Height / 2, sizeP.Width / 2 - sizeT.Width / 2);
            txtPrice.Location = new Point(2, (this.Height - txtPrice.Height) / 2);
//            txtPrice.Size = new Size(sizeP.Width - newOrigin.X*2, sizeP.Height - newOrigin.Y * 2);
            txtPrice.Refresh();
        }

        private void txtPrice_Paint(object sender, PaintEventArgs e)
        {
            int iMaxFontSize = w32native.getMaxFontSize(e.Graphics, txtPrice.Font, txtPrice.Width, 7);
            txtPrice.Font = new Font("Tahoma", iMaxFontSize, FontStyle.Regular);            
        }
    }
}
