using ControlPuerto2.ViewModels;
using ControlPuerto2.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ControlPuerto2
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AsignacionPage), typeof(AsignacionPage));
            Routing.RegisterRoute(nameof(DetalleOperarioPage), typeof(DetalleOperarioPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
