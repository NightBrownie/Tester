using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Caliburn.Micro;
using Tester.Data;
using Tester.Views;

namespace Tester.ViewModels
{
    public class SectionViewModel : Conductor<object>
    {
        private Brush TheorySectionBrush = new SolidColorBrush(Color.FromArgb(255, 173, 255, 107));
        private Brush TestSectionBrush = new SolidColorBrush(Color.FromArgb(255, 219, 112, 147));
        private Brush PracticeSectionBrush = new SolidColorBrush(Color.FromArgb(255, 30, 144, 47));

        public Section Section { get; set; }
        public Brush CurrentBorderBrush { get; set; }

        public SectionViewModel(Section section)
        {
            Section = section;
            CurrentBorderBrush = TestSectionBrush;
        }

        public void ShowTheoryButton()
        {
            //TODO: implements theory viewmodel in near future
            CurrentBorderBrush = TheorySectionBrush;
        }

        public void ShowTestButton()
        {
            ActivateItem(new TestViewModel(Section.Test));
            CurrentBorderBrush = TestSectionBrush;
        }

        public void ShowPractiseButton()
        {
            CurrentBorderBrush = PracticeSectionBrush;
        }
    }
}
