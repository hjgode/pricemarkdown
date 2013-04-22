using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PriceMarkdown
{
    class Helpers
    {
        static void logToFile(string s){
            string AppPath_ = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            if (!AppPath_.EndsWith(@"\"))
                AppPath_ += @"\";
            string AssemblyName_ = System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            string sLogFile = AppPath_ + AssemblyName_ + ".log";
            try
            {
                if (System.IO.File.Exists(sLogFile))
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(sLogFile);
                    if (fi.Length > 1000000)
                    {
                        if (System.IO.File.Exists(sLogFile + ".bak"))
                            System.IO.File.Delete(sLogFile + ".bak");
                        System.IO.File.Move(sLogFile, sLogFile + ".bak");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception in logToFile(): " + ex.Message);
            }
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sLogFile, true))
            {
                sw.WriteLine(s);
            }
        }
        public static void logError(string s)
        {
            System.Diagnostics.Debug.WriteLine("Error: " + s);
            logToFile(s);
        }
        public static void logInfo(string s)
        {
            System.Diagnostics.Debug.WriteLine("Info:  " + s);
            logToFile(s);
        }
        static bool logOnceApp = false;
        static bool logOnceAssembly = false;
        static string _AppPath=null;
        public static string AppPath()
        {
            if (_AppPath == null)
            {
                _AppPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                if (!_AppPath.EndsWith(@"\"))
                    _AppPath += @"\";
            }
            if (!logOnceApp)
            {
                Helpers.logInfo("_AppPath='" + _AppPath + "'");
                logOnceApp = true;
            }
            return _AppPath;
        }
        static string _AssemblyName=null;
        public static string AssemblyName()
        {
            if (_AssemblyName == null)
            {
                _AssemblyName = System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            }
            if (!logOnceAssembly)
            {
                Helpers.logInfo("_AssemblyName='" + _AssemblyName + "'");
                logOnceAssembly = true;
            }
            return _AssemblyName;
        }
    }
}
