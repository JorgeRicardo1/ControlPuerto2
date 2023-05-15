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
    public class LoginViewModel : BaseViewModel
    {
        #region Variables

        private ObservableCollection<XxxxciaoModel> _operarios;
        private XxxxciaoModel _operarioSelected;
        private string _claveOperario;

        #endregion

        #region Constructor

        public LoginViewModel()
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

        public XxxxciaoModel OperarioSelected
        {
            get { return _operarioSelected; }
            set { SetProperty(ref _operarioSelected, value); }
        }

        public string ClaveOperario
        {
            get { return _claveOperario; }
            set { SetProperty(ref _claveOperario, value); }
        }


        #endregion

        #region Procesos

        public async Task ObtenerOperarios()
        {
            Operarios = await XxxxciaoServices.GetOperarios();
        }

        public async Task ValidarOperario()
        {
            if (OperarioSelected != null && ClaveOperario != "")
            {
                if (OperarioSelected.pw == ClaveOperario)
                {
                    App.Operario = OperarioSelected;
                    await IrABarcosPage();
                }
                else
                {
                    await DisplayAlert("Aviso","Contraseña Incorrecta","Ok");
                }
            }
            else
            {
                await DisplayAlert("Aviso", "Seleccione un operario e ingrese una contraseña", "Ok");
            }
        }
        public async Task IrABarcosPage()
        {
            await Shell.Current.GoToAsync($"//{nameof(BarcosPage)}");
        }

        #endregion

        #region Comandos

        public ICommand ValidarOperarioCommand => new Command(async () => await ValidarOperario());

        #endregion
    }
}
