using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Tester.Data;
using Tester.Views;

namespace Tester.ViewModels
{
    public class SectionViewModel : Conductor<object>
    {
        public Section Section { get; set; }

        public SectionViewModel(Section section)
        {
            Section = section;
        }

        public void ShowTheoryButton()
        {
            //TODO: implements theory viewmodel in near future
        }

        public void ShowTestButton()
        {
            ActivateItem(new TestViewModel(Section.Test));
        }

        public void ShowPractiseButton()
        {
        }
    }
}
