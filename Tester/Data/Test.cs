using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Tester.Data
{
    [DataContract]
    public class Test
    {
        [DataMember]
        public string Name { get; set; }
        
        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public List<Question> Questions { get; set; }

        public Test()
        {
            Questions = new List<Question>();
        }
    }
}
