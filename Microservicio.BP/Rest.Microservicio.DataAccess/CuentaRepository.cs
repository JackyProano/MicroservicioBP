using Microsoft.EntityFrameworkCore;
using Rest.Microservicio.Model.Entidades;
using Rest.Microservicio.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest.Microservicio.DataAccess
{
    public class CuentaRepository : ICuentaRepository
    {
        private readonly BaseDatosBPContext _objContexto;

        public CuentaRepository(BaseDatosBPContext objContext)
        {
            _objContexto = objContext;
        }

        public async Task<Cuenta> ActualizarCuenta(Cuenta objCuenta)
        {
            _objContexto.Entry(objCuenta).State = EntityState.Modified;
            await _objContexto.SaveChangesAsync().ConfigureAwait(true);
            return objCuenta;
        }

        public async Task<Cuenta> ConsultarCuenta(string strNumeroCuenta)
        {
            Cuenta objCuenta = new Cuenta();
            objCuenta = await _objContexto.Cuenta.FindAsync(strNumeroCuenta);
            return objCuenta;
        }

        public async Task<IEnumerable<Cuenta>> ConsultarCuentas()
        {
            IEnumerable<Cuenta> objCuentas = null;
            objCuentas = await _objContexto.Cuenta.ToListAsync();
            return objCuentas;
        }

        public async Task<bool> EliminarCuenta(string strNumeroCuenta)
        {
            Cuenta objCuenta = new Cuenta();
            objCuenta = await _objContexto.Cuenta.FindAsync(strNumeroCuenta);
            _objContexto.Cuenta.Remove(objCuenta);
            await _objContexto.SaveChangesAsync();
            return true;
        }

        public async Task<Cuenta> InsertarCuenta(Cuenta objCuenta)
        {
            _objContexto.Cuenta.Add(objCuenta);
            await _objContexto.SaveChangesAsync().ConfigureAwait(true);
            return objCuenta;
        }
    }
}
