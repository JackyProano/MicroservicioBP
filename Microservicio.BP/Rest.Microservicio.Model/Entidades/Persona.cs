using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest.Microservicio.Model.Entidades
{
    public class Persona
    {
        public string cl_identificacion { get; set; }
        public string cl_nombre { get; set; }
        public string cl_genero { get; set; }
        public int cl_edad { get; set; }
        public string cl_direccion { get; set; }
        public string cl_telefono { get; set; }
    }
}
