using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tester.Data
{
    [DataContract]
    public class Crossword
    {
        [DataMember]
        public List<Word> Words { get; set; }

        public Crossword()
        {
            Words = new List<Word>();
        }

        [DataContract]
        public class Word
        {
            [DataMember]
            public int X { get; set; }

            [DataMember]
            public int Y { get; set; }

            [DataMember]
            public string Value { get; set; }

            [DataMember]
            public string Hint{ get; set; }

            [DataMember]
            public bool Vertical { get; set; }
        }
    }
}
