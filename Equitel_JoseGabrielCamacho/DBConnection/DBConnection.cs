using System.Data;
using System.Data.SqlClient;

namespace Equitel_JoseGabrielCamacho.DBConnection
{
    public class DBConnection
    {
        //GENERA LA CONEXIÓN A LA BASE DE DATOS - 05/04/2023 GABRIEL CAMACHO
        protected SqlConnection conexion;
        //EJECUTA LA CONSULTA O SCRIPT - 05/04/2023 GABRIEL CAMACHO
        protected SqlCommand comando;
        //TOMA LOS VALORES ALOJADOS EN EL ARCHIVO DE CONFIGURACIÓN APPSETTINGS.JSON - 05/04/2023 GABRIEL CAMACHO
        IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
        //CONSTRUCTOR DE LA CONEXIÓN - 05/04/2023 GABRIEL CAMACHO
        public DBConnection()
        {
            conexion = new SqlConnection(configuration.GetConnectionString("PruebaEquitelJGC"));
        }

        public void abrirConexion()
        {
            try
            {
                conexion.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void cerrarConexion()
        {
            try
            {
                conexion.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CreateCommand(string sql, bool use_store_proc)
        {
            comando = new SqlCommand(sql, conexion);
            comando.CommandType = CommandType.Text;
            if (use_store_proc)
                comando.CommandType = CommandType.StoredProcedure;
        }

        public void AddCmdParameter(string name, object value, ParameterDirection parameterDirection)
        {
            SqlParameter param = new SqlParameter(name, value);
            param.Direction = parameterDirection;
            comando.Parameters.Add(param);
        }

        public DataSet GetDataSet()
        {
            try
            {
                abrirConexion();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comando);
                da.Fill(ds);
                return ds;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                cerrarConexion();
            }
        }

        public int ExecuteNonQuery()
        {
            int respuesta;
            try
            {
                abrirConexion();
                respuesta = comando.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                cerrarConexion();
            }
            return respuesta;
        }

    }
}
