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
                checkContent();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Не удалось загрузить данные: " + exc);
                Environment.Exit(0);
            }
            base.OnStartup(e);
        }

        private void checkContent()
        {
            foreach (var section in Content.Sections)
            {
                foreach (var question in section.Test.Questions)
                {
                    if (question.Type == QuestionType.SingleChoice)
                        if (question.Answers.Where(a => a.Correct).Count() > 1)
                            if (MessageBox.Show("Error in test sources.", "Error in sources.", MessageBoxButton.OK,
                                MessageBoxImage.Error) == MessageBoxResult.OK)
                                Current.Shutdown(1);
                    else
                        if (question.Answers.Where(a => a.Correct).Count() == 0)
                            if (MessageBox.Show("Error in test sources.", "Error in sources.", MessageBoxButton.OK,
                                MessageBoxImage.Error) == MessageBoxResult.OK)
                                Current.Shutdown();
                }
            }
        }
    }
}
