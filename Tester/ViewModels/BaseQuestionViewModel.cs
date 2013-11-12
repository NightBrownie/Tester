using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Caliburn.Micro;
using Tester.Data;

namespace Tester.ViewModels
{
    public abstract class BaseQuestionViewModel : Screen
    {
        public class AnswerTuple : DependencyObject
        {
            public static readonly DependencyProperty IsCheckedProperty;

            public string AnswerText { get; set; }
            public int AnswerIndex { get; set; }

            public bool IsChecked
            {
                get { return (bool) GetValue(IsCheckedProperty); }
                set { SetValue(IsCheckedProperty, value); }
            }

            static AnswerTuple()
            {
                IsCheckedProperty = DependencyProperty.Register("IsChecked", typeof (bool), typeof (AnswerTuple));
            }
        }

        protected Random rand = new Random((int)DateTime.Now.Ticks);

        public Question Question { get; set; }

        //contains pairs <answer text, index in question>
        public ObservableCollection<AnswerTuple> AnswersList { get; set; } 

        protected BaseQuestionViewModel(Question question)
        {
            Question = question;

            AnswersList = new ObservableCollection<AnswerTuple>();

            while (AnswersList.Count != Question.AnswersList.Count)
            {
                var newAnswerIndex = rand.Next(Question.AnswersList.Count);
                while (AnswersList.Select(tuple => tuple.AnswerIndex).Contains(newAnswerIndex))
                    newAnswerIndex = rand.Next(Question.AnswersList.Count);

                AnswersList.Add(new AnswerTuple() {
                    AnswerText = Question.AnswersList[newAnswerIndex].Item1,
                    AnswerIndex = newAnswerIndex,
                    IsChecked = false});
            }
        }

        public bool Check()
        {
            bool result = true;

            foreach (var AnswerTuple in AnswersList)
            {
                result &= (AnswerTuple.IsChecked == Question.AnswersList[AnswerTuple.AnswerIndex].Item2);
                if (!result)
                    break;
            }

            return result;
        }
    }
}
