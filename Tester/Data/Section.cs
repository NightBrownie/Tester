using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


namespace Tester.Data
{
    [DataContract]
    public class Section
    {
        [DataMember]
        public string Name { get; set; }
        
        [DataMember]
        public string Description { get; set; }
        
        [DataMember]
        public string TheoryPath { get; set; }

        [DataMember]
        public string PracticePath { get; set; }
        
        [DataMember]
        public Test Test { get; set; }

        [DataMember]
        public Crossword PracticeCrossword { get; set; }
    }
}
