using AsientosFree.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsientosFree.ViewModels
{
    public class ConfiguracionViewModel
    {
        public ObservableCollection<Puc> Lista { get; } = new();

        /// <summary>
        /// Reseta el PUC a un conjunto de cuentas predeterminado.
        /// </summary>
        /// <returns></returns>
        public async Task CargarDefault()
        {
            await MauiProgram._appDb.GetPucsDefaultAsync();                        
        }

        /// <summary>
        /// Elimina todas las transacciones de la base de datos.
        /// </summary>
        /// <returns></returns>
        public async Task EliminarTransacciones()
        {
            await MauiProgram._appDb.DeleteAllTransaccionesAsync();
        }

        /// <summary>
        /// Carga un conjunto de transacciones predeterminadas en la base de datos.
        /// </summary>
        /// <returns></returns>
        public async Task CargarTransaccionesDefaultAsync()
        {
            await MauiProgram._appDb.GetTransaccionesDefaultAsync();
        }

    }
}