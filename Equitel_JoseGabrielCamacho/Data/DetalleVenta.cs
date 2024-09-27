namespace Equitel_JoseGabrielCamacho.Data
{
    public class DetalleVenta
    {
        public int IdDetalleVenta { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public int CantidadVendida { get; set; }
        public decimal ValorUnitario { get; set; }
    }
}
