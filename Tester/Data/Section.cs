using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester.Data
{
    public class Section
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string TheoryText { get; set; }
        public Test Test { get; set; }
    }
}
