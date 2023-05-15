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
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ControlPuerto2.ViewModels
{
    [QueryProperty(nameof(IdBarco), nameof(IdBarco))]
    public class DocumentosBarcoViewModel : BaseViewModel, IQueryAttributable
    {
        #region Variables
        string _idBarco;
        BbbarcosModel _barco;
        ObservableCollection<BbdoctosModel> _documentos;

        #endregion

        #region Constructor

        #endregion

        #region Objetos

        public string IdBarco
        {
            get { return _idBarco; } 
            set { SetProperty(ref _idBarco, value); }
        }

        public BbbarcosModel Barco
        {
            get { return _barco; }
            set { SetProperty(ref _barco, value); }
        }

        public ObservableCollection<BbdoctosModel> Documentos
        {
            get { return _documentos; }
            set { SetProperty(ref _documentos, value); }
        }

        #endregion

        #region Procesos
        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            string IdNave = HttpUtility.UrlDecode(query["IdBarco"]);
            _ = ObtenerBarco(IdNave);
            _ = ObtenerDocumentos(IdNave);
        }

        public async Task ObtenerBarco(string id_barco)
        {
            Barco = await BbbarcosServices.getBarco(id_barco);
        }

        public async Task ObtenerDocumentos(string idNave)
        {
            Documentos = await BbdoctosServices.GetArchivos(idNave);
        }

        public async Task IrAUrl(string url)
        {
            string nuevoHost = "192.168.1.100:81";

            // Reemplazar "http://Archivos" con "http://192.168.1.100/Archivos"
            string nuevaUrl = url.Replace("http://Archivos", "http://" + nuevoHost + "/Archivos");
            await Browser.OpenAsync(nuevaUrl);
        }

        #endregion

        #region Comandos
        public ICommand IrAUrlCommand => new Command<string>(async (p) => await IrAUrl(p));
        #endregion
    }
}
