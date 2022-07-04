using Rest.Microservicio.BusinessLogic.Services.Interfaces;
using Rest.Microservicio.Model.Entidades;
using Rest.Microservicio.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest.Microservicio.BusinessLogic.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente> ActualizarCliente(Cliente objCliente)
        {
            Cliente objClienteResultado = new Cliente();
            try
            {
                objClienteResultado = await _clienteRepository.ActualizarCliente(objCliente);
            }
            catch (Exception ex)
            {
                throw;
            }
            return objClienteResultado;
        }

        public async Task<Cliente> ConsultarCliente(int intCliente)
        {
            Cliente objCliente = null;
            try
            {
                objCliente = await _clienteRepository.ConsultarCliente(intCliente);
            }
            catch (Exception ex)
            {
                throw;
            }
            return objCliente;
        }

        public async Task<IEnumerable<Cliente>> ConsultarClientes()
        {
            IEnumerable<Cliente> objClientes = null;
            try
            {
                objClientes = await _clienteRepository.ConsultarClientes();
            }
            catch (Exception ex)
            {
                throw;
            }
            return objClientes;
        }

        public async Task<bool> EliminarCliente(int intCliente)
        {
            bool blnRespuesta;
            try
            {
                blnRespuesta = await _clienteRepository.EliminarCliente(intCliente);
            }
            catch (Exception ex)
            {
                throw;
            }
            return blnRespuesta;
        }

        public async Task<Cliente> InsertarCliente(Cliente objCliente)
        {
            Cliente objClienteRespuesta = null;
            try
            {
                objClienteRespuesta = await _clienteRepository.InsertarCliente(objCliente);
            }
            catch (Exception ex)
            {
                throw;
            }
            return objClienteRespuesta;
        }
    }
}
