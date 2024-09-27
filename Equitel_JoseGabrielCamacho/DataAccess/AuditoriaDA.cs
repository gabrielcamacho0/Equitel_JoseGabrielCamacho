using Equitel_JoseGabrielCamacho.Data;
using System.Data;

namespace Equitel_JoseGabrielCamacho.DataAccess
{
    public class AuditoriaDA : Equitel_JoseGabrielCamacho.DBConnection.DBConnection
    {
        public DataTable SelectTable(Auditoria _obj, int Action)
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

        public int InsertOrUpdate(Auditoria _obj, int Action)
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

        private void AddParameters(Auditoria _obj)
        {
            CreateCommand("SP_Auditoria", true);
            AddCmdParameter("@IdAuditoria", _obj.IdAuditoria, ParameterDirection.Input);
            AddCmdParameter("@Fecha", _obj.Fecha, ParameterDirection.Input);
            AddCmdParameter("@IdUsuario", _obj.IdUsuario, ParameterDirection.Input);
            AddCmdParameter("@Accion", _obj.Accion, ParameterDirection.Input);
        }
    }
}
