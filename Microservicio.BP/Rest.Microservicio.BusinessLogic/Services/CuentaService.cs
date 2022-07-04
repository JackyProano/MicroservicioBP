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
    public class CuentaService : ICuentaService
    {
        private readonly ICuentaRepository _CuentaRepository;

        public CuentaService(ICuentaRepository CuentaRepository)
        {
            _CuentaRepository = CuentaRepository;
        }

        public async Task<Cuenta> ActualizarCuenta(Cuenta objCuenta)
        {
            Cuenta objCuentaResultado = new Cuenta();
            try
            {
                objCuentaResultado = await _CuentaRepository.ActualizarCuenta(objCuenta);
            }
            catch (Exception ex)
            {
                throw;
            }
            return objCuentaResultado;
        }

        public async Task<Cuenta> ConsultarCuenta(string strNumeroCuenta)
        {
            Cuenta objCuenta = null;
            try
            {
                objCuenta = await _CuentaRepository.ConsultarCuenta(strNumeroCuenta);
            }
            catch (Exception ex)
            {
                throw;
            }
            return objCuenta;
        }

        public async Task<IEnumerable<Cuenta>> ConsultarCuentas()
        {
            IEnumerable<Cuenta> objCuentas = null;
            try
            {
                objCuentas = await _CuentaRepository.ConsultarCuentas();
            }
            catch (Exception ex)
            {
                throw;
            }
            return objCuentas;
        }

        public async Task<bool> EliminarCuenta(string strNumeroCuenta)
        {
            bool blnRespuesta;
            try
            {
                blnRespuesta = await _CuentaRepository.EliminarCuenta(strNumeroCuenta);
            }
            catch (Exception ex)
            {
                throw;
            }
            return blnRespuesta;
        }

        public async Task<Cuenta> InsertarCuenta(Cuenta objCuenta)
        {
            Cuenta objCuentaRespuesta = null;
            try
            {
                objCuentaRespuesta = await _CuentaRepository.InsertarCuenta(objCuenta);
            }
            catch (Exception ex)
            {
                throw;
            }
            return objCuentaRespuesta;
        }
    }
}
