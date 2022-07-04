using Rest.Microservicio.Model.Entidades;
using Rest.Microservicio.Model.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest.Microservicio.BusinessLogic.Services.Interfaces
{
    public interface IMovimientoService
    {
        Task<IEnumerable<Movimiento>> ConsultarMovimientos();
        Task<Movimiento> ConsultarMovimiento(int intMovimiento);
        Task<Resultado> InsertarMovimiento(Movimiento objMovimiento);
        Task<Movimiento> ActualizarMovimiento(Movimiento objMovimiento);
        Task<bool> EliminarMovimiento(int intMovimiento);
    }
}
