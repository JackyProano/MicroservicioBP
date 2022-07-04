using Rest.Microservicio.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest.Microservicio.Model.Repository
{
    public interface ICuentaRepository
    {
        Task<IEnumerable<Cuenta>> ConsultarCuentas();
        Task<Cuenta> ConsultarCuenta(string strNumeroCuenta);
        Task<Cuenta> InsertarCuenta(Cuenta objCuenta);
        Task<Cuenta> ActualizarCuenta(Cuenta objCuenta);
        Task<bool> EliminarCuenta(string strNumeroCuenta);
    }
}
