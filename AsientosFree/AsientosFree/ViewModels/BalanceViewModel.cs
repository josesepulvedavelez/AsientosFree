using AsientosFree.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsientosFree.ViewModels
{
    public class BalanceViewModel
    {
        public ObservableCollection<Balance> Lista { get; } = new();

        public BalanceViewModel()
        {

        }

        public async Task Cargar()
        {
            Lista.Clear();
            
            var data = await MauiProgram._appDb.GetBalancesAsync();
            foreach (var item in data)
            {
                Lista.Add(item);
            }

        }

    }
}
