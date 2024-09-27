using Equitel_JoseGabrielCamacho.Data;
using System.Data;

namespace Equitel_JoseGabrielCamacho.DataAccess
{
    public class DetalleVentaDA : Equitel_JoseGabrielCamacho.DBConnection.DBConnection
    {
        public DataTable SelectTable(DetalleVenta _obj, int Action)
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

        public int InsertOrUpdate(DetalleVenta _obj, int Action)
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

        private void AddParameters(DetalleVenta _obj)
        {
            CreateCommand("SP_DetalleVenta", true);
            AddCmdParameter("@IdDetalleVenta", _obj.IdDetalleVenta, ParameterDirection.Input);
            AddCmdParameter("@IdVenta", _obj.IdVenta, ParameterDirection.Input);
            AddCmdParameter("@IdProducto", _obj.IdProducto, ParameterDirection.Input);
            AddCmdParameter("@CantidadVendida", _obj.CantidadVendida, ParameterDirection.Input);
            AddCmdParameter("@ValorUnitario", _obj.ValorUnitario, ParameterDirection.Input);
        }
    }
}
