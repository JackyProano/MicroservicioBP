using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest.Microservicio.Model.Entidades
{
    public partial class Movimiento
    {
        [Key]
        public int mo_id_movimiento { get; set; }
        public string mo_numero_cuenta { get; set; }
        public DateTime mo_fecha { get; set; }
        public string mo_tipo { get; set; }
        public decimal mo_saldo_inicial { get; set; }
        public decimal mo_valor { get; set; }
        public decimal mo_saldo { get; set; }
    
    }
}
