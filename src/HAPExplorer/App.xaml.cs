using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using HAPExplorer.Properties;

namespace HAPExplorer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.Startup += new StartupEventHandler(App_Startup);
        }

        void App_Startup(object sender, StartupEventArgs e)
        {
            //Upgrade user settings if this is a new version
            if(Settings.Default.UpgradeSettings)
            {
                Settings.Default.Upgrade();
                Settings.Default.Save();
            }
        }
    }
}
