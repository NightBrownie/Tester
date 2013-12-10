using System.Reflection;
using System.Windows.Media.Animation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

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
                .GetManifestResourceStream(MhtHelper.ResourcePath + "appdata.json"));

            return JsonConvert.DeserializeObject<AppContent>(tr.ReadToEnd());
        }
    }
}
