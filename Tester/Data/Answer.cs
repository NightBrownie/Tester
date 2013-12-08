using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


namespace Tester.Data
{
    [DataContract]
    public class Answer 
    {
        [DataMember]
        public string Text { get; set; }

        [DataMember]
        public bool Correct { get; set; }
    }
}
