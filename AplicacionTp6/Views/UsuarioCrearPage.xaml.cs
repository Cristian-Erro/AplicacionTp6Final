using AplicacionTp6.Services;
using AplicacionTp6.ViewModels;

namespace AplicacionTp6.Views;

public partial class UsuarioCrearPage : ContentPage
{
	public UsuarioCrearPage()
	{
        UsuarioService service = new UsuarioService();
        UsuarioCrearViewModel vm = new UsuarioCrearViewModel(service);
		InitializeComponent();
        this.BindingContext = vm;
	}
    private async void Button_Clicked(object sender, EventArgs e)
    {
        
        await Navigation.PopAsync();
    }
}