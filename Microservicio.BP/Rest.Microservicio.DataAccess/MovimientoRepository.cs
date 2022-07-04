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
    public class MovimientoRepository : IMovimientoRepository
    {
        private readonly BaseDatosBPContext _objContexto;

        public MovimientoRepository(BaseDatosBPContext objContext)
        {
            _objContexto = objContext;
        }

        public async Task<Movimiento> ActualizarMovimiento(Movimiento objMovimiento)
        {
            _objContexto.Entry(objMovimiento).State = EntityState.Modified;
            await _objContexto.SaveChangesAsync().ConfigureAwait(true);
            return objMovimiento;
        }

        public async Task<Movimiento> ConsultarMovimiento(int intMovimiento)
        {
            Movimiento objMovimiento = new Movimiento();
            objMovimiento = await _objContexto.Movimiento.FindAsync(intMovimiento);
            return objMovimiento;
        }

        public async Task<IEnumerable<Movimiento>> ConsultarMovimientos()
        {
            IEnumerable<Movimiento> objMovimientos = null;
            objMovimientos = await _objContexto.Movimiento.ToListAsync();
            return objMovimientos;
        }

        public async Task<IEnumerable<Movimiento>> ConsultarMovimientosPorCuenta(string strNumeroCuenta)
        {
            IEnumerable<Movimiento> objMovimientos = null;
            objMovimientos = await (from m in _objContexto.Movimiento
                                      join c in _objContexto.Cuenta on m.mo_numero_cuenta equals c.cu_numero
                                      where c.cu_numero.Contains(strNumeroCuenta)
                                      select m).ToListAsync();            
            return objMovimientos;
        }

        public async Task<IEnumerable<Movimiento>> ConsultarTotalMovimientosPorCuentaFecha(string strNumeroCuenta, DateTime dtFecha)
        {
            IEnumerable<Movimiento> objMovimientos = null;
            objMovimientos = await (from m in _objContexto.Movimiento
                                    where m.mo_numero_cuenta.Contains(strNumeroCuenta) && m.mo_fecha == dtFecha
                                    select m).ToListAsync();
            return objMovimientos;
        }

        public async Task<bool> EliminarMovimiento(int intMovimiento)
        {
            Movimiento objMovimiento = new Movimiento();
            objMovimiento = await _objContexto.Movimiento.FindAsync(intMovimiento);
            _objContexto.Movimiento.Remove(objMovimiento);
            await _objContexto.SaveChangesAsync();
            return true;
        }

        public async Task<Movimiento> InsertarMovimiento(Movimiento objMovimiento)
        {
            _objContexto.Movimiento.Add(objMovimiento);
            await _objContexto.SaveChangesAsync().ConfigureAwait(true);
            return objMovimiento;
        }

    }
}
