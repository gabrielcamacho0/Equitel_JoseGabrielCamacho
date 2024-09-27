using Equitel_JoseGabrielCamacho.Data;
using System.Data;

namespace Equitel_JoseGabrielCamacho.DataAccess
{
    public class ProductoDA : Equitel_JoseGabrielCamacho.DBConnection.DBConnection
    {
        public DataTable SelectTable(Producto _obj, int Action)
        {
            DataTable dt = new DataTable();
            try
            {
                AddParameters(_obj);
                AddCmdParameter("@Action", Action, ParameterDirection.Input);
                dt = GetDataSet().Tables[0];
            }
            catch (Exception e)
            {
                throw e;
            }
            return dt;
        }

        public int InsertOrUpdate(Producto _obj, int Action)
        {
            int i;
            try
            {
                AddParameters(_obj);
                AddCmdParameter("@Action", Action, ParameterDirection.Input);
                ExecuteNonQuery();
                i = 1;
            }
            catch (Exception e)
            {
                i = -1;
                throw e;
            }
            return i;
        }

        private void AddParameters(Producto _obj)
        {
            CreateCommand("SP_Producto", true);
            AddCmdParameter("@IdProducto", _obj.IdProducto, ParameterDirection.Input);
            AddCmdParameter("@NombreProducto", _obj.NombreProducto, ParameterDirection.Input);
            AddCmdParameter("@DescripcionProducto", _obj.DescripcionProducto, ParameterDirection.Input);
            AddCmdParameter("@ModeloProducto", _obj.ModeloProducto, ParameterDirection.Input);
            AddCmdParameter("@ValorProducto", _obj.ValorProducto, ParameterDirection.Input);
            AddCmdParameter("@IdProveedor", _obj.IdProveedor, ParameterDirection.Input);
            AddCmdParameter("@Estado", _obj.Estado, ParameterDirection.Input);
            AddCmdParameter("@CantidadProducto", _obj.CantidadProducto, ParameterDirection.Input);
        }
    }
}
