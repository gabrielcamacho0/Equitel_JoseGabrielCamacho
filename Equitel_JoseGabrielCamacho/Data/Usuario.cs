using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Equitel_JoseGabrielCamacho.Data
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = "";
        public string Logueo { get; set; } = "";
        public string Clave{ get; set; } = "";
        public int Rol { get; set; }
        public bool Estado { get; set; }
    }
}
