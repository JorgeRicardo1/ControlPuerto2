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
    [QueryProperty(nameof(ClaveOperario), nameof(ClaveOperario))]
    public class OperarioDetalleViewModel : BaseViewModel, IQueryAttributable
    {

        #region Variables
        string _claveOperario;
        XxxxciaoModel _operario;
        ObservableCollection<BbbarcosModel> _barcos;
        ObservableCollection<BbdoctosModel> _documentos;
        bool _isVisibleRemover;

        #endregion

        #region Constructor
        public OperarioDetalleViewModel() 
        {
            CheckearPermisos();
        }

        #endregion

        #region Objetos
        public string ClaveOperario
        {
            get { return _claveOperario;}
            set { SetProperty(ref _claveOperario, value); }
        }

        public XxxxciaoModel Operario
        {
            get { return _operario; }
            set { SetProperty(ref _operario, value); }
        }

        public ObservableCollection<BbbarcosModel> Barcos
        {
            get { return _barcos; }
            set { SetProperty(ref _barcos, value); }
        }

        public ObservableCollection<BbdoctosModel> Documentos
        {
            get { return _documentos; }
            set { SetProperty(ref _documentos, value); }
        }

        public bool IsVisibleRemover
        {
            get { return _isVisibleRemover; }
            set { SetProperty(ref _isVisibleRemover, value); }
        }
        #endregion

        #region Procesos

        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            string clave = HttpUtility.UrlDecode(query["ClaveOperario"]);
            _ = ObtenerOperario(clave);
        }

        public async Task ObtenerOperario(string clave_operario)
        {
            Operario = await XxxxciaoServices.GetOperario(clave_operario);
            _=ObtenerBarcosOperario();
        }

        public async Task ObtenerBarcosOperario()
        {
            Barcos = await BbbarcosServices.GetBarcosOperario(Operario.clave);
        }

        public async Task IraDocumentosBarco(BbbarcosModel barcoSelected)
        {
            //_ = ObtenerDocumentos(barcoSelected.id_nave.ToString());
            string ruta = $"/{nameof(DocumentosBarcoPage)}?IdBarco={barcoSelected.id_nave}";
            await Shell.Current.GoToAsync(ruta);
        }

        public async Task DesasignarBarco(int idNave)
        {
            bool respuesta = await DisplayAlert("Aviso", $"Seguro que desea desasignar el barco para el operario {Operario.nombre}", "Si","No");
            if (respuesta)
            {
                await BbbarcosServices.RemoverOperario(idNave.ToString());
                _ = ObtenerBarcosOperario();
            }
        }

        public void CheckearPermisos()
        {
            if (App.Operario.nivel >= 4)
            {
                IsVisibleRemover = true;
            }
            else
            {
                IsVisibleRemover= false;
            }
        }
        #endregion

        #region Comandos
        public ICommand IraDocumentosBarcoCommand => new Command<BbbarcosModel>(async (p) => await IraDocumentosBarco(p));
        public ICommand DesasignarBarcoCommand => new Command<int>(async (p) => await DesasignarBarco(p));
        #endregion
    }
}
