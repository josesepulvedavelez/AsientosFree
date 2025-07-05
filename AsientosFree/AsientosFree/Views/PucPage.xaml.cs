
using AsientosFree.Models;
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
        if (string.IsNullOrWhiteSpace(codigoEntry.Text) || string.IsNullOrWhiteSpace(nombreEntry.Text) || naturalezaPicker.SelectedItem == null)
        {
            await DisplayAlert("Datos imcompletos", "Por favor, complete todos los campos.", "OK");            
        }
        else
        {
            string naturaleza = naturalezaPicker.SelectedItem.ToString();
            await vm.Agregar(codigoEntry.Text, nombreEntry.Text, naturaleza);

            codigoEntry.Text = string.Empty;
            nombreEntry.Text = string.Empty;
            naturalezaPicker.SelectedItem = null;
            codigoEntry.Focus();
        }           
    }

    private async void OnEliminarClicked(object sender, EventArgs e)
    {
        var button = (ImageButton)sender;
        var pucSeleccionado = (Puc)button.CommandParameter;

        if (pucSeleccionado != null)
        {
            bool confirm = await DisplayAlert("Confirmar eliminación", "¿Estás seguro de eliminar esta cuenta PUC?", "Sí", "No");
            if (confirm)
            {
                await vm.Eliminar(pucSeleccionado);
            }
        }
    }

}