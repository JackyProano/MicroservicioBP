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
    public class ClienteRepository : IClienteRepository
    {
        private readonly BaseDatosBPContext _objContexto;

        public ClienteRepository(BaseDatosBPContext objContext)
        {
            _objContexto = objContext;
        }

        public async Task<Cliente> ActualizarCliente(Cliente objCliente)
        {
            _objContexto.Entry(objCliente).State = EntityState.Modified;
            await _objContexto.SaveChangesAsync().ConfigureAwait(true);
            return objCliente;
        }

        public async Task<Cliente> ConsultarCliente(int intCliente)
        {
            Cliente objCliente = new Cliente();
            objCliente = await _objContexto.Cliente.FindAsync(intCliente);
            return objCliente;
        }

        public async Task<IEnumerable<Cliente>> ConsultarClientes()
        {
            IEnumerable<Cliente> objClientes = null;
            objClientes = await _objContexto.Cliente.ToListAsync();
            return objClientes;
        }

        public async Task<bool> EliminarCliente(int intCliente)
        {
            Cliente objCliente = new Cliente();
            objCliente = await _objContexto.Cliente.FindAsync(intCliente);
            _objContexto.Cliente.Remove(objCliente);
            await _objContexto.SaveChangesAsync();
            return true;
        }

        public async Task<Cliente> InsertarCliente(Cliente objCliente)
        {
            _objContexto.Cliente.Add(objCliente);
            await _objContexto.SaveChangesAsync().ConfigureAwait(true);
            return objCliente;
        }
    }
}
