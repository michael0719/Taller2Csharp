using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Modelo
{
    public class Datos
    {

        #region Declaración de variables
        SqlConnection cnnConexion = null;
        SqlCommand cmdComando = null;
        SqlDataAdapter daAdaptador = null;
        DataTable Dtt = null;
        String strConexion = string.Empty;
        #endregion

        #region Constructor
        public Datos()
        {
            strConexion = @"Data Source=SALA403-1\SQLEXPRESS;Initial Catalog=DBColegio;Integrated Security=True";
        }
        #endregion

        #region Métodos a ejecutar

        public void EjecutarSP(SqlParameter[] Parametros, string pasComando)
        {
            try
            {
                cnnConexion = new SqlConnection(strConexion);
                cmdComando = new SqlCommand();
                cmdComando.Connection = cnnConexion;
                cnnConexion.Open();
                cmdComando.CommandType = CommandType.StoredProcedure;
                cmdComando.CommandText = pasComando;
                cmdComando.Parameters.AddRange(Parametros);
                cmdComando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                cnnConexion.Dispose();
                cmdComando.Dispose();
            }

        }

        public DataTable RetornaTabla(SqlParameter[] Parametros, string parTSQL)
        {
            Dtt = null;
            try
            {
                Dtt = new DataTable();
                cnnConexion = new SqlConnection(strConexion);
                cmdComando = new SqlCommand();
                cmdComando.Connection = cnnConexion;
                cmdComando.CommandType = CommandType.StoredProcedure;
                cmdComando.CommandText = parTSQL;
                cmdComando.Parameters.AddRange(Parametros);

                daAdaptador = new SqlDataAdapter(cmdComando);
                daAdaptador.Fill(Dtt);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                cnnConexion.Dispose();
                cmdComando.Dispose();
                daAdaptador.Dispose();
            }

            return Dtt;

        }

        #endregion

    }
}
