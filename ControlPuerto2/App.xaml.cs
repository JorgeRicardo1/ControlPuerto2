using ControlPuerto2.Data;
using ControlPuerto2.Models;
using ControlPuerto2.Services;
using ControlPuerto2.Views;
using Plugin.DeviceInfo;
using SQLite;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ControlPuerto2
{
    public partial class App : Application
    {
        public static DataBase Context { get; set; }
        public static SQLiteAsyncConnection Connection { get; set; }
        public static EmpresaModel Empresa { get; set; }
        public App()
        {
            InitializeDatabase();
            Task.Run(async () => await ObtenerEmpresa());
            InitializeComponent();
           

            MainPage = new AppShell();
        }

        private void InitializeDatabase()
        {
            var folderApp = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData); // ruta de la carpera local del aplicativo
            var dbPath = System.IO.Path.Combine(folderApp, "pedidos.db");
            Context = new DataBase(dbPath, Connection);
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

        public async Task ObtenerEmpresa()
        {
            var empre = await App.Context.getEmpresaAsync();
            Empresa =  empre[0];
            DataConexion.getConnectionString(empre);
        }
    }
}
