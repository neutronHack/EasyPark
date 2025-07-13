using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyPark.Backend.Entidad
{
    public class eUsuario
    {
        public int IdUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IdRol { get; set; }
        public bool DebeCambiarClave { get; set; }
    }
}