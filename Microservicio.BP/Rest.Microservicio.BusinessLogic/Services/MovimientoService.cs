using Rest.Microservicio.BusinessLogic.Services.Interfaces;
using Rest.Microservicio.Model.Entidades;
using Rest.Microservicio.Model.Utilitarios;
using Rest.Microservicio.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest.Microservicio.BusinessLogic.Services
{
    public class MovimientoService : IMovimientoService
    {
        private readonly IMovimientoRepository _MovimientoRepository;
        private readonly ICuentaRepository _CuentaRepository;

        public MovimientoService(IMovimientoRepository movimientoRepository, ICuentaRepository cuentaRepository)
        {
            _MovimientoRepository = movimientoRepository;
            _CuentaRepository = cuentaRepository;
        }

        public async Task<Movimiento> ActualizarMovimiento(Movimiento objMovimiento)
        {
            Movimiento objMovimientoResultado = new Movimiento();
            try
            {
                objMovimientoResultado = await _MovimientoRepository.ActualizarMovimiento(objMovimiento);
            }
            catch (Exception ex)
            {
                throw;
            }
            return objMovimientoResultado;
        }

        public async Task<Movimiento> ConsultarMovimiento(int intMovimiento)
        {
            Movimiento objMovimiento = null;
            try
            {
                objMovimiento = await _MovimientoRepository.ConsultarMovimiento(intMovimiento);
            }
            catch (Exception ex)
            {
                throw;
            }
            return objMovimiento;
        }

        public async Task<IEnumerable<Movimiento>> ConsultarMovimientos()
        {
            IEnumerable<Movimiento> objMovimientos = null;
            try
            {
                objMovimientos = await _MovimientoRepository.ConsultarMovimientos();
            }
            catch (Exception ex)
            {
                throw;
            }
            return objMovimientos;
        }

        public async Task<bool> EliminarMovimiento(int intMovimiento)
        {
            bool blnRespuesta;
            try
            {
                blnRespuesta = await _MovimientoRepository.EliminarMovimiento(intMovimiento);
            }
            catch (Exception ex)
            {
                throw;
            }
            return blnRespuesta;
        }

        public async Task<Resultado> InsertarMovimiento(Movimiento objMovimiento)
        {
            Movimiento objMovimientoRespuesta = new Movimiento();
            IEnumerable<Movimiento> objMovimientosPorFecha = null;
            Resultado resultadoInsercion = new Resultado();
            decimal decSaldoActual;
            try
            {
                Cuenta objCuenta = await _CuentaRepository.ConsultarCuenta(objMovimiento.mo_numero_cuenta);
                if (objMovimiento.mo_tipo == Constantes.Constantes.TipoMovRetiro)
                {
                    if (objCuenta.cu_saldo < objMovimiento.mo_valor)
                    {
                        resultadoInsercion.Respuesta = Constantes.Constantes.MsgSaldoNoDisponible;
                        return resultadoInsercion;
                    }
                    decSaldoActual = objCuenta.cu_saldo - objMovimiento.mo_valor;
                }
                else
                    decSaldoActual = objCuenta.cu_saldo + objMovimiento.mo_valor;

                objMovimientosPorFecha = await _MovimientoRepository.ConsultarTotalMovimientosPorCuentaFecha(objMovimiento.mo_numero_cuenta, objMovimiento.mo_fecha);

                if(objMovimientosPorFecha.Sum(x => x.mo_valor) >= Constantes.Constantes.decLimiteDiario)
                {
                    resultadoInsercion.Respuesta = Constantes.Constantes.MsgLimiteDiario;
                    return resultadoInsercion;
                }

                objMovimiento.mo_saldo_inicial = objCuenta.cu_saldo;
                objMovimiento.mo_saldo = decSaldoActual;
                objMovimientoRespuesta = await _MovimientoRepository.InsertarMovimiento(objMovimiento);
                objCuenta.cu_saldo = decSaldoActual;
                objCuenta = await _CuentaRepository.ActualizarCuenta(objCuenta);
                resultadoInsercion.Respuesta = Constantes.Constantes.MsgMovimientoInsertado;

            }
            catch (Exception ex)
            {
                throw;
            }
            return resultadoInsercion;
        }

    }
}
