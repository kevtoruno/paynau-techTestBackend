using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class GetPersonaDto
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string PaisOrigen { get; set; }
        public string CiudadOrigen { get; set; }
        public string Direccion { get; set; }
        public string FechaNacimiento { get; set; }
        public string EstadoCivil { get; set; }
    }
}
