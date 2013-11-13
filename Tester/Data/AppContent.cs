using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Tester.Data
{
    [DataContract]
    public class AppContent
    {
        [DataMember]
        public string CourseName { get; set; }

        [DataMember]
        public List<Section> Sections;

        public static AppContent Load(string path)
        {
            return JsonConvert.DeserializeObject<AppContent>(File.ReadAllText(path));
        }
    }
}
