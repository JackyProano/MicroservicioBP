using Rest.Microservicio.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest.Microservicio.Model.Repository
{
    public interface IMovimientoRepository
    {
        Task<IEnumerable<Movimiento>> ConsultarMovimientos();
        Task<Movimiento> ConsultarMovimiento(int intMovimiento);
        Task<IEnumerable<Movimiento>> ConsultarMovimientosPorCuenta(string strCuenta);
        Task<IEnumerable<Movimiento>> ConsultarTotalMovimientosPorCuentaFecha(string strCuenta, DateTime dtFecha);
        Task<Movimiento> InsertarMovimiento(Movimiento objMovimiento);
        Task<Movimiento> ActualizarMovimiento(Movimiento objMovimiento);
        Task<bool> EliminarMovimiento(int intMovimiento);
    }
}
