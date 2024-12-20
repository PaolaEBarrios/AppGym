using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using Negocio.Negocio;
using System.Drawing;
using System.Diagnostics.Eventing.Reader;
using System.Net;


namespace Negocio
{
    public class ClienteNegocio
    {
        private AccesoDatos accesoDatos = new AccesoDatos(); 


        public ClienteNegocio() { }

        public Cliente buscarClientexDni(string dni)
        {
            
                Cliente cliente = null;

                try
                {
                    string consulta = "select * from Clientes where dni = @dni";

                    SqlParameter[] parametros = {
                            new SqlParameter("@dni", dni)
                    };

                    SqlDataReader reader = accesoDatos.EjecutarLecturaConParametros(consulta, parametros);

                    if (reader.Read())
                    {
                       cliente = new Cliente();

                        cliente.Id = (int)reader["clientesId"];
                        cliente.Name = reader["nombre"].ToString();
                        cliente.LastName = reader["apellido"].ToString();
                        cliente.Dni = reader["dni"].ToString();
                        cliente.Tipo = (int)reader["idmembresia"];
                        cliente.State = (bool)reader["estado"];
                     
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    accesoDatos.CerrarConexion();
                }

                return cliente;
            

        }

        public string activarCliente(Cliente cliente)
        {
            try
            {
                string consulta = "Update Clientes set Estado=@estado where Dni = @dni";

                SqlParameter[] parametros = new SqlParameter[] { 
                
                    new SqlParameter("@estado",true),
                    new SqlParameter("@dni", cliente.Dni)
                };

                int filas = accesoDatos.EjecutarComandoConParametros(consulta, parametros);

                if (filas > 0) {

                    return "Exito, el Cliente con DNI: " + cliente.Dni + " se reactivo";
                }
                else
                {
                    return "Error, el cliente con el  DNI: " + cliente.Dni + " NO PUDO REACTIVARSE";
                }

            }
            catch (Exception ex)
            {

                return "Ocurrio una excepcion: "+ ex.Message;
            }
        }

        public string registrarCliente(string apellido, string dni, string nombre, int tipo)
        {
            
            try
            {

                //buscar si existe el dni en la tabla de clientes 
                //si no existe guardarlo sino mostrar cartel de que existe
                bool bandera =  BuscarDniCliente(dni);


                if (bandera == true)
                {
                    return "El cliente ya existe";
                }
                else
                {
                    string consulta = "INSERT INTO CLIENTES (apellido,dni, nombre, idmembresia, estado) VALUES (@apellido,@dni,@nombre,@tipo,@estado)";

                    SqlParameter[] parametros = {
                        new SqlParameter("@apellido", apellido),
                        new SqlParameter("@nombre", nombre),
                        new SqlParameter("@dni", dni),
                        new SqlParameter("@tipo",tipo),
                        new SqlParameter("@estado",1)
                    };

                   int contador =  accesoDatos.EjecutarComandoConParametros(consulta,parametros);

                    if (contador > 0)
                    {
                        return "Cliente cargado en sistema";
                    }
                    else {

                        return "Error al cargar en sistema";
                    }
                }
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
            finally
            {
                accesoDatos.CerrarConexion();
            }
        }


        public string modificarCliente(Cliente cliente)
        {
            var respuesta = "";

            try
            {



                string consulta = "Update Clientes set  apellido = @apellido, nombre = @nombre, dni =@dni where clientesid = @id";

                SqlParameter[] parametros = new SqlParameter[] {

                    new SqlParameter("@apellido",cliente.LastName),
                    new SqlParameter("@nombre",cliente.Name),
                    new SqlParameter("@dni",cliente.Dni),
                    new SqlParameter("@id",cliente.Id),

                };

                int response = accesoDatos.EjecutarComandoConParametros(consulta, parametros);

                if (response != 0)
                {

                    respuesta = "El cliente se modifico correctamente";

                    return respuesta;
                }

                respuesta = "Error, no se pudo modificar, verificar la conexion a la base de datos";
                return respuesta;
            }
            catch (Exception ex)
            {

                return "Ocurrio una excepcion: " + ex.ToString();
            }
            finally { }
        }

        public string eliminarCliente(Cliente cliente)
        {
            var respuesta = "";

            try
            {



                string consulta = "Update Clientes set estado = @estado where clientesid = @id";

                SqlParameter[] parametros = new SqlParameter[] {

                    new SqlParameter("@estado",false),
                    new SqlParameter("@id",cliente.Id),

                };

                int response = accesoDatos.EjecutarComandoConParametros(consulta, parametros);

                if (response != 0)
                {

                    respuesta = "Exito, al eliminar cliente";

                    return respuesta;
                }

                respuesta = "Error, no se pudo eliminar, verificar la conexion a la base de datos";
                return respuesta;
            }
            catch (Exception ex)
            {

                return "Ocurrio una excepcion: " + ex.ToString();
            }
            finally { }
        }

        public List<Cliente> getClientes()
        {
            SqlDataReader reader = null;
            List<Cliente> listaClientes = new List<Cliente>();

            try
            {
                //accesoDatos.AbrirConexion();

                string consulta = "Select * from Clientes";
                reader = accesoDatos.EjecutarLectura(consulta);

                while (reader.Read())
                {
                    Cliente cliente = new Cliente();

                    cliente.Id = (int)reader["ClientesId"];
                    cliente.Name = reader["Nombre"].ToString();
                    cliente.LastName = reader["Apellido"].ToString();
                    //teacher.userid = (int)reader["userId"];
                    cliente.Dni = reader["DNI"].ToString();
                    cliente.Tipo = (int)reader["idmembresia"];
                    cliente.State = (bool)reader["Estado"];
                    listaClientes.Add(cliente);

                }


                return listaClientes;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                reader?.Close();
                accesoDatos.CerrarConexion();
            }
        }
        public bool BuscarDniCliente(string dni)
        {

            try
            {
                string consulta = "Select count(*) from Clientes where dni = @dni";

                SqlParameter[] parametros = {
                    new SqlParameter("@dni",dni)

                };

                SqlDataReader reader = accesoDatos.EjecutarLecturaConParametros(consulta, parametros);

                if (reader.Read())
                {
                    int count = Convert.ToInt32(reader[0]);
                    if (count > 0) return true;
                }
                reader.Close();
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        
        }

        // obtener los clientes de la base de datos
        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> clientes = new List<Cliente>();



            string consulta = "SELECT ClientesId, Nombre, Apellido, Observacion, Dni, userid, idmembresia FROM CLIENTES";
            SqlDataReader reader = accesoDatos.EjecutarLectura(consulta); //  ejecutar lectura

            try
            {
                
                while (reader != null && reader.Read())
                {

                    Cliente cliente = new Cliente();
                    clientes.Add(cliente);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error obteniendo clientes: " + ex.Message);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close(); // Cerrar el lector; es necesario??
            }

            return clientes;
        }
    }
}
