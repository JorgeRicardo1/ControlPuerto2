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
    public class OperarioViewModel : BaseViewModel
    {
        #region Variables
        ObservableCollection<XxxxciaoModel> _operarios;

        #endregion

        #region Constructor
        public OperarioViewModel()
        {
            _ = ObtenerOperarios();
        }

        #endregion

        #region Objetos

        public ObservableCollection<XxxxciaoModel> Operarios
        {
            get { return _operarios; }
            set { SetProperty(ref _operarios, value); }
        }

        #endregion

        #region Procesos

        public async Task ObtenerOperarios()
        {
            Operarios = await XxxxciaoServices.GetOperarios();
        }

        public async Task IrADetalleOperario(XxxxciaoModel operario)
        {
            string ruta = $"/{nameof(DetalleOperarioPage)}?ClaveOperario={operario.clave}";
            await Shell.Current.GoToAsync(ruta);
        }

        #endregion

        #region Comandos

        public ICommand IrADetalleOperarioCommand => new Command<XxxxciaoModel>(async (p) => await IrADetalleOperario(p));
        #endregion
    }
}
