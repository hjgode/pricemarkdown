using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PriceMarkdown
{
    public partial class frmPrint : Form
    {
        string varLabel = "reduziert";
        Comm.BT.BTPort _btPort;
        System.IO.Ports.SerialPort _serPort;
        ResClass2 res;
        int _iLang = 0;

        public frmPrint(ref Comm.BT.BTPort btPort, ref System.IO.Ports.SerialPort serPort, int iLang)
        {
            InitializeComponent();
            _iLang = iLang;
            _btPort = btPort;
            _serPort = serPort;

            res = ResClass2.getInstance();
            res.colorizeForm(this);

            lblOldPrice.Text = res._labelsText(ResClass2.frmPrintText.oldPrice, iLang);
            lblNewPrice.Text = res._labelsText(ResClass2.frmPrintText.newPrice, iLang);
            btnPrint.Text = res._labelsText(ResClass2.frmPrintText.printButton, iLang);

            varLabel = res._reducedText(iLang);// getVarLabel(iLang);

            lblCurrencyOld.Text = ResClass2.sCurrency[iLang];
            lblCurrencyNew.Text = ResClass2.sCurrency[iLang];
        }

        private void mnuBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPrint_Paint(object sender, PaintEventArgs e)
        {
            int iMaxFontSize = w32native.getMaxFontSize(e.Graphics, txtPriceOld.Font, txtPriceOld.Width, 8);
            txtPriceOld.Font = new Font("Tahoma", iMaxFontSize, FontStyle.Bold);
            txtPriceNew.Font = new Font("Tahoma", iMaxFontSize, FontStyle.Bold);
            
            iMaxFontSize = w32native.getMaxFontSize(e.Graphics, lblCurrencyOld.Font, lblCurrencyOld.Width, 1);
            lblCurrencyOld.Font = new Font("Tahoma", iMaxFontSize, FontStyle.Regular);
            lblCurrencyNew.Font = new Font("Tahoma", iMaxFontSize, FontStyle.Regular);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (_serPort != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    if (!_serPort.IsOpen)
                        _serPort.Open();
                    _serPort.WriteTimeout = 15000;
                    //send layout once per session
                    if (!res._bLayoutSended)
                    {
                        string sLayout = res.getLayoutPRN();
                        if (sLayout.Length == 0)
                            throw new NullReferenceException("LayoutPRN is empty!");
                        byte[] bLayout = Encoding.UTF8.GetBytes(sLayout);
                        _serPort.Write(bLayout, 0, bLayout.Length);
                        res._bLayoutSended = true;
                    }

                    //string sSample = res.getSamplePRN();
                    string sSample = res.getPriceMark(txtPriceOld.Text, txtPriceNew.Text, _iLang);
                    if (sSample.Length == 0)
                        throw new NullReferenceException("Print data is empty!");

                    byte[] bSample = Encoding.UTF8.GetBytes(sSample);
                    _serPort.Write(bSample, 0, bSample.Length);
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    System.Diagnostics.Debug.WriteLine("Exception in print(): " + ex.Message);
                    Helpers.logError("Exception in print(): " + ex.Message);
                    MessageBox.Show("Printing failed. Please restart. " + ex.Message);
                    _serPort.Close();
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void frmPrint_Closing(object sender, CancelEventArgs e)
        {
            if (_serPort.IsOpen)
                _serPort.Close();
        }
    }
}