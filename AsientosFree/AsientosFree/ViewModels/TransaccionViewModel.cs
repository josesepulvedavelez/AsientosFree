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
        public ObservableCollection<TransaccionGroup> ListaAgrupada { get; } = new();
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

            ListaAgrupada.Clear();
            var dataTransacciones = await MauiProgram._appDb.GetTransaccionesAsync();

            var grupos = dataTransacciones
                .GroupBy(t => t.No)
                .Select(g => new TransaccionGroup
                {
                    No = g.Key,
                    Detalles = new ObservableCollection<Transaccion>(g)
                });

            foreach (var grupo in grupos)
            {
                ListaAgrupada.Add(grupo);
            }
        }

        public async Task Agregar(Transaccion transaccion)
        {
            await MauiProgram._appDb.AddTransaccionAsync(transaccion);
            await Cargar();
        }

        public async Task Eliminar(Transaccion transaccion)
        {
            await MauiProgram._appDb.DeleteTransaccionAsync(transaccion);
            await Cargar();
        }

    }
}
