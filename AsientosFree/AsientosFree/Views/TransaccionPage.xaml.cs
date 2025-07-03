using AsientosFree.Models;
using AsientosFree.ViewModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Transactions;

namespace AsientosFree.Views;

public partial class TransaccionPage : ContentPage
{
    private readonly TransaccionViewModel vm = new();

    public TransaccionPage()
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
        if (string.IsNullOrWhiteSpace(NoEntry.Text) || string.IsNullOrWhiteSpace(valorEntry.Text))
        {
            await DisplayAlert("Datos incompletos", "Por favor, complete todos los campos.", "OK");
            return;
        }

        if (!decimal.TryParse(valorEntry.Text, out decimal valor))
        {
            await DisplayAlert("Error", "El valor debe ser numérico.", "OK");
            return;
        }

        var pucSeleccionado = pickerPuc.SelectedItem as Puc;
        if (pucSeleccionado == null)
        {
            await DisplayAlert("Error", "Debes seleccionar una cuenta PUC", "OK");
            return;
        }

        Transaccion transaccion = new()
        {
            No = int.Parse(NoEntry.Text),
            Cuenta = $"{pucSeleccionado.Codigo} - {pucSeleccionado.Nombre}"
        };

        if (radioDebito.IsChecked)
        {
            transaccion.Debito = valor;
            transaccion.Credito = 0;
        }
        else if (radioCredito.IsChecked)
        {
            transaccion.Debito = 0;
            transaccion.Credito = valor;
        }

        await vm.Agregar(transaccion);

        NoEntry.Text = "";
        valorEntry.Text = "";
        pickerPuc.SelectedIndex = -1;
        radioDebito.IsChecked = true;
    }

    private async void OnEliminarClicked(object sender, EventArgs e)
    {
        var button = (ImageButton)sender;
        var transaccionSeleccionada = (Transaccion)button.CommandParameter;

        if (transaccionSeleccionada != null)
        {
            bool confirm = await DisplayAlert("Confirmar eliminación", "¿Estás seguro de eliminar esta transacción?", "Sí", "No");
            if (confirm)
            {
                await vm.Eliminar(transaccionSeleccionada);
            }
        }
    }

}
