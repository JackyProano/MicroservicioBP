using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rest.Microservicio.BusinessLogic.Services.Interfaces;
using Rest.Microservicio.Model.Entidades;
using Rest.Microservicio.Model.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.Microservicio.API.Controllers
{
    [Route("api/Movimientos")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {
        private readonly IMovimientoService _MovimientoService;

        public MovimientoController(IMovimientoService MovimientoService)
        {
            _MovimientoService = MovimientoService;
        }

        [HttpGet]
        [Route("ConsultarMovimientos")]
        public async Task<IEnumerable<Movimiento>> ConsultarMovimientos()
        {
            return await _MovimientoService.ConsultarMovimientos();
        }

        [HttpGet]
        [Route("ConsultarMovimiento")]
        public async Task<Movimiento> ConsultarMovimiento(int intIdMovimiento)
        {
            return await _MovimientoService.ConsultarMovimiento(intIdMovimiento);
        }

        [HttpPost]
        [Route("InsertarMovimiento")]
        public async Task<Resultado> InsertarMovimiento(Movimiento objMovimiento)
        {
            return await _MovimientoService.InsertarMovimiento(objMovimiento);
        }

        [HttpPut]
        [Route("ActualizarMovimiento")]
        public async Task<Movimiento> ActualizarMovimiento(Movimiento objMovimiento)
        {
            return await _MovimientoService.ActualizarMovimiento(objMovimiento);
        }

        [HttpDelete]
        [Route("EliminarMovimiento")]
        public async Task<bool> EliminarMovimiento(int intIdMovimiento)
        {
            return await _MovimientoService.EliminarMovimiento(intIdMovimiento);
        }
    }
}
