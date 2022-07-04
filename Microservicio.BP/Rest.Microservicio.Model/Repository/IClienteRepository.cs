using Rest.Microservicio.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest.Microservicio.Model.Repository
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> ConsultarClientes();
        Task<Cliente> ConsultarCliente(int intCliente);
        Task<Cliente> InsertarCliente(Cliente objCliente);
        Task<Cliente> ActualizarCliente(Cliente objCliente);
        Task<bool> EliminarCliente(int intCliente);
    }
}
