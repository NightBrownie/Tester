﻿using System;
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
    class PracticeTextViewModel : Screen
    {
        private Section Section { get; set; }

        public PracticeTextViewModel(Section section)
        {
            Section = section;
        }

        protected override void OnViewLoaded(object view)
        {
            (view as PracticeTextView).Browser.Navigate("file:///"
                + MhtHelper.GetMhtFilePath(Section.PracticeCrossword.Words.First().Value));
        }
    }
}
