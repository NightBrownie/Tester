using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows;
using Caliburn.Micro;

namespace Tester
{
    [Export(typeof(IWindowManager))]
    class AppWindowManager : WindowManager
    {
        protected override Window EnsureWindow(object model, object view, bool isDialog)
        {
            if (view as Window == null)
            {
                var w = new MainWindowContainer { Content = view };
                w.SetValue(View.IsGeneratedProperty, true);
                view = w;
            }
            return view as Window;
        }
    }
}
