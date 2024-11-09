using AplicacionTp6.Models;
using AplicacionTp6.Services;
using AplicacionTp6.ViewModels;

namespace AplicacionTp6.Views;

public partial class EditarUsuarioPage : ContentPage
{
	public EditarUsuarioPage(Usuario usuario,IUsuarioService usuarioService)
	{
		InitializeComponent();
		EditarUsuarioViewModel vm = new EditarUsuarioViewModel(usuarioService,usuario);
		this.BindingContext = vm;
	}
}