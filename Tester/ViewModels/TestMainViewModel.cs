using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Tester.Data;

namespace Tester.ViewModels
{
    class TestMainViewModel: Screen
    {
        public Test Test { get; set; }

        public TestMainViewModel(Test test)
        {
            Test = test;
        }
    }
}
