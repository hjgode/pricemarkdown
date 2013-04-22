using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

using System.Globalization;
using System.Windows.Forms;
using System.Xml;

using System.Drawing;
using System.IO;

namespace PriceMarkdown
{
    class ResClass3
    {
        string[] resourceNames;
        static ResClass3 _instance;
        public static ResClass3 getInstance()
        {
            if (_instance == null)
                _instance = new ResClass3();
            return _instance; 
        }
        static string _AppPath;
        public static string AppPath(){
            if (_AppPath==null || _AppPath == "")
            {
                _AppPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                if (!_AppPath.EndsWith(@"\"))
                    _AppPath += @"\";
            }
            return _AppPath;
        }

        private ResClass3()
        {
            AppPath();
            resourceNames = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames();
            getColors();
            getButtonText();
            getLabelText(0);
            getVarLabelText(0);
            readCurrencies();
            _sCurrency = sCurrency[0];
        }
        private ResClass3(int iLang):this()
        {
            getLabelText(iLang);
            getVarLabelText(iLang);
            _sCurrency = sCurrency[iLang];
        }
        
        /// <summary>
        /// remember to send layout ONE time
        /// </summary>
        static bool bLayoutSended=false;
        public bool _bLayoutSended
        {
            get { return bLayoutSended; }
            set { bLayoutSended = true; }
        }

        public string getLayoutPRN()
        {
            string sLayout = "";
            if (existAppFile("layout-prn.txt"))
            {
                System.IO.TextReader tr = new System.IO.StreamReader(AppPath() + "layout-prn.txt");
                sLayout = tr.ReadToEnd();
                tr.Close();
            }
            else
            {
                using (Stream stream = this.GetType().Assembly.GetManifestResourceStream("PriceMarkdown.printfiles.layout-prn.txt"))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        sLayout = reader.ReadToEnd();
                    } 
                }
            }
            return sLayout;
        }
        public string getPriceMark(string sOldPrice, string sNewPrice, int iLang)
        {
            StringBuilder sb = new StringBuilder();
            string varLabel = this.getVarLabel(iLang);
            sb.Append("LAYOUT RUN \"c:PRICE_MARKDOWN.LAY\"");
            sb.Append("\r\n");
            sb.Append("INPUT ON");
            sb.Append("\r\n");
            //sb.Append("...stark reduziert");
            sb.Append("" + varLabel);  //starts with 0x02
            sb.Append("\r\n");
            //sb.Append("9,95");
            sb.Append(sOldPrice);
            sb.Append("\r\n");
            //sb.Append("2,85");
            sb.Append(sNewPrice);
            sb.Append("\r\n");
            sb.Append("76589");
            sb.Append("\r\n");
            sb.Append(sCurrency[iLang]);
            sb.Append("\r\n");
            sb.Append("");             //ends with 0x03
            sb.Append("\r\n");
            sb.Append("PF");
            sb.Append("\r\n");
            sb.Append("PRINT KEY OFF");
            sb.Append("\r\n");

            return sb.ToString();
        }
        string getDezimal(float fNumber)
        {            
            string s = fNumber.ToString("#"+getDecimalChar.ToString()+"##");
            s.Replace('.', ',');
            return s;
        }

        public string getSamplePRN()
        {
            string sLayout = "";
            if (existAppFile("sample-prn.txt"))
            {
                System.IO.TextReader tr = new System.IO.StreamReader(AppPath() + "sample-prn.txt");
                sLayout = tr.ReadToEnd();
                tr.Close();
            }
            else
            {
                using (Stream stream = this.GetType().Assembly.GetManifestResourceStream("PriceMarkdown.printfiles.sample-prn.txt"))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        sLayout = reader.ReadToEnd();
                    }
                }
            }
            return sLayout;
        }

        public System.Drawing.Image getImage()
        {
            System.Drawing.Image _Image=null;
            if (existAppFile("startlogo.gif"))
            {
                _Image = new Bitmap(_AppPath + "startlogo.gif");
            }
            else
            {
                _Image = new Bitmap(this.GetType().Assembly.GetManifestResourceStream("PriceMarkdown.Images.startlogo.gif"));
            }
            return _Image;
        }

        private bool existAppFile(string sFile)
        {
            return System.IO.File.Exists(_AppPath + sFile);
        }

        public static char getDecimalChar
        {
            get
            {
                //System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.CurrentCulture;
                //string sDec = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
                char cDec = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator.ToCharArray()[0];
                return cDec;
            }
        }

#region text resources
        //read strings from xml for button and labels
        string[] sCurrency;
        string[] sCurrencyDefaults = { "€", "$", "€" };
        public string _sCurrency = "€";
        void readCurrencies()
        {
            sCurrency = sCurrencyDefaults;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();

                if (existAppFile("buttontexts.xml"))
                {
                    xmlDoc.Load(_AppPath + "buttontexts.xml");
                    logInfo("Using external resource " + _AppPath + "buttontexts.xml");
                }
                else
                {
                    logInfo("Using internal resource " + "PriceMarkdown.textxml.buttontexts.xml");
                    //string sString = "";
                    using (Stream stream = this.GetType().Assembly.GetManifestResourceStream("PriceMarkdown.textxml.buttontexts.xml"))
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            //sString = reader.ReadToEnd();
                            xmlDoc.Load(reader);
                        }
                    }
                }
                parseCurrencyXml(xmlDoc);
            }
            catch (Exception) { }
        }
        bool parseCurrencyXml(XmlDocument docXML)
        {
            bool bRet = false;
            try
            {
                XmlNodeList baseNodeList = docXML.SelectNodes("text/currencies/currency");
                foreach (XmlNode n in baseNodeList)
                {
                    int iID = int.Parse(n.Attributes["id"].Value);
                    if (iID > -1 && iID < 3)
                        sCurrency[iID] = n.Attributes["text"].Value;
                }
                bRet = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception in parseCurrencyXml():" + ex.Message);
            }
            return bRet;
        }
        //############################################
        static string[] buttonText;
        public string[] _buttonTexts{
            get { return buttonText; }
        }
        static string[] ButtonTextDefault = { "deutsch", "english", "espanol" };
        
        void getButtonText()
        {
            //default text
            buttonText = ButtonTextDefault;
            //buttonText[0] = "Deutsch";
            //buttonText[1] = "English";
            //buttonText[2] = "Espanol";
            try
            {
                XmlDocument xmlDoc = new XmlDocument();

                if (existAppFile("buttontexts.xml"))
                {
                    xmlDoc.Load(_AppPath + "buttontexts.xml");
                }
                else
                {
                    //string sString = "";
                    using (Stream stream = this.GetType().Assembly.GetManifestResourceStream("PriceMarkdown.textxml.buttontexts.xml"))
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            //sString = reader.ReadToEnd();
                            xmlDoc.Load(reader);
                        }
                    }
                }
                parseButtonXml(xmlDoc);
            }
            catch (Exception) { }
        }
        bool parseButtonXml(XmlDocument docXML)
        {
            bool bRet = false;
            try
            {
                XmlNodeList baseNodeList = docXML.SelectNodes("text/buttons/button");
                foreach (XmlNode n in baseNodeList)
                {
                    int iID = int.Parse(n.Attributes["id"].Value);
                    if (iID > -1 && iID < 3)
                        buttonText[iID] = n.Attributes["text"].Value;
                }
                bRet = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception in parseButtonXml():" + ex.Message);
            }
            return bRet;
        }

        //###########################################################################################
        static string varLabel;
        public string _varLabel
        {
            get { return varLabel; }
        }
        public string getVarLabel(int iLang)
        {
            getVarLabelText(iLang);
            return varLabel;
        }
        static string varLabelTextDefault = "reduziert";
        void getVarLabelText(int iLang)
        {
            //default text
            varLabel = varLabelTextDefault;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();

                if (existAppFile("buttontexts.xml"))
                {
                    xmlDoc.Load(_AppPath + "buttontexts.xml");
                }
                else
                {
                    //string sString = "";
                    using (Stream stream = this.GetType().Assembly.GetManifestResourceStream("PriceMarkdown.textxml.buttontexts.xml"))
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            //sString = reader.ReadToEnd();
                            xmlDoc.Load(reader);
                        }
                    }
                }
                parseVarLabelText(xmlDoc, iLang);
            }
            catch (Exception) { }
        }
        bool parseVarLabelText(XmlDocument docXML, int iLang)
        {
            bool bRet = false;
            try
            {
                XmlNodeList baseNodeList = docXML.SelectNodes("text/vars/var");
                foreach (XmlNode n in baseNodeList)
                {
                    if(n.Attributes["id"].Value == iLang.ToString())
                        varLabel = n.Attributes["text"].Value;
                }
                bRet = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception in parseVarLabelText():" + ex.Message);
            }
            return bRet;
        }

        //###########################################################################################
        static string[] labels;
        public string[] _labelsText
        {
            get { return labels; }
        }
        public string[] _getLabelsText(int iLang)
        {
            getLabelText(iLang);
            return labels;
        }
        static string[] labelTextDefault = { "Alter Preis", "Neuer Preis", "Drucken" };
        void getLabelText(int iLang)
        {
            //default text
            labels = labelTextDefault;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();

                if (existAppFile("buttontexts.xml"))
                {
                    xmlDoc.Load(_AppPath + "buttontexts.xml");
                }
                else
                {
                    //string sString = "";
                    using (Stream stream = this.GetType().Assembly.GetManifestResourceStream("PriceMarkdown.textxml.buttontexts.xml"))
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            //sString = reader.ReadToEnd();
                            xmlDoc.Load(reader);
                        }
                    }
                }
                parseLabelText(xmlDoc, iLang);
            }
            catch (Exception) { }
        }
        bool parseLabelText(XmlDocument docXML, int iLang)
        {
            bool bRet = false;
            try
            {
                XmlNodeList baseNodeList = docXML.SelectNodes("text/labels/labels" + iLang.ToString()+"/label");
                foreach (XmlNode n in baseNodeList)
                {
                    int iID = int.Parse(n.Attributes["id"].Value);
                    if (iID > -1 && iID < labelTextDefault.Length)
                        labels[iID] = n.Attributes["text"].Value;
                }
                bRet = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception in parseLabelText():" + ex.Message);
            }
            return bRet;
        }
        //colors
        public Color[] appColors;
        Color[] appColorDefaults = { Color.FromArgb(0x003149D6), Color.FromArgb(0x00FFFFFF), Color.FromArgb(0x003149D6), 
                                Color.FromArgb(0x00ff0000), Color.FromArgb(0x00CECBEF), Color.FromArgb(0x00FF0000)};
        string[] appColorNames = { "formback", "formtext", "pictback", 
                                     "buttonback", "buttontext", "texthighlight" };
        public enum APPCOLORS
        {
            formback, formtext, pictback,
            buttonback, buttontext, texthighlight
        };
        const int lastColorIndex = (int)APPCOLORS.texthighlight;
        void getColors()
        {
            //default text
            appColors = appColorDefaults;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();

                if (existAppFile("appcolors.xml"))
                {
                    xmlDoc.Load(_AppPath + "appcolors.xml");
                }
                else
                {
                    //string sString = "";
                    using (Stream stream = this.GetType().Assembly.GetManifestResourceStream("PriceMarkdown.colors.appcolors.xml"))
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            //sString = reader.ReadToEnd();
                            xmlDoc.Load(reader);
                        }
                    }
                }
                parseColors(xmlDoc);
            }
            catch (Exception) { }
        }
        bool parseColors(XmlDocument docXML)
        {
            bool bRet = false;
            string sNode = "";
            int iElement = -1;
            string sColorHex = "";
            int iColor = 0;
            try
            {
                XmlNodeList baseNodeList = docXML.SelectNodes("colors/*");
                foreach (XmlNode n in baseNodeList)
                {
                    sNode = n.Name;
                    iElement = (int)Enum.Parse(typeof(APPCOLORS), sNode, true);
                    sColorHex = n.InnerText;
                    iColor = Int32.Parse(sColorHex, NumberStyles.HexNumber);
                    //0x003149d6
                    appColors[iElement] = Color.FromArgb(iColor);
                    logInfo("Color '" + sNode + "', ix=" + iElement.ToString()+", col=0x"+iColor.ToString("x"));
                    //int iID = int.Parse(n.Attributes["id"].Value);
                    //if (iID > -1 && iID < labelTextDefault.Length)
                    //    labels[iID] = n.Attributes["text"].Value;
                }
                bRet = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception in parseLabelText():" + ex.Message);
            }
            return bRet;
        }
        public void colorizeForm(System.Windows.Forms.Form frm)
        {
            foreach (Control ctrl in frm.Controls)
            {
                if (ctrl.GetType() == typeof(Button))
                {
                    ctrl.BackColor = this.appColors[(int)APPCOLORS.buttonback];
                    ctrl.ForeColor = this.appColors[(int)APPCOLORS.buttontext];
                }
                else if (ctrl.GetType() == typeof(PictureBox))
                {
                    ctrl.BackColor = this.appColors[(int)APPCOLORS.pictback];
                }
                else if (ctrl.GetType() == typeof(Intermec.Windows.Forms.FormattedNumericValue))
                {
                    ((Intermec.Windows.Forms.FormattedNumericValue)ctrl).OverwriteBackColor= this.appColors[(int)APPCOLORS.texthighlight];
                }
                else
                {   
                    //labels, listbox etc.....
                    ctrl.BackColor = this.appColors[(int)APPCOLORS.formback];
                    ctrl.ForeColor = this.appColors[(int)APPCOLORS.formtext];
                }
            }
            frm.BackColor = this.appColors[(int)PriceMarkdown.ResClass2.APPCOLORS.formback];
        }
#endregion
        public static void logError(string s)
        {
            System.Diagnostics.Debug.WriteLine("Error: " + s);
        }
        public static void logInfo(string s)
        {
            System.Diagnostics.Debug.WriteLine("Info:  " + s);
        }

    }
}
