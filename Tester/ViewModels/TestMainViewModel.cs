using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using Tester.Data;

namespace Tester.ViewModels
{
    class TestMainViewModel: Screen
    {
        public Test Test { get; set; }

        public Visibility MaxFailQuestionCountVisibility
        {
            get
            {
                return Test.MaxSkippedQuestions != 0
                    ? Visibility.Visible
                    : Visibility.Collapsed;
            }
        }

        public TestMainViewModel(Test test)
        {
            Test = test;
        }
    }
}
