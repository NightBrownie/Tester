using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Caliburn.Micro;
using Tester.Data;

namespace Tester.ViewModels
{
    public class TestFinishViewModel : Screen
    {
        public List<Tuple<string, List<string>>> ResultAnswers { get; set; }
        public bool TestFailShowingEnabled { get; set; }
        public int QuestionCount { get; set; }
        public Brush ResultColorBrush {
            get
                {
                    //if test fail showing enabled then we will check for question count, else we will always show result in green
                    return (!TestFailShowingEnabled || QuestionCount == ResultAnswers.Count) ? Brushes.Green : Brushes.Red;
                }
        }

        public string TestResultMessage
        {
            get
            {
                return (!TestFailShowingEnabled || QuestionCount == ResultAnswers.Count)
                    ? "Тест пройден"
                    : "Тест не пройден";
            } 
        }

        public TestFinishViewModel(int questionCount, bool testFailShowingEnabled = false)
        {
            QuestionCount = questionCount;
            ResultAnswers = new List<Tuple<string, List<string>>>();
            TestFailShowingEnabled = testFailShowingEnabled;
        }
    }
}
