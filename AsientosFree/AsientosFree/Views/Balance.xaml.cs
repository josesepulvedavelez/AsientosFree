using AsientosFree.ViewModels;

namespace AsientosFree.Views;

public partial class Balance : ContentPage
{
    private readonly BalanceViewModel vm = new();
    
	public Balance()
	{
		InitializeComponent();
        BindingContext = vm;
    }

	protected override async void OnAppearing()
    {
        base.OnAppearing();
        await vm.Cargar();        
    }
}