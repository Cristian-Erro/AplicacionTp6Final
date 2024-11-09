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
    public partial class ProductoDetalleViewModel:BaseViewModel
    {
        [ObservableProperty]
        Producto producto;

        IProductoService _productoService;
        public ProductoDetalleViewModel(IProductoService productoService)
        {
            Title = "Detalle de Producto";
            _productoService = productoService;
        }
        [RelayCommand]
        private async Task DeleteProductAsync()
        {
            if (producto == null)
            {
                await App.Current.MainPage.DisplayAlert("Advertencia", "No hay producto seleccionado para eliminar.", "Ok");
                return;
            }

            try
            {
                bool isDeleted = await _productoService.DeleteProductAsync(producto.idProducto);

                if (isDeleted)
                {
                    await App.Current.MainPage.DisplayAlert("Éxito", "Producto eliminado correctamente.", "Ok");
                    // Aquí puedes agregar lógica para actualizar la lista de productos si es necesario
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "No se pudo eliminar el producto.", "Ok");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error!", ex.Message, "Ok");
            }
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        [RelayCommand]
        private async Task GoEditar()
        {
            // Navegar a la página de edición de producto, pasando el producto actual como parámetro.
            await Application.Current.MainPage.Navigation.PushAsync(new EditarProductoPage(producto, _productoService));

        }
    }
}
