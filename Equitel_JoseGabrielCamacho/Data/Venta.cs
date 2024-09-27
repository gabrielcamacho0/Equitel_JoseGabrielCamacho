namespace Equitel_JoseGabrielCamacho.Data
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public DateTime FechaVenta { get; set; }
        public int IdVendedor { get; set; }
        public decimal TotalVenta { get; set; }
    }
}
