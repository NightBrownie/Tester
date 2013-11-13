using System.Windows;
using System.Windows.Controls;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tester.Data;
using Tester.ViewModels;

namespace Tester
{
    public class RootViewModel : Conductor<object>
    {
        public List<Section> Sections { get; set; }

        public RootViewModel()
        {
            DisplayName = "Обучающая программа по дисциплине " + App.Instance.Content.CourseName;
            Sections = new List<Section>();
            LoadModel();
            ActivateItem(new SectionViewModel(Sections.First()));
        }

        public void SelectSection(ListBox source)
        {
            ActivateItem(new SectionViewModel(Sections[source.SelectedIndex]));
        }

        private void LoadModel()
        {
            Sections = App.Instance.Content.Sections;
        }
    }
}
