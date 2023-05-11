using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    public class Alumno
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdCurso { get; set; }
        public string NombreCurso { get; set; }
        public int Edad { get; set; }
    }
}
