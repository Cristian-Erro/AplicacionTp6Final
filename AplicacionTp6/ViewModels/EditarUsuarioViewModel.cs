using AplicacionTp6.Models;
using AplicacionTp6.Services;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionTp6.ViewModels
{
    public partial class EditarUsuarioViewModel : BaseViewModel
    {
        public ObservableCollection<Usuario> Usuarios { get; } = new();

        private Usuario nuevoUsuario;

        public Usuario NuevoUsuario
        {
            get => nuevoUsuario;
            set
            {
                SetProperty(ref nuevoUsuario, value);
            }
        }

        private readonly IUsuarioService _usuarioService;

        public EditarUsuarioViewModel(IUsuarioService usuarioService,Usuario usuario)
        {
            _usuarioService = usuarioService;
            NuevoUsuario = usuario;
        }

        [RelayCommand]
        private async Task EditarUsuarioAsync()
        {
            if (string.IsNullOrWhiteSpace(NuevoUsuario?.nombreUsuario))
            {
                await App.Current.MainPage.DisplayAlert("Advertencia", "El nombre del usuario es obligatorio.", "Ok");
                return;
            }

            if (NuevoUsuario?.numTelefono <= 0)
            {
                await App.Current.MainPage.DisplayAlert("Advertencia", "El numero de telefono debe ser mayor a 0.", "Ok");
                return;
            }

            try
            {
                
                bool isUpdated = await _usuarioService.UpdateUserAsync(NuevoUsuario.idUsuario, NuevoUsuario);

                if (isUpdated)
                {
                    await App.Current.MainPage.DisplayAlert("Éxito", "Usuario editado correctamente.", "Ok");

                    
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "No se pudo editar el usuario", "Ok");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error!", $"Ocurrió un error: {ex.Message}", "Ok");
            }
        }
    }
}
