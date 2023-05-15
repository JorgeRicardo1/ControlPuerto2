using ControlPuerto2.Models;
using ControlPuerto2.Services;
using ControlPuerto2.Views;
using Plugin.DeviceInfo;
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
    public class AppShellViewModel : BaseViewModel
    {
        #region Variables
        bool _isValidacionVisible;
        #endregion

        #region Constructor
        public AppShellViewModel()
        {
            IsValidacionVisible = true;
            Task.Run(async () => await ValidarNuevoEquipo());
        }

        #endregion

        #region Objetos
        public bool IsValidacionVisible
        {
            get { return _isValidacionVisible; }
            set { SetProperty(ref _isValidacionVisible, value); }
        }

        #endregion

        #region Procesos
        public async Task ValidarNuevoEquipo()
        {
            try
            {
                string id = CrossDeviceInfo.Current.Id;

                if (App.Empresa == null)
                {
                    IsValidacionVisible = true;
                }
                else
                {
                    var equipo = await LlequipoServices.Validar(id, App.Empresa.empresa);
                    if (equipo != null && equipo.modulos.Contains("M33") && equipo.activar.Equals(App.Empresa.activar))
                    {
                        IsValidacionVisible = false;
                    }
                    else
                    {
                        IsValidacionVisible = true;
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            
        }
        #endregion

        #region Comandos


        #endregion
    }

}
