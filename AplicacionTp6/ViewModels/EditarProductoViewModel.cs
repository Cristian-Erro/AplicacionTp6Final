using AplicacionTp6.Models;

using AplicacionTp6.Views;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using AplicacionTp6.Services;

namespace AplicacionTp6.ViewModels
{
    public partial class EditarProductoViewModel : BaseViewModel
    {
        public ObservableCollection<Producto> Productos { get; } = new();

        // Producto a editar
        private Producto nuevoProducto;
        public Producto NuevoProducto
        {
            get => nuevoProducto;
            set
            {
                SetProperty(ref nuevoProducto, value);
            }
        }

        private readonly IProductoService _productoService;

        public EditarProductoViewModel(IProductoService productoService, Producto producto)
        {

            _productoService = productoService;

            // Asignar el producto recibido al NuevoProducto
            NuevoProducto = producto;
        }

        [RelayCommand]
        private async Task EditarProductoAsync()
        {
            if (string.IsNullOrWhiteSpace(NuevoProducto?.nombreProducto))
            {
                await App.Current.MainPage.DisplayAlert("Advertencia", "El nombre del producto es obligatorio.", "Ok");
                return;
            }

            if (NuevoProducto?.precioProducto <= 0)
            {
                await App.Current.MainPage.DisplayAlert("Advertencia", "El precio debe ser mayor a 0.", "Ok");
                return;
            }

            try
            {
                // Actualizar el producto en la base de datos a través del servicio
                bool isUpdated = await _productoService.UpdateProductAsync(NuevoProducto.idProducto, NuevoProducto);

                if (isUpdated)
                {
                    await App.Current.MainPage.DisplayAlert("Éxito", "Producto editado correctamente.", "Ok");

                    // Navegar a la página de detalles del producto editado
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "No se pudo editar el producto", "Ok");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error!", $"Ocurrió un error: {ex.Message}", "Ok");
            }
        }
    }
}