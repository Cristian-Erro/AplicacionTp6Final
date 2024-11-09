using AplicacionTp6.Services;
using AplicacionTp6.ViewModels;

namespace AplicacionTp6.Views;

public partial class ProductoCrearPage : ContentPage
{
	public ProductoCrearPage()
	{
        ProductoService service = new ProductoService();
        ProductoCrearViewModel vm = new ProductoCrearViewModel(service);
        InitializeComponent();
        this.BindingContext = vm;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}