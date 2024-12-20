using Negocio.Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class LoginNegocio
    {
        private AccesoDatos accesoDatos = new AccesoDatos();

        public bool ValidarUsuario(string username, string password)
        {
            string consulta = "SELECT COUNT(1) FROM Users WHERE Username = @Username AND Pass = @Pass";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@Pass", password)
            };

            SqlDataReader reader = null;
            try
            {
                reader = accesoDatos.EjecutarLecturaConParametros(consulta, parametros);

                //SI LA LECTURA ESTA ABIERTA Y 
                if (reader.Read() && Convert.ToInt32(reader[0]) > 0)
                {
                    // Usuario válido
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error validando usuario: " + ex.Message);
            }
            finally
            {
                //SI EL READER ES DISTINTO DE NULL Y EL READER ES DISTINTO DE CERRADO CIERRA LA LECTURA
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }
            }

            // FALSO EN CASO DE NO ENCONTRARLO
            return false;
        }
    }
}
