using AsientosFree.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsientosFree.ViewModels
{
    public class PucViewModel
    {
        public ObservableCollection<Puc> Lista { get; } = new();

        public async Task Cargar()
        {
            Lista.Clear();
            var data = await MauiProgram._appDb.GetPucsAsync();
            foreach (var item in data)
                Lista.Add(item);
        }

        public async Task Agregar(string codigo, string nombre, string naturaleza)
        {
            await MauiProgram._appDb.AddPucAsync(new Puc { Codigo = codigo, Nombre = nombre, Naturaleza = naturaleza });
            await Cargar();
        }

        public async Task Eliminar(Puc puc)
        {
            await MauiProgram._appDb.DeletePucAsync(puc);
            await Cargar();
        }

    }
}