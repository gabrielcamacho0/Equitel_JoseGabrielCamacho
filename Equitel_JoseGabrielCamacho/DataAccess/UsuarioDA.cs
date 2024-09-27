using Equitel_JoseGabrielCamacho.Data;
using System.Data;


namespace Equitel_JoseGabrielCamacho.DataAccess
{
    public class UsuarioDA : Equitel_JoseGabrielCamacho.DBConnection.DBConnection
    {
        public DataTable SelectTable(Usuario _obj, int Action)
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

        public int InsertOrUpdate(Usuario _obj, int Action)
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

        private void AddParameters(Usuario _obj)
        {
            CreateCommand("SP_Usuario", true);
            AddCmdParameter("@IdUsuario", _obj.IdUsuario, ParameterDirection.Input);
            AddCmdParameter("@NombreUsuario", _obj.NombreUsuario, ParameterDirection.Input);
            AddCmdParameter("@Logueo", _obj.Logueo, ParameterDirection.Input);
            AddCmdParameter("@Clave", _obj.Clave, ParameterDirection.Input);
            AddCmdParameter("@Rol", _obj.Rol, ParameterDirection.Input);
            AddCmdParameter("@Estado", _obj.Estado, ParameterDirection.Input);
        }
    }
}
