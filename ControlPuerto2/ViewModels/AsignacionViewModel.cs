using ControlPuerto2;
using ControlPuerto2.Models;
using ControlPuerto2.Services;
using ControlPuerto2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;
using Xamarin.Forms;

namespace ControlPuerto2.ViewModels
{
    [QueryProperty(nameof(IdBarco), nameof(IdBarco))]
    public class AsignacionViewModel : BaseViewModel, IQueryAttributable
    {
        #region Variables

        private string _idBarco;
        private BbbarcosModel _barco;
        private ObservableCollection<XxxxciaoModel> _operarios;

        #endregion

        #region Constructor

        public AsignacionViewModel()
        {
            _ = ObtenerOperarios();
            _ = ContarBarXOperario();
            
        }
        #endregion

        #region Objetos
        public string IdBarco
        {
            get {  return _idBarco; }
            set { SetProperty(ref _idBarco, value); }
        }
            
        public BbbarcosModel Barco
        {
            get { return _barco; }
            set { SetProperty(ref _barco, value); }
        }

        public ObservableCollection<XxxxciaoModel> Operarios
        {
            get { return _operarios; }
            set { SetProperty(ref _operarios, value); }
        }
        #endregion

        #region Procesos
        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            string id_barco = HttpUtility.UrlDecode(query["IdBarco"]);
            _ = ObtenerBarco(id_barco);
        }

        public async Task ObtenerBarco(string id_barco)
        {
            Barco = await BbbarcosServices.getBarco(id_barco);
        }

        public async Task ObtenerOperarios()
        {
            Operarios = await XxxxciaoServices.GetOperarios();
        }

        public async Task ContarBarXOperario()
        {
            foreach (XxxxciaoModel operario in Operarios)
            {
                operario.BarcosAsignados = await BbbarcosServices.ContarBarcosOperario(operario.nombre);
            }
        }

        public async Task AsignarOperario(XxxxciaoModel operario)
        {
            try
            {
                bool confirmacion = await DisplayAlert("Aviso", $"Quiere asignar a {operario.nombre} al barco {Barco.nav_nombre}", "Si", "No");
                if (!confirmacion)
                {
                    return;
                }
                await BbbarcosServices.AsignarOperario(Barco.id_nave, operario);
                await DisplayAlert("Aviso", "Se asigno correctamente el operario", "Ok");

                string ruta = $"///BarcosPage";

                MessagingCenter.Send(this, "RefreshBarcos");

                await Shell.Current.GoToAsync(ruta);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"{ex}", "Ok");
                throw;
            }
        }

        public async Task IrADetalleOperario(XxxxciaoModel operario)
        {
            string ruta = $"/{nameof(DetalleOperarioPage)}?ClaveOperario={operario.clave}";
            await Shell.Current.GoToAsync(ruta);
        }

        #endregion

        #region Comandos

        public ICommand AsignarOperarioCommand => new Command<XxxxciaoModel>(async (p) => await AsignarOperario(p));
        public ICommand IrADetalleOperarioCommand => new Command<XxxxciaoModel>(async (p) => await IrADetalleOperario(p));
        #endregion
    }
}
