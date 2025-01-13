using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonaTest
{
    public static class PersonaDataTest
    {
        public static int Id { get; set; } = 0;
        public static string Nombres { get; set; } = "Pedro";
        public static string Apellidos { get; set; } = "Martinez";
        public static string Telefono { get; set; } = "88965542";
        public static string PaisOrigen { get; set; } = "Nicaragua";
        public static string CiudadOrigen { get; set; } = "Estelí";
        public static string Direccion { get; set; } = "Bello Horizonte";
        public static DateTime FechaNacimiento { get; set; } = new DateTime(1990, 10, 20);
    }
}
