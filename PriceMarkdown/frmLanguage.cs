using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO.Ports;
using Comm.BT;

namespace PriceMarkdown
{
    public partial class frmLanguage : Form
    {
        SerialPort _sp = null;
        Comm.BT.BTPort _bt = null;
        public frmLanguage(ref SerialPort sp, ref BTPort bt)
        {
            InitializeComponent();
            _sp = sp;
            _bt = bt;
            ResClass2 res = ResClass2.getInstance();
            res.colorizeForm(this);

            btnLangDE.Text = res._buttonTexts[0];
            btnLangEN.Text = res._buttonTexts[1];
            btnLangES.Text = res._buttonTexts[2];
        }

        private void mnuBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLangEN_Click(object sender, EventArgs e)
        {
            showPrintForm(1);
        }
        void showPrintForm(int iLang){
            frmPrint dlg = new frmPrint(ref _bt, ref _sp, iLang);
            dlg.ShowDialog();
            dlg.Dispose();
        }

        private void btnLangDE_Click(object sender, EventArgs e)
        {
            showPrintForm(0);
        }

        private void btnLangES_Click(object sender, EventArgs e)
        {
            showPrintForm(2);
        }
    }
}