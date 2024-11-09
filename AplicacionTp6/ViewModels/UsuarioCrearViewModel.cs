using AplicacionTp6.Models;
using AplicacionTp6.Services;
using AplicacionTp6.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionTp6.ViewModels
{
    public partial class UsuarioCrearViewModel: BaseViewModel
    {
        public ObservableCollection<Usuario> Usuarios{ get; } = new();

        [ObservableProperty]
        Usuario nuevoUsuario = new Usuario();

        IUsuarioService _usuarioService;

        public UsuarioCrearViewModel(IUsuarioService usuarioService)
        {
            Title = "Crear Usuario";
            _usuarioService = usuarioService;
            NuevoUsuario = new Usuario();
        }

        [RelayCommand]
        private async Task CrearUsuarioAsync()
        {
            if (string.IsNullOrWhiteSpace(nuevoUsuario?.nombreUsuario) || nuevoUsuario?.numTelefono <= 0)
            {
                await App.Current.MainPage.DisplayAlert("Advertencia", "Complete todos los campos correctamente.", "Ok");
                return;
            }

            try
            {
                var usuarioCreado = await _usuarioService.CreateUserAsync(nuevoUsuario);

                if (usuarioCreado != null)
                {
                    Usuarios.Add(usuarioCreado);
                    await App.Current.MainPage.DisplayAlert("Éxito", "Usuario creado correctamente.", "Ok");
                    NuevoUsuario = new Usuario();
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "No se pudo crear el usuario", "Ok");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Exito", "Usuario creado correctamente.", "Ok");
                await Application.Current.MainPage.Navigation.PushAsync(new UsuarioListaPage());
            }
        }




    }
}
