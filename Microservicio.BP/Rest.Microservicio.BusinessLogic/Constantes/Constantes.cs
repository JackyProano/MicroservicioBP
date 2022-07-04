using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest.Microservicio.BusinessLogic.Constantes
{
    public static class Constantes
    {
        public const string TipoCtaAhorro = "Ahorro";
        public const string TipoCtaCorriente = "Corriente";
        public const string TipoMovRetiro = "Retiro";
        public const string TipoMovDeposito = "Deposito";

        public const string MsgSaldoNoDisponible = "Saldo no disponible";

        public const decimal decLimiteDiario = 1000;
        public const string MsgLimiteDiario = "Cupo Diario Excedido";

        public const string MsgMovimientoInsertado = "Movimiento insertado correctamente";
    }
}
