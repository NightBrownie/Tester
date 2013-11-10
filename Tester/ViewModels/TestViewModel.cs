using System.Windows;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tester.Data;
using Tester.ViewModels;

namespace Tester
{
    public class TestViewModel : Conductor<object>
    {
        public Visibility StartTestButtonVisibility { get; set; }
        public Visibility NextQuestionButtonVisibility { get; set; }
        public Visibility ToHomePageButtonVisibility { get; set; }
        public Test Test { get; set; }

        public TestViewModel(Test test)
        {
            Test = test;

            StartTestButtonVisibility = Visibility.Visible;
            NextQuestionButtonVisibility = Visibility.Collapsed;
            ToHomePageButtonVisibility = Visibility.Collapsed;

            ActivateItem(new TestMainViewModel(Test));
        }
    }
}
