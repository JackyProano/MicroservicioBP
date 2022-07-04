using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest.Microservicio.Model.Entidades
{
    public partial class Cliente : Persona
    {
        [Key]
        public int cl_id_cliente { get; set; }
        public string cl_contrasenia { get; set; }
        public bool cl_estado { get; set; }
    }
}
