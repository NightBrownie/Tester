using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Tester.Data;

namespace Tester.ViewModels
{
    public class MultiChoiseQuestionViewModel : BaseQuestionViewModel
    {
        public MultiChoiseQuestionViewModel(Question question) : base(question)
        {
        }
    }
}
