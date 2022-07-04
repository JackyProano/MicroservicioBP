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
    [Route("api/Cuentas")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly ICuentaService _CuentaService;

        public CuentaController(ICuentaService CuentaService)
        {
            _CuentaService = CuentaService;
        }

        [HttpGet]
        [Route("ConsultarCuentas")]
        public async Task<IEnumerable<Cuenta>> ConsultarCuentas()
        {
            return await _CuentaService.ConsultarCuentas();
        }

        [HttpGet]
        [Route("ConsultarCuenta")]
        public async Task<Cuenta> ConsultarCuenta(string strNumeroCuenta)
        {
            return await _CuentaService.ConsultarCuenta(strNumeroCuenta);
        }

        [HttpPost]
        [Route("InsertarCuenta")]
        public async Task<Cuenta> InsertarCuenta(Cuenta objCuenta)
        {
            return await _CuentaService.InsertarCuenta(objCuenta);
        }

        [HttpPut]
        [Route("ActualizarCuenta")]
        public async Task<Cuenta> ActualizarCuenta(Cuenta objCuenta)
        {
            return await _CuentaService.ActualizarCuenta(objCuenta);
        }

        [HttpDelete]
        [Route("EliminarCuenta")]
        public async Task<bool> EliminarCuenta(string strNumeroCuenta)
        {
            return await _CuentaService.EliminarCuenta(strNumeroCuenta);
        }
    }
}
