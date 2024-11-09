/*
namespace AplicacionTp6.Views;

public partial class EditarProductoPage : ContentPage
{
    public EditarProductoPage()
    {
        InitializeComponent();
    }
}
*/


using AplicacionTp6.Models;
using AplicacionTp6.Services;
using AplicacionTp6.ViewModels;

namespace AplicacionTp6.Views;

public partial class EditarProductoPage : ContentPage
{
	public EditarProductoPage(Producto producto, IProductoService productoService)
    {
		InitializeComponent();

		EditarProductoViewModel vm = new EditarProductoViewModel(productoService, producto);

        this.BindingContext = vm;
    }
}
