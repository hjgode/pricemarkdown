﻿using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using OpenNETCF.Net.Bluetooth;

namespace CommAppCF
{
    public partial class BluetoothConnect : Form
    {
        //using intermec bluetooth tool
        [DllImport("ibt.dll", SetLastError = true)]
        private static extern bool IBT_SetPrinter(StringBuilder AddrString, bool Register);
        [DllImport("ibt.dll", SetLastError = true)]
        private static extern UInt32 IBT_On (); 
        
        //using SetBtPrinter.DLL, needs pswdm0c.cab (pswdm0cDll.dll) installed on intermec!
        [DllImport("SetBtPrinter.dll", SetLastError = true)]
        private static extern int registerPrinter(StringBuilder AddrString);

        public bool bUseSocket = false;
        public byte[] bdAddress;
        private Comm.BT.BTPort _btport;

        public BluetoothConnect(ref Comm.BT.BTPort btport)
        {
            PriceMarkdown.ResClass2 _resClass = PriceMarkdown.ResClass2.getInstance();
            _resClass.colorizeForm(this);

            _btport = btport;
            InitializeComponent();
#if DEBUG
            txtBTAddress.Text = "000666025f1d";
#endif
        }
        /*
        */
        private bool serialPortConnect()
        {
            bool bSuccess = false;
            int iRes = -1;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                StringBuilder sb = new StringBuilder(txtBTAddress.Text);
                if (System.IO.File.Exists(@"\Windows\pswdm0cDLL.dll"))
                {
                    iRes = registerPrinter(sb); //this may take a while...
                    if (iRes != 0)
                    {
                        System.Diagnostics.Debug.WriteLine("registerPrinter failed:" + Marshal.GetLastWin32Error().ToString("x"));
                        PriceMarkdown.Helpers.logError("registerPrinter failed:" + Marshal.GetLastWin32Error().ToString("x"));
                        bSuccess = false;
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("registerPrinter OK");
                        PriceMarkdown.Helpers.logError("registerPrinter OK");
                        bSuccess = true;
                    }
                }
                else if (System.IO.File.Exists(@"\Windows\ibt.dll"))
                {
                    bSuccess = IBT_SetPrinter(sb, true);
                    if (!bSuccess)
                    {
                        System.Diagnostics.Debug.WriteLine("IBT_SetPrinter failed:" + Marshal.GetLastWin32Error().ToString("x"));
                        PriceMarkdown.Helpers.logError("IBT_SetPrinter failed:" + Marshal.GetLastWin32Error().ToString("x"));
                    }
                    else
                        System.Diagnostics.Debug.WriteLine("IBT_SetPrinter OK");

                }
            }
            catch (Exception)
            {
                bSuccess = false;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            if (bSuccess)
            {
                MessageBox.Show("Connection success");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Connection failed");
                this.DialogResult = DialogResult.Abort;
            }
            return bSuccess;
        }
        private void mnuOK_Click(object sender, EventArgs e)
        {
            if (!bUseSocket)
            {
                if (serialPortConnect())
                    DialogResult = DialogResult.OK;
                else
                    DialogResult = DialogResult.Cancel;
            }
            else
            {
                string sBDA = txtBTAddress.Text;
                int iDisc = 0;
                byte[] bTemp = hexHelper.GetBytes(sBDA, out iDisc);
                byte[] bRev = hexHelper.reverseBytes(bTemp);
                _btport.Open(bRev);
                DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void mnuCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void radioSerialPort_CheckedChanged(object sender, EventArgs e)
        {
            bUseSocket = radioSocketConnect.Checked;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            BluetoothDeviceInfo[] bdi;
            BluetoothClient bc = new BluetoothClient();
            bdi = bc.DiscoverDevices();
            comboBox1.DisplayMember = "DeviceName";
            comboBox1.ValueMember = "DeviceID";
            comboBox1.DataSource = bdi;
            if(comboBox1.Items.Count>0)
                comboBox1.SelectedIndex = 0;
            bc.Close();
            Cursor.Current = Cursors.Default;
            this.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = comboBox1.SelectedIndex;
            if (x == -1)
                return;

            BluetoothDeviceInfo BDI = (BluetoothDeviceInfo)(comboBox1.Items[x]);
            bdAddress = BDI.DeviceID;
            byte[] bDisplay = hexHelper.reverseBytes(bdAddress);
            txtBTAddress.Text = hexHelper.ToString(bDisplay);
        }
    }
}