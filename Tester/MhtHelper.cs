using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;


namespace Tester
{
    public static class MhtHelper
    {
        private static string applicationFolderName = @"Tester_BSUIR\";
        private static string resourcesPath = @"Tester.Resources.";

        public static string ResourcePath
        {
            get { return resourcesPath; }
        }

        public static string ApplicationFolderName
        {
            get { return applicationFolderName; }
        }

        public static string GetMhtFilePath(string wantedFileName)
        {
            var tempFolderName = Path.GetTempPath();
            if (!Directory.Exists(tempFolderName + applicationFolderName))
                Directory.CreateDirectory(tempFolderName + applicationFolderName);

            var filePath = tempFolderName + applicationFolderName + wantedFileName;

            //if (!File.Exists(filePath))
            {
                try
                {
                    TextReader tr = new StreamReader(
                        Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcesPath + wantedFileName));

                    File.WriteAllText(filePath, tr.ReadToEnd());
                }
                catch (Exception ex)
                {
                }
            }

            return filePath;
        }
    }
}
