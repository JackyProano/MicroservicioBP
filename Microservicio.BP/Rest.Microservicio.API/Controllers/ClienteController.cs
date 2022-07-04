using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rest.Microservicio.BusinessLogic.Services.Interfaces;
using Rest.Microservicio.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.Microservicio.API.Controllers
{
    [Route("api/Clientes")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        [Route("ConsultarClientes")]
        public async Task<IEnumerable<Cliente>> ConsultarClientes()
        {
            return await _clienteService.ConsultarClientes();
        }

        [HttpGet]
        [Route("ConsultarCliente")]
        public async Task<Cliente> ConsultarCliente(int intIdCliente)
        {
            return await _clienteService.ConsultarCliente(intIdCliente);
        }

        [HttpPost]
        [Route("InsertarCliente")]
        public async Task<Cliente> InsertarCliente(Cliente objCliente)
        {
            return await _clienteService.InsertarCliente(objCliente);
        }

        [HttpPut]
        [Route("ActualizarCliente")]
        public async Task<Cliente> ActualizarCliente(Cliente objCliente)
        {
            return await _clienteService.ActualizarCliente(objCliente);
        }

        [HttpDelete]
        [Route("EliminarCliente")]
        public async Task<bool> EliminarCliente(int intIdCliente)
        {
            return await _clienteService.EliminarCliente(intIdCliente);
        }
    }
}
