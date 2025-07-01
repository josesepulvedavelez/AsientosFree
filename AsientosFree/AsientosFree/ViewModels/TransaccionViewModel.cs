using AsientosFree.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsientosFree.ViewModels
{
    public class TransaccionViewModel
    {
        public ObservableCollection<Transaccion> Transacciones { get; } = new();

        public async Task Cargar()
        {
            Transacciones.Clear();
            var data = await MauiProgram._appDb.GetTransaccionesAsync();
            foreach (var t in data)
                Transacciones.Add(t);
        }

        public async Task Agregar(Transaccion transaccion)
        {
            await MauiProgram._appDb.AddTransaccionAsync(transaccion);
            await Cargar();
        }
    }
}
