


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clipboard_PROX.Utilities
{
    public static class Folder
    {
        public static string path = Directory.GetCurrentDirectory() + "\\credentials\\";
        public static string foldername = "" ;

        public static bool CreateFolder()
        {
            try
            {

                if (!Directory.Exists(path + foldername))
                {
                    Directory.CreateDirectory(path + foldername);
                    return true;
                }


            }
            catch
            {


            }
            return false;


        }

        public static String GetTodayFolderName()
        {

            return (path + foldername);

        }
        public static String GetPathDownload()
        {

            return (path);

        }
        public static String GetPathFolderDataResult()
        {
            string w = Directory.GetCurrentDirectory() + "/DataResult/";

            if (!Directory.Exists(w))
            {
                Directory.CreateDirectory(w);

            }

            return w;

        }
    }
}