using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Caliburn.Micro;
using Tester.Data;
using Tester.Views;

namespace Tester.ViewModels
{
    public class PracticeCrosswordViewModel : Screen
    {
        private Crossword crossword;

        public PracticeCrosswordViewModel(Crossword crossword)
        {
            this.crossword = crossword;
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            (GetView() as PracticeCrosswordView).Populate(crossword);
        }
    }
}
