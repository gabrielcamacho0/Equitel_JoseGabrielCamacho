namespace Equitel_JoseGabrielCamacho.Data
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; } = "";
        public string DescripcionProducto { get; set; } = "";
        public int ModeloProducto { get; set; }
        public decimal ValorProducto { get; set; }
        public int IdProveedor { get; set; }
        public bool Estado { get; set; }
        public int CantidadProducto { get; set; }
    }
}
