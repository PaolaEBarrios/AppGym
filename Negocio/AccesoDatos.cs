using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    using System;
    using System.Data.SqlClient;

    namespace Negocio
    {
        public class AccesoDatos
        {
            //Se define en un string la conexion a la base de datos - no recuerdo el ./ algo asi
            private string connectionString = "Server=DESKTOP-DAPQT6K\\SQLEXPRESS;Database=APPGYMFINAL;Trusted_Connection=True;";
            //Definimos una propiedad Conexion
            private SqlConnection conexion; 

            //Metodo sqlConnection llamado conexion que se encarga de crear una conexion
            public SqlConnection Conexion
            {
                get
                {
                    //metodo get que pregunta si la conexion es null crea un conexion y retorna
                    if (conexion == null)
                    {

                        conexion = new SqlConnection(connectionString);
                    }
                    return conexion;
                }
            }

            //Metodo que pregunta si el estado de la conexion si esta cerrada abre la conexion
            public void AbrirConexion()
            {
                if (Conexion.State == System.Data.ConnectionState.Closed)
                {
                    Conexion.Open();
                }
            }

            //Metodo inverso a Abrir conexion - si el estado de Conexion es Open - cierra la conexion
            public void CerrarConexion()
            {
                if (Conexion.State == System.Data.ConnectionState.Open)
                {
                    Conexion.Close();
                }
            }

            //INVESTIGAR EL USO DE USING


            //Metodo que ejecuta un comando en sql server y devuelve el numero de filas - delete update etc
            public int EjecutarComando(string consulta)
            {
                SqlCommand command = new SqlCommand(consulta, Conexion);
                int filasAfectadas = 0;

                try
                {
                    AbrirConexion();
                    filasAfectadas = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error ejecutando comando: " + ex.Message);
                }
                finally
                {
                    CerrarConexion();
                }

                return filasAfectadas;
            }

            // Metodo similar al anterior solo que Ejecuta un comando utilizando parametros Insert, update y delete
            //recibe la consulta, y un array de parametros sqlparameter
            public int EjecutarComandoConParametros(string consulta, SqlParameter[] parametros)
            {
                //Se define el comando 
                SqlCommand command = new SqlCommand(consulta, Conexion);
                int filasAfectadas = 0;


                try
                {

                    AbrirConexion();

                    //Agrega los parametros dentro del command se utiliza llamando a los nombres con @
                    command.Parameters.AddRange(parametros);

                    filasAfectadas = command.ExecuteNonQuery();


                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error ejecutando comando con parametros: " + ex.Message);
                }
                finally
                {
                    CerrarConexion();
                }

                return filasAfectadas;
            }


            public SqlDataReader EjecutarLectura(string consulta)
            {
                //Se crea una variable de sqlcomand para ejecutar las consulta - se le pasa la consulta mas la conexion
                SqlCommand command = new SqlCommand(consulta, Conexion);

                //se define un sqldatareader  un lector con valor null
                SqlDataReader reader = null;

                try
                {
                    //se abre la conexion
                    AbrirConexion();
                    //el lector es el valor de command de la respuesta de ExecuteReader  ademas se cierra la conexion 
                    reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error ejecutando lectura: " + ex.Message);
                    CerrarConexion();
                }

                //retorna el lector
                return reader;
            }

            // Metodo similar al anterior solo que Ejecuta un comando para lectura utilizando parametros solo SELECT 
            //recibe la consulta, y un array de parametros sqlparameter
            public SqlDataReader EjecutarLecturaConParametros(string consulta, SqlParameter[] parametros)
            {
                SqlCommand command = new SqlCommand(consulta, Conexion);

                SqlDataReader reader = null;

                try
                {
                    
                    //logica

                    command.Parameters.AddRange(parametros);
                    

                    AbrirConexion(); 
                    reader = command.ExecuteReader(CommandBehavior.CloseConnection); 


                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error ejecutando lectura con parámetros: " + ex.Message);
                    CerrarConexion(); 
                }
                finally {

                    
                    
                }

                return reader; 
            }


            //Ejecuta una lectura devolviendo el valor de la primera columna solo usar con count
            public int EjecutarEscalarConParametros(string consulta, SqlParameter[] parametros)
            {
                SqlCommand command = new SqlCommand(consulta, Conexion);

                try
                {
                    command.Parameters.AddRange(parametros);
                    AbrirConexion();
                    return Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error ejecutando consulta escalar con parámetros: " + ex.Message);
                    return 0;
                }
                finally
                {
                    CerrarConexion();
                }
            }



        }

    }


}



