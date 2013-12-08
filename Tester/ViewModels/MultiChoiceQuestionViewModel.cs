using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Caliburn.Micro;
using Tester.Data;

namespace Tester.ViewModels
{
    public class MultiChoiceQuestionViewModel : BaseQuestionViewModel
    {
        public MultiChoiceQuestionViewModel(Question question) : base(question)
        {
        }
    }
}
