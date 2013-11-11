using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Tester.Data;

namespace Tester.ViewModels
{
    public class SingleChoiseQuestionViewModel : BaseQuestionViewModel
    {
        private int selectedIndex { get; set; }

        public SingleChoiseQuestionViewModel(Question question) : base(question)
        {
            AnswersList.First().IsChecked = true;
        }
    }
}
