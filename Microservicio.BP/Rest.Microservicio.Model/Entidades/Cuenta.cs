using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest.Microservicio.Model.Entidades
{
    public partial class Cuenta
    {
        [Key]
        public string cu_numero { get; set; }
        public int cu_id_cliente { get; set; }
        public string cu_tipo { get; set; }
        public decimal cu_saldo { get; set; }
        public bool cu_estado { get; set; }
    }
}
