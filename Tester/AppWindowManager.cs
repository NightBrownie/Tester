using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows;
using Caliburn.Micro;

namespace Tester
{
    [Export(typeof(IWindowManager))]
    class AppWindowManager: WindowManager
    {
    }
}
