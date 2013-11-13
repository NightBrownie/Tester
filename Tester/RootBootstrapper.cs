using System;
using Caliburn.Micro;

namespace Tester
{
    public class RootBootstrapper : Bootstrapper<RootViewModel>
    {
        protected override object GetInstance(Type service, string key)
        {
            if (service == typeof(IWindowManager))
                return new AppWindowManager();
            return base.GetInstance(service, key);
        }
    }
}