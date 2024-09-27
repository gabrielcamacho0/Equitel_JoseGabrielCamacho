namespace Equitel_JoseGabrielCamacho.Data
{
    public class Auditoria
    {
        public int IdAuditoria { get; set; }
        public DateTime Fecha { get; set; }
        public int IdUsuario { get; set; }
        public string Accion { get; set; } = "";
    }
}
