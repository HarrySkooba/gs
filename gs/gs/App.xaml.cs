using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using gs.Tools;
using System.IO;

namespace gs
{
    public partial class App : Application
    {
        static DB dB;

        public static DB DB
        {
            get
            {
                if (dB == null)
                {
                    dB = new DB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DataBase.db3"));
                }
                return dB;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
