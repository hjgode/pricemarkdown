using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Xml;

namespace PriceMarkdown
{
    /// <summary>
    /// class to retrieve global and lang specific resources
    /// </summary>
    class ResClass2
    {
        //singleton pattern
        static ResClass2 _instance;

        public static ResClass2 getInstance()
        {
            if (_instance == null)
                _instance = new ResClass2();
            return _instance;
        }
        ResClass2()
        {
            //read all variable resources
            buttonText = ButtonTextDefault;
            labels = labelTextDefault;
            reducedText = reducedTextDefault;
            sCurrency = sCurrencyDefaults;

            //read colors
            readColorsXML();

            //frmLanguage:  three buttons with text defined in buttontexts.xml/language.xml
            //frmPrint:     two input field labels and one button 
            //printed label: currency symbol plus 'reduziert' var
            readLanguageXML();
        }

        void readLanguageXML()
        {
            //test if to use embedded or external file?
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                bool xmlLoaded = false;
                if (existAppFile("language.xml"))
                {
                    try
                    {
                        xmlDoc.Load(Helpers.AppPath() + "language.xml");
                        Helpers.logInfo("Using external res file: 'language.xml'");
                        xmlLoaded = true;
                    }
                    catch (XmlException ex)
                    {
                        Helpers.logError("Exception reading language.xml " + ex.Message + " Using default!");
                    }
                    catch (Exception ex)
                    {
                        Helpers.logError("Exception reading language.xml " + ex.Message + " Using default!");
                    }
                }
                if(!xmlLoaded)
                {
                    //read embedded resource
                    using (Stream stream = this.GetType().Assembly.GetManifestResourceStream(Helpers.AssemblyName() + ".textxml.language.xml"))
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            xmlDoc.Load(reader);
                            Helpers.logInfo("Using embedded res file: 'language.xml'");
                        }
                    }
                }
                //read buttons
                XmlNodeList baseNodeList = xmlDoc.SelectNodes("text/buttons/button");
                try
                {
                    foreach (XmlNode n in baseNodeList)
                    {
                        int iID = int.Parse(n.Attributes["id"].Value);
                        if (iID > -1 && iID < ButtonTextDefault.Length)
                            buttonText[iID] = n.Attributes["text"].Value;
                    }
                }
                catch (XmlException ex)
                {
                    Helpers.logError("Exception reading language() for buttons" + ex.Message + " Using default!");
                    buttonText = ButtonTextDefault;
                }
                catch (Exception ex)
                {
                    Helpers.logError("Exception reading language() for buttons" + ex.Message + " Using default!");
                    buttonText = ButtonTextDefault;
                }
                //read frmPrint var text
                try{
                    for (int iLang=0; iLang < 3; iLang++)
                    {
                        baseNodeList = xmlDoc.SelectNodes("text/labels/labels" + iLang.ToString() + "/label");
                        foreach (XmlNode n in baseNodeList)
                        {
                            int iID = int.Parse(n.Attributes["id"].Value);
                            if (iID > -1 && iID < labelTextDefault.Length)
                                labels[iLang][iID] = n.Attributes["text"].Value;
                        }
                    }
                }
                catch (XmlException ex)
                {
                    Helpers.logError("Exception reading language() for labels" + ex.Message + " Using default!");
                    labels = labelTextDefault;
                }
                catch (Exception ex)
                {
                    Helpers.logError("Exception reading language() for labels" + ex.Message + " Using default!");
                    labels = labelTextDefault;
                }
                //read 'reduziert'
                baseNodeList = xmlDoc.SelectNodes("text/vars/var");
                try{
                    foreach (XmlNode n in baseNodeList)
                    {
                        for (int iLang = 0; iLang < 3; iLang++)
                        {
                            if (n.Attributes["id"].Value == iLang.ToString())
                                reducedText[iLang] = n.Attributes["text"].Value;
                        }
                    }
                }
                catch (XmlException ex)
                {
                    Helpers.logError("Exception reading language() for vars" + ex.Message + " Using default!");
                    reducedText = reducedTextDefault;
                }
                catch (Exception ex)
                {
                    Helpers.logError("Exception reading language() for vars" + ex.Message + " Using default!");
                    reducedText = reducedTextDefault;
                }

                //read currency
                baseNodeList = xmlDoc.SelectNodes("text/currencies/currency");
                try
                {
                    foreach (XmlNode n in baseNodeList)
                    {
                        for (int iLang = 0; iLang < 3; iLang++)
                        {
                            if (n.Attributes["id"].Value == iLang.ToString())
                                sCurrency[iLang] = n.Attributes["text"].Value;
                        }
                    }
                }
                catch (XmlException ex)
                {
                    Helpers.logError("Exception reading language() for currencies" + ex.Message + " Using default!");
                    sCurrency = sCurrencyDefaults;
                }
                catch (Exception ex)
                {
                    Helpers.logError("Exception reading language() for currencies" + ex.Message + " Using default!");
                    sCurrency = sCurrencyDefaults;
                }
            }
            catch (XmlException ex)
            {
                Helpers.logError("Exception in readLanguageXML(): " + ex.Message);
            }
            catch (Exception ex) {
                Helpers.logError("Exception in readLanguageXML(): " + ex.Message);
            }
        }
        #region constants
        const string assemblyName = "PriceMarkdown";
        #endregion
        #region fields
        //######################
        #region colors
        //colors
        public static Color[] appColors = appColorDefaults;
        
        static Color[] appColorDefaults = { Color.FromArgb(0x003149D6), Color.FromArgb(0x00FFFFFF), Color.FromArgb(0x003149D6), 
                                Color.FromArgb(0x00ff0000), Color.FromArgb(0x00CECBEF), Color.FromArgb(0x00FF0000)};
        string[] appColorNames = { "formback", "formtext", "pictback", 
                                     "buttonback", "buttontext", "texthighlight" };
        public enum APPCOLORS
        {
            formback, formtext, pictback,
            buttonback, buttontext, texthighlight
        };
        const int lastColorIndex = (int)APPCOLORS.texthighlight;
        void readColorsXML()
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();

                if (existAppFile("appcolors.xml"))
                {
                    xmlDoc.Load(Helpers.AppPath() + "appcolors.xml");
                    Helpers.logInfo("Using external res file: 'appcolors.xml'");
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
                            Helpers.logInfo("Using embedded res file: 'appcolors.xml'");
                        }
                    }
                }
                parseColors(xmlDoc);
            }
            catch (Exception ex) {
                Helpers.logError("Exception in readColorsXML(): " + ex.Message);
            }
        }
        bool parseColors(XmlDocument docXML)
        {
            bool bRet = false;
            string sNode = "";
            int iElement = -1;
            string sColorHex = "";
            int iColor = 0;
            appColors = appColorDefaults;
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
                    Helpers.logInfo("Color '" + sNode + "', ix=" + iElement.ToString() + ", col=0x" + iColor.ToString("x"));
                }
                bRet = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception in parseColors():" + ex.Message);
                Helpers.logError("Exception in parseColors():" + ex.Message);
            }
            return bRet;
        }
        public void colorizeForm(System.Windows.Forms.Form frm)
        {
            foreach (Control ctrl in frm.Controls)
            {
                if (ctrl.GetType() == typeof(Button))
                {
                    ctrl.BackColor = appColors[(int)APPCOLORS.buttonback];
                    ctrl.ForeColor = appColors[(int)APPCOLORS.buttontext];
                }
                else if (ctrl.GetType() == typeof(PictureBox))
                {
                    ctrl.BackColor = appColors[(int)APPCOLORS.pictback];
                }
                else if (ctrl.GetType() == typeof(Intermec.Windows.Forms.FormattedNumericValue))
                {
                    ((Intermec.Windows.Forms.FormattedNumericValue)ctrl).OverwriteBackColor = appColors[(int)APPCOLORS.texthighlight];
                }
                else
                {
                    //labels, listbox etc.....
                    ctrl.BackColor = appColors[(int)APPCOLORS.formback];
                    ctrl.ForeColor = appColors[(int)APPCOLORS.formtext];
                }
            }
            frm.BackColor = appColors[(int)APPCOLORS.formback];
        }

        #endregion
        //######################
        #region text
        public static string[] sCurrency = sCurrencyDefaults;
        static string[] sCurrencyDefaults = { "€", "$", "€" };
        string _sCurrency = "€";

        /// <summary>
        /// holds language strings for printFrm
        /// </summary>
        public string _labelsText(frmPrintText frmObject, int iLang)
        {
            return labels[iLang][(int)frmObject]; 
        }
        public enum frmPrintText
        {
            oldPrice,
            newPrice,
            printButton
        }
        /// <summary>
        /// holds text of frmPrint
        /// first index is for langugae
        /// second index for object
        /// </summary>
        static string[][] labels = labelTextDefault;
        static string[][] labelTextDefault = {
               new String[]{ "Alter Preis", "Neuer Preis", "Drucken" },
               new String[]{ "Old Price", "New Price", "Print" },
               new String[]{ "Precio antiguo", "Precio nuevo", "Imprimir" },
                                             };


        //button text
        static string[] buttonText = ButtonTextDefault;
        public string[] _buttonTexts
        {
            get { return buttonText; }
        }
        static string[] ButtonTextDefault = { "deutsch", "english", "espanol" };
        
        #endregion
        //######################
        #region reducedText
        static string[] reducedText = reducedTextDefault;
        static string[] reducedTextDefault = { "reduziert", "reduced", "muy reducido" };
        /// <summary>
        /// get language text for "reduced"
        /// </summary>
        /// <param name="iLang">language index</param>
        /// <returns></returns>
        public string _reducedText(int iLang)
        {
            return reducedText[iLang];
        }
        #endregion
        #region ####image#####
        public System.Drawing.Image getImage()
        {
            System.Drawing.Image _Image = null;
            if (existAppFile("startlogo.gif"))
            {
                _Image = new Bitmap(Helpers.AppPath() + "startlogo.gif");
            }
            else
            {
                _Image = new Bitmap(this.GetType().Assembly.GetManifestResourceStream(Helpers.AssemblyName() + ".Images.startlogo.gif"));
            }
            return _Image;
        }
        #endregion
        #endregion
        #region ###### helper ##########

        private static bool existAppFile(string sFile)
        {
            return System.IO.File.Exists(Helpers.AppPath() + sFile);
        }
        #endregion
        #region ######## print stuff ##########
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
                System.IO.TextReader tr = new System.IO.StreamReader(Helpers.AppPath() + "layout-prn.txt");
                sLayout = tr.ReadToEnd();
                tr.Close();
                Helpers.logInfo("using external resource 'layout-prn.txt'");
            }
            else
            {
                try
                {
                    using (Stream stream = this.GetType().Assembly.GetManifestResourceStream(Helpers.AssemblyName() + ".printfiles.layout-prn.txt"))
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            sLayout = reader.ReadToEnd();
                            Helpers.logInfo("using embedded resource 'layout-prn.txt'");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Helpers.logError("Exception in getLayoutPRN()" + ex.Message);
                }
            }
            return sLayout;
        }
        public string getPriceMark(string sOldPrice, string sNewPrice, int iLang)
        {
            StringBuilder sb = new StringBuilder();
            string sReducedText = this._reducedText(iLang);
            sb.Append("LAYOUT RUN \"c:PRICE_MARKDOWN.LAY\"");
            sb.Append("\r\n");
            sb.Append("INPUT ON");
            sb.Append("\r\n");
            //sb.Append("...stark reduziert");
            sb.Append("" + sReducedText);  //starts with 0x02
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
        #endregion
    }
}
