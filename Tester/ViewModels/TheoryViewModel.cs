using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;

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
            (view as TheoryView).Browser.Navigate(new Uri("file:///" + MhtHelper.GetMhtFilePath(Section.TheoryPath)));
        }
    }
}
