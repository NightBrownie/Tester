using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Tester.Data;

namespace Tester
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static App Instance { get; set; }
        public AppContent Content { get; set; }

        public App()
        {
            Instance = this;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                Content = AppContent.Load();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Не удалось загрузить данные: " + exc);
                Environment.Exit(0);
            }
            base.OnStartup(e);
        }
    }
}
