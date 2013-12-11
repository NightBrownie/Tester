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
        private static string tempPath
        {
            get { return Path.Combine(Path.GetTempPath(), "Tester_BSUIR"); }
        }
        private static string resourcesPath = @"Tester.Resources.";

        public static string ResourcePath
        {
            get { return resourcesPath; }
        }

        public static string GetMhtFilePath(string wantedFileName)
        {
            if (!Directory.Exists(tempPath))
                Directory.CreateDirectory(tempPath);

            var filePath = Path.Combine(tempPath, wantedFileName);

            if (!File.Exists(filePath))
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

        public static void Cleanup()
        {
            if (Directory.Exists(tempPath))
                Directory.Delete(tempPath, true);
        }
    }
}
