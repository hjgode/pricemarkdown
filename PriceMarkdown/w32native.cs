using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PriceMarkdown
{
    class w32native
    {
        const int GWL_EXSTYLE = (-20);
        const int GWL_STYLE = (-16);
        const int WS_EX_LAYOUTRTL = 0x400000;
        const int ES_LEFT = 0x00;
        const int ES_RIGHT = 0x0002;

        public static void SetControlDirection(Control c, bool p_isRTL)
        {
            int style = GetWindowLong(c.Handle, GWL_EXSTYLE);
            style = GetWindowLong(c.Handle, GWL_STYLE);

            // set default to ltr (clear rtl bit)
            //style &= ~WS_EX_LAYOUTRTL;
            style &= ~ES_LEFT;

            if (p_isRTL == true)
            {
                // rtl
                //style = WS_EX_LAYOUTRTL;
                style = ES_RIGHT;
            }

            //SetWindowLong(c.Handle, GWL_EXSTYLE, style);
            SetWindowLong(c.Handle, GWL_STYLE, style);
            c.Invalidate();
        }


        [DllImport("coredll.dll")]
        static extern int GetWindowLong(IntPtr hWnd, int cmd);

        [DllImport("coredll.dll")]
        static extern IntPtr SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        /// <summary>
        /// return the max font size fitting in iWidth
        /// </summary>
        /// <param name="g"></param>
        /// <param name="font">font to use for measuring</param>
        /// <param name="iCellWidth">width of the cell to fit</param>
        /// <param name="iNumChars">how many chars to measure, have to fit</param>
        /// <returns></returns>
		public static int getMaxFontSize(Graphics g, Font font, int iCellWidth, int iNumChars){
			int iRet = 10;
			Font testFont; // = font.Clone();

            //start with a large font size
            int iFSize = 72; // (int)font.Size;
			testFont = new Font( font.Name, iFSize, FontStyle.Regular);
			String sChars="";
			for(int x=0; x<iNumChars; x++){
				sChars+="0";
			}

			while(Math.Max( g.MeasureString(sChars, testFont).Width, 
			               g.MeasureString(sChars, testFont).Height)>iCellWidth){
				iFSize--;
				testFont = new Font( font.Name, iFSize, FontStyle.Regular);
			}
			//SizeF sizeF = g.MeasureString("00", font);
			iRet = iFSize;
			System.Diagnostics.Debug.WriteLine("Cell max="+iRet.ToString());
			return iRet;
		}
	}
}
