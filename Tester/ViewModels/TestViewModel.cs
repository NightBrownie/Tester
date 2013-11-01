using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tester.Data;

namespace Tester
{
    public class TestViewModel : Conductor<QuestionViewModel>
    {
        public Test Test { get; set; }

        public TestViewModel(Test test)
        {
            Test = test;
            ActivateQuestion(0);
        }

        public void NextQuestion()
        {
            var index = Test.Questions.IndexOf(ActiveItem.Question);
            index++;
            if (index >= Test.Questions.Count)
                ; // Dunno
            else
                ActivateQuestion(index);
        }

        public void ActivateQuestion(int index)
        {
            ActivateItem(new QuestionViewModel(Test.Questions[index]));
        }
    }
}
