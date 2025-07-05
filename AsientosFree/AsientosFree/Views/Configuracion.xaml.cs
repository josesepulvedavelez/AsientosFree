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
        bool confirm = await DisplayAlert("Confirmar", "�Est�s seguro de resetear el PUC a su estado predeterminado?", "S�", "No");
        if (confirm)
        {
            await vm.CargarDefault();
            await DisplayAlert("�xito", "PUC reseteado a su estado predeterminado.", "OK");
        }
    }

}