using LoginPage.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LoginPage
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MainWindow ParentWindowRef;
        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            var LoginView = new LoginView();
            LoginView.Show();
            LoginView.IsVisibleChanged += (s, ev) =>
            {
                if (LoginView.IsVisible == false && LoginView.IsLoaded)
                {
                    var InfoView = new InfoView();
                    InfoView.Show();
                    LoginView.Close();
                }
            };
        }
    }
}
