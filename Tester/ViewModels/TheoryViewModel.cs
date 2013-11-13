using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Tester.Data;
using Tester.Views;
using System.IO;

namespace Tester.ViewModels
{
    public class TheoryViewModel : Screen
    {
        private Section Section { get; set; }

        public TheoryViewModel(Section section)
        {
            Section = section;
        }

        protected override void OnViewLoaded(object view)
        {
            (view as TheoryView).Browser.Navigate("file:///" + Path.Combine(Environment.CurrentDirectory, "Content", Section.TheoryPath));
        }
    }
}
