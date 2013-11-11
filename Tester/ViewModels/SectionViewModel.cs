using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
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
        private Brush _currentBorderBrush;
        private Brush _theorySectionBrush;
        private Brush _testSectionBrush;
        private Brush _practiceSectionBrush;

        public Brush TheorySectionBrush
        {
            get { return _theorySectionBrush; }
            set
            {
                _theorySectionBrush = value;
                OnPropertyChanged(new PropertyChangedEventArgs("TheorySectionBrush"));
            }
        }

        public Brush TestSectionBrush
        {
            get { return _testSectionBrush; }
            set
            {
                _testSectionBrush = value;
                OnPropertyChanged(new PropertyChangedEventArgs("TestSectionBrush"));
            }
        }

        public Brush PracticeSectionBrush
        {
            get { return _practiceSectionBrush; }
            set
            {
                _practiceSectionBrush = value;
                OnPropertyChanged(new PropertyChangedEventArgs("PracticeSectionBrush"));
            }
        }

        public Section Section { get; set; }

        public Brush CurrentBorderBrush
        {
            get { return _currentBorderBrush; }
            set
            {
                _currentBorderBrush = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CurrentBorderBrush"));
            }
        }

        public SectionViewModel(Section section)
        {
            TheorySectionBrush = new SolidColorBrush(Colors.GreenYellow);
            TestSectionBrush = new SolidColorBrush(Colors.OrangeRed);
            PracticeSectionBrush = new SolidColorBrush(Colors.LightSkyBlue);

            Section = section;
            ShowTheoryButton();
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

        public void ShowPracticeButton()
        {
            CurrentBorderBrush = PracticeSectionBrush;
        }
    }
}
