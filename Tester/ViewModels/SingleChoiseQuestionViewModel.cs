using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Tester.Data;

namespace Tester.ViewModels
{
    public class SingleChoiseQuestionViewModel : BaseQuestionViewModel
    {
        public SingleChoiseQuestionViewModel(Question question) : base(question)
        {
        }
    }
}
