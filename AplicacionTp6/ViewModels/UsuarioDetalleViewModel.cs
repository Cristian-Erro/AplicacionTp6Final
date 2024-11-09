using AplicacionTp6.Models;
using AplicacionTp6.Services;
using AplicacionTp6.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionTp6.ViewModels
{
    public partial class UsuarioDetalleViewModel: BaseViewModel
    {
        [ObservableProperty]
        Usuario usuario;

        IUsuarioService _usuarioService;

        public UsuarioDetalleViewModel(IUsuarioService usuarioService)
        {
            Title = "Detalle de usuario";
            _usuarioService = usuarioService;
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        [RelayCommand]
        public async Task GoToCrearLista()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new UsuarioCrearPage());
        }


        [RelayCommand]
        public async Task GoToEditarLista()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new EditarUsuarioPage(usuario, _usuarioService));
        }

        [RelayCommand]
        private async Task DeleteUserAsync()
        {
            if (usuario == null)
            {
                await App.Current.MainPage.DisplayAlert("Advertencia", "No hay usuario seleccionado para eliminar.", "Ok");
                return;
            }

            try
            {
                bool isDeleted = await _usuarioService.DeleteUserAsync(usuario.idUsuario);

                if (isDeleted)
                {
                    await App.Current.MainPage.DisplayAlert("Éxito", "Usuario eliminado correctamente.", "Ok");
                   
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "No se pudo eliminar el usuario.", "Ok");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error!", ex.Message, "Ok");
            }
        }

    }
}
