using ControlPuerto2.Models;
using ControlPuerto2.Services;
using ControlPuerto2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ControlPuerto2.ViewModels
{
    public class BarcoViewModel : BaseViewModel
    {
        #region Variables

        private ObservableCollection<BbbarcosModel> _barcosNoAsignados;
        private bool _tituloIsVisible;
        private BbbarcosModel _barcoSelected;

        #endregion

        #region Constructor

        public BarcoViewModel()
        {
            TituloIsVisible = false;
            _ = ObtenerBarcos();

            MessagingCenter.Subscribe<AsignacionViewModel>(this, "RefreshBarcos", (sender) =>
            {
                _ = ObtenerBarcos();
                
            });
        }
        #endregion

        #region Objetos

        public ObservableCollection<BbbarcosModel> BarcoNoAsignados
        {
            get { return _barcosNoAsignados; }
            set
            {
                if (value != null) { TituloIsVisible = true; }
                SetProperty(ref _barcosNoAsignados, value);
            }
        }

        public bool TituloIsVisible
        {
            get { return _tituloIsVisible; }
            set { SetProperty(ref _tituloIsVisible, value); }
        }

        public BbbarcosModel BarcoSelected
        {
            get { return _barcoSelected; }
            set { SetProperty(ref _barcoSelected, value); }
        }

        #endregion

        #region Procesos

        public async Task ObtenerBarcos()
        {
            BarcoNoAsignados = await BbbarcosServices.getBarcos();
        }

        public async Task IrAsignacionBarco(BbbarcosModel barcoSelected)
        {
            string ruta = $"/{nameof(AsignacionPage)}?IdBarco={barcoSelected.id_nave}";
            await Shell.Current.GoToAsync(ruta);
        }

        
        #endregion

        #region Comandos

        public ICommand ObtenerBarcosCommand => new Command(async () => await ObtenerBarcos());
        public ICommand IrAsignacionBarcoCommand => new Command<BbbarcosModel>(async (p) => await IrAsignacionBarco(p));
        #endregion
    }
}
