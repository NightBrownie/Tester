using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester.Data
{
    public class Test
    {
        public string Name { get; set; }
        public List<Question> Questions { get; set; }

        public Test()
        {
            Questions = new List<Question>();
        }
    }
}
