using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CommAppCF;
using System.IO.Ports;
using Comm.BT;

namespace PriceMarkdown
{
    public partial class Form1 : Form
    {
        ResClass2 _resClass;
        private SerialPort comport = new SerialPort();
        private BTPort btport = new BTPort();
        private bool bUseSocket;

        public Form1()
        {
            InitializeComponent();
            _resClass = ResClass2.getInstance();
            _resClass.colorizeForm(this);

            pictureBox1.Image = _resClass.getImage();
            mnuConnectBT.Enabled = false;   //currently no BT direct socket printing
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuNext_Click(object sender, EventArgs e)
        {
        }

        private void mnuConnectBT_Click(object sender, EventArgs e)
        {
            byte[] bdAddress = new byte[6];
            BluetoothConnect dlg = new BluetoothConnect(ref btport);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                bUseSocket = true;
                bdAddress = dlg.bdAddress;
                dlg.Dispose();
                showLangSelect(ref comport, ref btport);
            }
            else
                dlg.Dispose();            
        }

        private void mnuConnectSer_Click(object sender, EventArgs e)
        {
            bUseSocket = false;
            ConnectDlg dlg = new ConnectDlg(ref comport);
            dlg.ShowDialog();
            if(dlg.DialogResult==DialogResult.OK){
                dlg.Dispose();
                showLangSelect(ref comport, ref btport);
            }
            else
                dlg.Dispose();            
        }
        void showLangSelect(ref SerialPort serConn, ref Comm.BT.BTPort btConn)
        {
            comport = serConn;
            btport = btConn;
            //if (bUseSocket)
            //    comport = null;
            //else
            //    btport = null;
            frmLanguage dlg = new frmLanguage(ref comport, ref btport);
            dlg.ShowDialog();
            dlg.Dispose();
        }
    }
}