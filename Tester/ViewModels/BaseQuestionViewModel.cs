using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using Tester.Annotations;
using Tester.Data;

namespace Tester.ViewModels
{
    public abstract class BaseQuestionViewModel : Screen
    {
        //TODO: Implement properties, look at this http://www.galasoft.ch/mydotnet/articles/article-2007041201.aspx
        public class QuestionTuple : DependencyObject
        {
            private string _answerText;
            private int _questionIndex;
            private bool _isChecked;

            public string AnswerText
            {
                get { return _answerText; }
                set
                {
                    _answerText = value;
                    OnPropertyChanged();
                }
            }

            public int QuestionIndex
            {
                get { return _questionIndex; }
                set
                {
                    _questionIndex = value;
                    OnPropertyChanged();
                }
            }

            public bool IsChecked
            {
                get { return _isChecked; }
                set
                {
                    _isChecked = value;
                    OnPropertyChanged();
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected Random rand = new Random((int)DateTime.Now.Ticks);

        public Question Question { get; set; }

        //contains pairs <answer text, index in question>
        public ObservableCollection<QuestionTuple> AnswersList { get; set; } 

        protected BaseQuestionViewModel(Question question)
        {
            Question = question;

            AnswersList = new ObservableCollection<QuestionTuple>();

            while (AnswersList.Count != Question.AnswersList.Count)
            {
                var newAnswerIndex = rand.Next(Question.AnswersList.Count);
                while (AnswersList.Select(tuple => tuple.QuestionIndex).Contains(newAnswerIndex))
                    newAnswerIndex = rand.Next(Question.AnswersList.Count);

                AnswersList.Add(new QuestionTuple() {
                    AnswerText = Question.AnswersList[newAnswerIndex].Item1,
                    QuestionIndex = newAnswerIndex,
                    IsChecked = false});
            }
        }

        public bool Check()
        {
            return false;
        }
    }
}
