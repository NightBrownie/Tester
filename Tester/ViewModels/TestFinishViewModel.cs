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
        public int QuestionCount { get; set; }
        public Brush ResultColorBrush { get
        {
            return (QuestionCount == ResultAnswers.Count) ? Brushes.Green : Brushes.Red;
        } }

        public TestFinishViewModel(int questionCount)
        {
            QuestionCount = questionCount;
            ResultAnswers = new List<Tuple<string, List<string>>>();
        }
    }
}
