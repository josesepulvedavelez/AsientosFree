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

    public async void OnEliminarTransaccionesClicked(object sender, EventArgs e)
    {
        bool confirm = await DisplayAlert("Confirmar", "�Est�s seguro de eliminar todas las transacciones?", "S�", "No");
        if (confirm)
        {
            await vm.EliminarTransacciones();
            await DisplayAlert("�xito", "Todas las transacciones han sido eliminadas.", "OK");
        }
    }

    public async void OnCargarTransaccionesDefaultClicked(object sender, EventArgs e)
    {
        bool confirm = await DisplayAlert("Confirmar", "�Est�s seguro de cargar las transacciones de ejemplo?", "S�", "No");
        if (confirm)
        {
            await vm.CargarTransaccionesDefaultAsync();
            await DisplayAlert("�xito", "Transacciones de ejemplo cargadas.", "OK");
        }
    }

}