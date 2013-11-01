using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tester.Data;

namespace Tester
{
    public class QuestionViewModel : Screen
    {
        public Question Question { get; set; }

        public QuestionViewModel(Question question)
        {
            Question = question;
        }
    }
}
