using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Tester.Data;

namespace Tester.ViewModels
{
    public abstract class BaseQuestionViewModel : Screen
    {
        public Question Question { get; set; }

        protected BaseQuestionViewModel(Question question)
        {
            Question = question;
        }

        public bool Check()
        {
            return false;
        }
    }
}
