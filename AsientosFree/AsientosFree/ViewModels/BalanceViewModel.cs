using AsientosFree.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AsientosFree.ViewModels
{
    public class BalanceViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Balance> Lista { get; } = new ObservableCollection<Balance>();

        private decimal _totalSaldoDebito;
        public decimal TotalSaldoDebito
        {
            get => _totalSaldoDebito;
            set
            {
                _totalSaldoDebito = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(AreTotalsEqual));
            }
        }

        private decimal _totalSaldoCredito;
        public decimal TotalSaldoCredito
        {
            get => _totalSaldoCredito;
            set
            {
                _totalSaldoCredito = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(AreTotalsEqual));
            }
        }

        public bool AreTotalsEqual => TotalSaldoDebito == TotalSaldoCredito;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task Cargar()
        {
            Lista.Clear();

            var data = await MauiProgram._appDb.GetBalancesAsync();
            decimal totalDebito = 0;
            decimal totalCredito = 0;

            foreach (var item in data)
            {
                Lista.Add(item);
                totalDebito += item.SaldoDebito ?? 0;
                totalCredito += item.SaldoCredito ?? 0;
            }

            TotalSaldoDebito = totalDebito;
            TotalSaldoCredito = totalCredito;
        }
    }

}
