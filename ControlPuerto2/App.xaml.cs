using ControlPuerto2.Services;
using ControlPuerto2.Views;
using Plugin.DeviceInfo;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ControlPuerto2
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            var id = CrossDeviceInfo.Current.Id;
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
