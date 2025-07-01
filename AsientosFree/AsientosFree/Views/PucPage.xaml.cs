
using AsientosFree.ViewModels;
using System.Threading.Tasks;

namespace AsientosFree.Views;

public partial class PucPage : ContentPage
{
	private readonly PucViewModel vm = new();

	public PucPage()
	{
		InitializeComponent();
        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await vm.Cargar();
    }

    private async void OnAgregarClicked(object sender, EventArgs e)
    {
        await vm.Agregar(codigoEntry.Text, nombreEntry.Text);
        codigoEntry.Text = string.Empty;
        nombreEntry.Text = string.Empty;
    }
}