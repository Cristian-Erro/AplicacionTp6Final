using AplicacionTp6.Models;
using AplicacionTp6.Services;
using AplicacionTp6.ViewModels;

namespace AplicacionTp6.Views;

public partial class ProductoDetallePage : ContentPage
{
	public ProductoDetallePage(Producto param)
	{
		InitializeComponent();
        ProductoService productoService = new ProductoService();
        ProductoDetalleViewModel vm = new ProductoDetalleViewModel(productoService);
        this.BindingContext = vm;
        vm.Producto = param;
    }
}