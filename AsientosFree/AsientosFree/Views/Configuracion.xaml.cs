using AsientosFree.ViewModels;

namespace AsientosFree.Views;

public partial class Configuracion : ContentPage
{
	private readonly ConfiguracionViewModel vm = new();

    public Configuracion()
	{
		InitializeComponent();
	}

	protected override async void OnAppearing()
    {
        base.OnAppearing();        
    }

    private async void OnCargarDefaultClicked(object sender, EventArgs e)
    {
        bool confirm = await DisplayAlert("Confirmar", "¿Estás seguro de resetear el PUC a su estado predeterminado?", "Sí", "No");
        if (confirm)
        {
            await vm.CargarDefault();
            await DisplayAlert("Éxito", "PUC reseteado a su estado predeterminado.", "OK");
        }
    }

}