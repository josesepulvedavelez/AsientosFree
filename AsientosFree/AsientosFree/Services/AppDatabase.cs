using AsientosFree.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsientosFree.Services
{
    public class AppDatabase
    {
        private readonly SQLiteAsyncConnection _db;

        public AppDatabase(string path)
        { 
            _db = new SQLiteAsyncConnection(path);
            _db.CreateTableAsync<Puc>();
            _db.CreateTableAsync<Transaccion>();
        }


        /* Plan unico de cuentas */        
        public Task<List<Puc>> GetPucsAsync()
        {
            return _db.Table<Puc>().OrderBy(x => x.Codigo).ToListAsync();
        }

        public Task<int> AddPucAsync(Puc puc)
        { 
            return _db.InsertAsync(puc);
        }

        public Task<int> DeletePucAsync(Puc puc)
        {
            return _db.DeleteAsync(puc);
        }

        /// <summary>
        /// Reseta el PUC a un conjunto de cuentas predeterminado.
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetPucsDefaultAsync()
        {
            await _db.DeleteAllAsync<Puc>();
            var cuentas = new List<Puc>
            {
                new Puc { Codigo = "1", Nombre = "ACTIVO", Naturaleza = "Debito" },
                new Puc { Codigo = "11", Nombre = "EFECTIVO Y EQUIVALENTES AL EFECTIVO", Naturaleza = "Debito" },
                new Puc { Codigo = "1105", Nombre = "CAJA", Naturaleza = "Debito" },
                new Puc { Codigo = "110505", Nombre = "CAJA GENERAL", Naturaleza = "Debito" },
                new Puc { Codigo = "11050501", Nombre = "CAJA GENERAL", Naturaleza = "Debito" },
                new Puc { Codigo = "11050599", Nombre = "AJUSTES POR INFLACION", Naturaleza = "Debito" },
                new Puc { Codigo = "110510", Nombre = "CAJA MENOR", Naturaleza = "Debito" },
                new Puc { Codigo = "11051001", Nombre = "CAJA MENOR", Naturaleza = "Debito" },
                new Puc { Codigo = "11051099", Nombre = "AJUSTES POR INFLACION", Naturaleza = "Debito" },
                new Puc { Codigo = "110515", Nombre = "FONDOS EN CAJA", Naturaleza = "Debito" },
                new Puc { Codigo = "11051501", Nombre = "FONDOS EN CAJA", Naturaleza = "Debito" },
                new Puc { Codigo = "11051599", Nombre = "AJUSTES POR INFLACION", Naturaleza = "Debito" },
                new Puc { Codigo = "1110", Nombre = "BANCOS", Naturaleza = "Debito" },
                new Puc { Codigo = "111005", Nombre = "MONEDA NACIONAL", Naturaleza = "Debito" },
                new Puc { Codigo = "11100501", Nombre = "BANCOLOMBIA CTA CORRIENTE", Naturaleza = "Debito" },
                new Puc { Codigo = "11100502", Nombre = "BANCOLOMBIA CTA AHORROS", Naturaleza = "Debito" },
                new Puc { Codigo = "11100503", Nombre = "BANCO DE BOGOTA CTA CORRIENTE", Naturaleza = "Debito" },
                new Puc { Codigo = "11100504", Nombre = "BANCO DE BOGOTA CTA AHORROS", Naturaleza = "Debito" },
                new Puc { Codigo = "11100505", Nombre = "BBVA CTA CORRIENTE", Naturaleza = "Debito" },
                new Puc { Codigo = "11100506", Nombre = "BBVA CTA AHORROS", Naturaleza = "Debito" },
                new Puc { Codigo = "11100507", Nombre = "DAVIVIENDA CTA CORRIENTE", Naturaleza = "Debito" },
                new Puc { Codigo = "11100508", Nombre = "DAVIVIENDA CTA AHORROS", Naturaleza = "Debito" },
                new Puc { Codigo = "11100599", Nombre = "AJUSTES POR INFLACION", Naturaleza = "Debito" },
                new Puc { Codigo = "111010", Nombre = "MONEDA EXTRANJERA", Naturaleza = "Debito" },
                new Puc { Codigo = "11101001", Nombre = "CUENTA MONEDA EXTRANJERA USD", Naturaleza = "Debito" },
                new Puc { Codigo = "11101002", Nombre = "CUENTA MONEDA EXTRANJERA EUR", Naturaleza = "Debito" },
                new Puc { Codigo = "11101099", Nombre = "AJUSTES POR INFLACION", Naturaleza = "Debito" },
                new Puc { Codigo = "12", Nombre = "INVERSIONES Y VALORES", Naturaleza = "Debito" },
                new Puc { Codigo = "1204", Nombre = "INVERSIONES", Naturaleza = "Debito" },
                new Puc { Codigo = "120405", Nombre = "ACCIONES", Naturaleza = "Debito" },
                new Puc { Codigo = "12040501", Nombre = "ACCIONES EN SOCIEDADES NACIONALES", Naturaleza = "Debito" },
                new Puc { Codigo = "12040502", Nombre = "ACCIONES EN SOCIEDADES EXTRANJERAS", Naturaleza = "Debito" },
                new Puc { Codigo = "12040599", Nombre = "AJUSTES POR INFLACION", Naturaleza = "Debito" },
                new Puc { Codigo = "120410", Nombre = "CUOTAS O PARTES DE INTERES SOCIAL", Naturaleza = "Debito" },
                new Puc { Codigo = "12041001", Nombre = "CUOTAS EN SOCIEDADES NACIONALES", Naturaleza = "Debito" },
                new Puc { Codigo = "12041002", Nombre = "CUOTAS EN SOCIEDADES EXTRANJERAS", Naturaleza = "Debito" },
                new Puc { Codigo = "12041099", Nombre = "AJUSTES POR INFLACION", Naturaleza = "Debito" },
                new Puc { Codigo = "120415", Nombre = "BONOS", Naturaleza = "Debito" },
                new Puc { Codigo = "12041501", Nombre = "BONOS EN SOCIEDADES NACIONALES", Naturaleza = "Debito" },
                new Puc { Codigo = "12041502", Nombre = "BONOS EN SOCIEDADES EXTRANJERAS", Naturaleza = "Debito" },
                new Puc { Codigo = "12041599", Nombre = "AJUSTES POR INFLACION", Naturaleza = "Debito" },
                new Puc { Codigo = "120420", Nombre = "CEDULAS", Naturaleza = "Debito" },
                new Puc { Codigo = "12042001", Nombre = "CEDULAS EN SOCIEDADES NACIONALES", Naturaleza = "Debito" },
                new Puc { Codigo = "12042002", Nombre = "CEDULAS EN SOCIEDADES EXTRANJERAS", Naturaleza = "Debito" },
                new Puc { Codigo = "12042099", Nombre = "AJUSTES POR INFLACION", Naturaleza = "Debito" },
                new Puc { Codigo = "120425", Nombre = "PAPELES COMERCIALES", Naturaleza = "Debito" },
                new Puc { Codigo = "12042501", Nombre = "PAPELES COMERCIALES EN SOCIEDADES NACIONALES", Naturaleza = "Debito" },
                new Puc { Codigo = "12042502", Nombre = "PAPELES COMERCIALES EN SOCIEDADES EXTRANJERAS", Naturaleza = "Debito" },
                new Puc { Codigo = "12042599", Nombre = "AJUSTES POR INFLACION", Naturaleza = "Debito" },
                new Puc { Codigo = "120430", Nombre = "CERTIFICADOS DE DEPOSITO A TERMINO - CDT", Naturaleza = "Debito" },
                new Puc { Codigo = "12043001", Nombre = "CDT EN MONEDA NACIONAL", Naturaleza = "Debito" },
                new Puc { Codigo = "12043002", Nombre = "CDT EN MONEDA EXTRANJERA", Naturaleza = "Debito" },
                new Puc { Codigo = "12043099", Nombre = "AJUSTES POR INFLACION", Naturaleza = "Debito" },
                new Puc { Codigo = "120435", Nombre = "TITULOS", Naturaleza = "Debito" },
                new Puc { Codigo = "12043501", Nombre = "TITULOS EN MONEDA NACIONAL", Naturaleza = "Debito" },
                new Puc { Codigo = "12043502", Nombre = "TITULOS EN MONEDA EXTRANJERA", Naturaleza = "Debito" },
                new Puc { Codigo = "12043599", Nombre = "AJUSTES POR INFLACION", Naturaleza = "Debito" },
                new Puc { Codigo = "120440", Nombre = "DERECHOS FIDUCIARIOS", Naturaleza = "Debito" },
                new Puc { Codigo = "12044001", Nombre = "FIDUCIAS EN SOCIEDADES NACIONALES", Naturaleza = "Debito" },
                new Puc { Codigo = "12044002", Nombre = "FIDUCIAS EN SOCIEDADES EXTRANJERAS", Naturaleza = "Debito" },
                new Puc { Codigo = "12044099", Nombre = "AJUSTES POR INFLACION", Naturaleza = "Debito" },
                new Puc { Codigo = "120445", Nombre = "OTRAS INVERSIONES", Naturaleza = "Debito" },
                new Puc { Codigo = "12044501", Nombre = "OTRAS INVERSIONES NACIONALES", Naturaleza = "Debito" },
                new Puc { Codigo = "12044502", Nombre = "OTRAS INVERSIONES EXTRANJERAS", Naturaleza = "Debito" },
                new Puc { Codigo = "12044599", Nombre = "AJUSTES POR INFLACION", Naturaleza = "Debito" },
                new Puc { Codigo = "2", Nombre = "PASIVO", Naturaleza = "Credito" },
                new Puc { Codigo = "21", Nombre = "OBLIGACIONES FINANCIERAS", Naturaleza = "Credito" },
                new Puc { Codigo = "2105", Nombre = "BANCOS NACIONALES", Naturaleza = "Credito" },
                new Puc { Codigo = "210505", Nombre = "SOBREGIROS BANCARIOS", Naturaleza = "Credito" },
                new Puc { Codigo = "210510", Nombre = "CREDITOS BANCARIOS", Naturaleza = "Credito" },
                new Puc { Codigo = "3", Nombre = "PATRIMONIO", Naturaleza = "Credito" },
                new Puc { Codigo = "31", Nombre = "CAPITAL SOCIAL", Naturaleza = "Credito" },
                new Puc { Codigo = "3105", Nombre = "APORTES SOCIOS", Naturaleza = "Credito" },
                new Puc { Codigo = "4", Nombre = "INGRESOS", Naturaleza = "Credito" },
                new Puc { Codigo = "41", Nombre = "OPERACIONALES", Naturaleza = "Credito" },
                new Puc { Codigo = "4105", Nombre = "VENTAS", Naturaleza = "Credito" },
                new Puc { Codigo = "5", Nombre = "GASTOS", Naturaleza = "Debito" },
                new Puc { Codigo = "51", Nombre = "GASTOS DE ADMINISTRACION", Naturaleza = "Debito" },
                new Puc { Codigo = "5105", Nombre = "SUELDOS", Naturaleza = "Debito" },
                new Puc { Codigo = "6", Nombre = "CUENTAS DE ORDEN DEUDORAS", Naturaleza = "Debito" },
                new Puc { Codigo = "61", Nombre = "CONTROL", Naturaleza = "Debito" },
                new Puc { Codigo = "6105", Nombre = "CONTROL DE ACTIVOS", Naturaleza = "Debito" }
            };

            return await _db.InsertAllAsync(cuentas);
        }


        /* Transacciones */
        public Task<List<Transaccion>> GetTransaccionesAsync()
        {
            return _db.Table<Transaccion>().ToListAsync();
        }

        public Task<int> AddTransaccionAsync(Transaccion transaccion)
        {
            return _db.InsertAsync(transaccion);
        }
        
        public Task<int> DeleteTransaccionAsync(Transaccion transaccion)
        {
            return _db.DeleteAsync(transaccion);
        }

        public async Task<List<Balance>> GetBalancesAsync()
        {
            var transacciones = await _db.Table<Transaccion>().ToListAsync();

            var balances = transacciones
                .GroupBy(t => t.Cuenta)
                .Select(g =>
                {
                    var sumDebito = g.Sum(x => x.Debito);
                    var sumCredito = g.Sum(x => x.Credito);

                    decimal saldoDebito = 0;
                    decimal saldoCredito = 0;

                    if (sumDebito > sumCredito)
                    {
                        saldoDebito = sumDebito - sumCredito;
                    }
                    else if (sumCredito > sumDebito)
                    {
                        saldoCredito = sumCredito - sumDebito;
                    }

                    return new Balance
                    {
                        Cuenta = g.Key,
                        Debito = sumDebito,
                        Credito = sumCredito,
                        SaldoDebito = saldoDebito,
                        SaldoCredito = saldoCredito
                    };
                })
                .ToList();

            return balances;
        }

    }
}
