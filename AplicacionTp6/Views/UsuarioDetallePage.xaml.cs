using AplicacionTp6.Models;
using AplicacionTp6.ViewModels;
using AplicacionTp6.Services;

namespace AplicacionTp6.Views;

public partial class UsuarioDetallePage : ContentPage
{
	public UsuarioDetallePage(Usuario param)
	{
		InitializeComponent();
		UsuarioService usuarioService= new UsuarioService();
		UsuarioDetalleViewModel vm = new UsuarioDetalleViewModel(usuarioService);
        this.BindingContext = vm;
        vm.Usuario = param;
    }
}