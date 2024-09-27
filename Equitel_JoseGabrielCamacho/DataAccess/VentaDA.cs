using Equitel_JoseGabrielCamacho.Data;
using System.Data;

namespace Equitel_JoseGabrielCamacho.DataAccess
{
    public class VentaDA : Equitel_JoseGabrielCamacho.DBConnection.DBConnection
    {
        public DataTable SelectTable(Venta _obj, int Action)
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

        public int InsertOrUpdate(Venta _obj, int Action)
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

        private void AddParameters(Venta _obj)
        {
            CreateCommand("SP_Venta", true);
            AddCmdParameter("@IdVenta", _obj.IdVenta, ParameterDirection.Input);
            AddCmdParameter("@FechaVenta", _obj.FechaVenta, ParameterDirection.Input);
            AddCmdParameter("@IdVendedor", _obj.IdVendedor, ParameterDirection.Input);
            AddCmdParameter("@TotalVenta", _obj.TotalVenta, ParameterDirection.Input);
        }
    }
}
