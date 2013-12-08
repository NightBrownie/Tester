using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;

using System.Windows;
using System.Windows.Annotations;
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
        private TestViewModel currentTestViewModel;

        public Brush TheorySectionBrush
        {
            get { return _theorySectionBrush; }
            set
            {
                _theorySectionBrush = value;
                NotifyOfPropertyChange(("TheorySectionBrush"));
            }
        }

        public Brush TestSectionBrush
        {
            get { return _testSectionBrush; }
            set
            {
                _testSectionBrush = value;
                NotifyOfPropertyChange(("TestSectionBrush"));
            }
        }

        public Brush PracticeSectionBrush
        {
            get { return _practiceSectionBrush; }
            set
            {
                _practiceSectionBrush = value;
                NotifyOfPropertyChange(("PracticeSectionBrush"));
            }
        }

        public Section Section { get; set; }

        public Brush CurrentBorderBrush
        {
            get { return _currentBorderBrush; }
            set
            {
                _currentBorderBrush = value;
                NotifyOfPropertyChange(("CurrentBorderBrush"));
            }
        }

        public SectionViewModel(Section section)
        {
            TheorySectionBrush = Brushes.GreenYellow;
            TestSectionBrush = Brushes.OrangeRed;
            PracticeSectionBrush = Brushes.LightSkyBlue;

            Section = section;
            ShowTheoryButton();
        }

        public void ShowTheoryButton()
        {
            if (tryExitFromTest())
            {
                ActivateItem(new TheoryViewModel(Section));
                CurrentBorderBrush = TheorySectionBrush;
            }
        }

        public void ShowTestButton()
        {
            if (tryExitFromTest())
            {
                currentTestViewModel = new TestViewModel(Section.Test);
                ActivateItem(currentTestViewModel);
                CurrentBorderBrush = TestSectionBrush;
            }
        }

        public void ShowPracticeButton()
        {
            if (tryExitFromTest())
            {
                if (Section.PracticeCrossword != null)
                {
                    if (Section.PracticeCrossword.Words.Count > 1)
                        ActivateItem(new PracticeCrosswordViewModel(Section.PracticeCrossword));
                    else
                        ActivateItem(new PracticeTextViewModel(Section)); 
                }
                CurrentBorderBrush = PracticeSectionBrush;
            }
        }

        private bool tryExitFromTest()
        {
            if (currentTestViewModel != null && currentTestViewModel.IsInProgress)
            {
                var result = MessageBox.Show("Желаете закончить тест и перейти к другому разделу?", "Оповещение",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;

                if (result)
                    currentTestViewModel = null;
                return result;
            }

            return true;
        }
    }
}
