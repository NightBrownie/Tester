using System.Reflection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Tester.Data
{
    [DataContract]
    public class AppContent
    {
        [DataMember]
        public string CourseName { get; set; }

        [DataMember]
        public List<Section> Sections;

        public static AppContent Load()
        {
            TextReader tr = new StreamReader(Assembly.GetExecutingAssembly()
                .GetManifestResourceStream(ConfigurationSettings.AppSettings.Get("ResourcesPath") + "appdata.json"));

            return JsonConvert.DeserializeObject<AppContent>(tr.ReadToEnd());
        }
    }
}
