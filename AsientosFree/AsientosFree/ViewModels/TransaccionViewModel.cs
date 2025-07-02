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
        public ObservableCollection<Transaccion> Lista { get; } = new();
        public ObservableCollection<Puc> Pucs { get; } = new();

        public TransaccionViewModel()
        {
            CargarPuc();
        }

        public async Task CargarPuc()
        {
            Pucs.Clear();
            var data = await MauiProgram._appDb.GetPucsAsync();
            
            foreach (var item in data)
            {
                Pucs.Add(item);    
            }
        }

        public async Task Cargar()
        {
            Lista.Clear();
            var data = await MauiProgram._appDb.GetTransaccionesAsync();

            foreach (var item in data)
            {
                Lista.Add(item);
            }            
        }

        public async Task Agregar(Transaccion transaccion)
        {
            await MauiProgram._appDb.AddTransaccionAsync(transaccion);
            await Cargar();
        }

    }
}
