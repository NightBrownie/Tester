using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tester
{
    public static class MhtHelper
    {
        private static string applicationFolderName = @"Tester_BSUIR\";

        public static string GetMhtFilePath(string wantedFileName)
        {
            var tempFolderName = Path.GetTempPath();
            if (!Directory.Exists(tempFolderName + applicationFolderName))
                Directory.CreateDirectory(tempFolderName + applicationFolderName);

            var filePath = tempFolderName + applicationFolderName + wantedFileName;

            if (!File.Exists(filePath))
            {
                try
                {
                    TextReader tr = new StreamReader(Assembly.GetExecutingAssembly()
                        .GetManifestResourceStream(ConfigurationSettings.AppSettings.Get("ResourcesPath") +
                                                   wantedFileName));

                    File.WriteAllText(filePath, tr.ReadToEnd());
                }
                catch (Exception ex) { }
            }

            return filePath;
        }
    }
}
