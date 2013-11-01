using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tester.Data;

namespace Tester
{
    public class RootViewModel : Conductor<object>
    {
        public RootViewModel()
        {
            var t = new Test
            {
                Name = "test test",
                Questions = {
                    new Question{Text="Q1"},
                    new Question{Text="Q2"},
                    new Question{Text="Q3"},
                }
            };
            ActivateItem(new TestViewModel(t));
        }
    }
}
