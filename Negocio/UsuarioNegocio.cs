using Dominio;
using Negocio.Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuarioNegocio
    {

        public UsuarioNegocio()
        {

        }

        public int activarUsuario(string dni) {

            AccesoDatos acceso = new AccesoDatos();
            try
            {
                //enviar los datos como parametros para modificar

                string consulta = "Update users set Estado=@estado where dni=@dni";

                SqlParameter[] parametros = new SqlParameter[]{


                    new SqlParameter("@dni",dni),

                    new SqlParameter("@estado",true),

                };

                int filas = acceso.EjecutarComandoConParametros(consulta, parametros);

                if (filas > 0) return 1;

                return 0;
            }
            catch (Exception e)
            {
                return -1;
            }
            finally { }
        }
        public string cambiarPassword(Usuario usuario, string passNuevo)
        {
            AccesoDatos acceso = new AccesoDatos();
            try
            {
                //enviar los datos como parametros para modificar

                string consulta = "Update users set pass=@pass where userid=@idUser";

                SqlParameter[] parametros = new SqlParameter[]{


                    new SqlParameter("@pass",passNuevo),

                    new SqlParameter("@idUser",usuario.Id),

                };

                int filas = acceso.EjecutarComandoConParametros(consulta, parametros);

                if (filas > 0) return "Exito al modificar la contraseña";

                return "No se pudo modificar la contraseña";
            }
            catch (Exception e)
            {
                return "Ocurrio una excepcion " + e.Message;
            }
            finally { }
        }


        public int getUserIdxDni(string dni)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            
            

            try
            {
                string consulta = "Select userId from users where dni = @dni";


                SqlParameter[] parametros = new SqlParameter[]{
                    new SqlParameter("@dni", dni),
                };


               int resultado = accesoDatos.EjecutarEscalarConParametros(consulta, parametros);

               return resultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }
        public Usuario getUsuarioXuserName(string username) {

            Usuario usuario = new Usuario();
            AccesoDatos acceso = new AccesoDatos();
            SqlDataReader  reader = null;


            try
            {



                string consulta = "Select * from users where username=@username";


                SqlParameter[] parametros = new SqlParameter[]{

                    new SqlParameter("@username", username),

                };

                reader = acceso.EjecutarLecturaConParametros(consulta, parametros);

                if (reader.HasRows) //se pregunta si el lector tiene filas
                {

                    reader.Read();

                    usuario.Id = (int)reader["userid"];
                    usuario.Phone = reader["phone"].ToString();
                    usuario.Email = reader["email"].ToString();
                    usuario.State = (bool)reader["estado"];
                    usuario.UserName = reader["username"].ToString();
                    usuario.tipo = (int)reader["tipo"];
                    usuario.Dni = reader["dni"].ToString();
                    usuario.Password = reader["pass"].ToString();

                    return usuario;

                }


                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { }
        
        }
        public string registrarUsuario(Usuario usuario)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            string mensaje = "";
            //verificar si el usuario que quiero cargar ya esta registrado

            try
            {
                string consultarUser = "SELECT COUNT(*) FROM Users WHERE Username = @Username OR DNI = @Dni";
                SqlParameter[] parametersVerificacion = new SqlParameter[]
                {
                    new SqlParameter("@Username", usuario.UserName),
                    new SqlParameter("@DNI", usuario.Dni)
                };

                int resultado = accesoDatos.EjecutarEscalarConParametros(consultarUser, parametersVerificacion);

                if (resultado > 0)
                {
                    return "El nombre de usuario o DNI ya están registrados.";
                }
                //INSERT INTO productos (nombre, precio, stock) VALUES('Nuevo Producto', 19.99, 100);
                string consulta = "INSERT INTO Users (Username, Pass, Tipo, Email, Phone, Estado, DNI) VALUES (@Username, @Pass, @tipo, '', '', 1, @DNI)";

                SqlParameter[] parameters = new SqlParameter[] {

                    new SqlParameter("@Username", usuario.UserName),
                    new SqlParameter("@Pass", usuario.Password),
                    new SqlParameter("@DNI", usuario.Dni),
                    new SqlParameter("@Tipo", usuario.tipo),

                };


                int valor = accesoDatos.EjecutarComandoConParametros(consulta, parameters);

                if (valor == 0)
                {
                    mensaje = "Error, no pudo añadirse el usuario, fallo el metodo ejecutarComandoConParametro";
                    return mensaje;
                }
                else
                {
                    mensaje = "Se registro el usuario correctamente";
                    return mensaje;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                accesoDatos.CerrarConexion();
            }

        }

       


        public List<Usuario> getUsuarios()
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            List<Usuario> listaUsuario = new List<Usuario>();

            SqlDataReader lector = null;

            try
            {
                


                string consulta = "SELECT * FROM Users";
                lector = accesoDatos.EjecutarLectura(consulta);

                while (lector.Read())
                {
                    Usuario usuario = new Usuario();

                    usuario.Dni = lector["DNI"].ToString();
                    usuario.Id = (int)lector["userid"];
                    usuario.UserName = lector["username"].ToString();
                    usuario.Password = lector["pass"].ToString();
                    usuario.State = (bool)lector["estado"];
                    usuario.Phone = lector["phone"].ToString();
                    usuario.tipo = (int)lector["tipo"];

                    listaUsuario.Add(usuario);
                }

                return listaUsuario;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (lector != null && !lector.IsClosed)
                {
                    lector.Close();
                }
                accesoDatos.CerrarConexion();
            }
       
        }
        public Usuario getUsuarioPorDNI(string dni)
        {
            AccesoDatos acceso = new AccesoDatos();
            Usuario usuario = new Usuario();
            SqlDataReader reader = null;

            try
            {
                

                string consulta = "Select * from users where dni=@dni";


                SqlParameter[] parametros= new SqlParameter[]{
                    
                    new SqlParameter("@dni", dni),
                    
                };

                reader = acceso.EjecutarLecturaConParametros(consulta, parametros);

                if (reader.HasRows) //se pregunta si el lector tiene filas
                {

                    reader.Read();

                    usuario.Id = (int)reader["userid"];
                    usuario.Phone = reader["phone"].ToString();
                    usuario.Email = reader["email"].ToString();
                    usuario.State = (bool)reader["estado"];
                    usuario.UserName = reader["username"].ToString();
                    usuario.tipo = (int)reader["tipo"];
                    usuario.Dni = reader["dni"].ToString();
                    usuario.Password = reader["pass"].ToString();

                    return usuario;

                }


                return null;
                    
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }
                acceso.CerrarConexion();
            }
        }


        public Usuario getUsuarioPorID(string id)
        {
            AccesoDatos acceso = new AccesoDatos();
            Usuario usuario = new Usuario();
            SqlDataReader reader = null;

            try
            {

                string consulta = "Select * from users where userid=@id";


                SqlParameter[] parametros = new SqlParameter[]{

                    new SqlParameter("@id", id),

                };

                reader = acceso.EjecutarLecturaConParametros(consulta, parametros);

                if (reader.HasRows) //se pregunta si el lector tiene filas
                {

                    reader.Read();

                    usuario.Id = (int)reader["userid"];
                    usuario.Phone = reader["phone"].ToString();
                    usuario.Email = reader["email"].ToString();
                    usuario.State = (bool)reader["estado"];
                    usuario.UserName = reader["username"].ToString();
                    usuario.tipo = (int)reader["tipo"];
                    usuario.Dni = reader["dni"].ToString();
                    usuario.Password = reader["pass"].ToString();

                    return usuario;

                }


                return null;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }
                acceso.CerrarConexion();
            }
        }

        //public int obtenerID(string dni)
        //{

        //}


        public string modificarUsuario(Usuario user)
        {
            AccesoDatos acceso = new AccesoDatos();
            try
            {
                //enviar los datos como parametros para modificar

                string consulta = "Update users set dni=@dni,username=@username,pass=@pass,tipo=@tipo where userid=@idUser";

                SqlParameter[] parametros = new SqlParameter[]{
                    
                    new SqlParameter("@dni",user.Dni),
                    new SqlParameter("@username",user.UserName),
                    new SqlParameter("@pass",user.Password),
                    new SqlParameter("@tipo",user.tipo),
                    new SqlParameter("@idUser",user.Id),
                
                };

                int filas= acceso.EjecutarComandoConParametros(consulta,parametros);

                if (filas > 0)  return "Modificacion cargada en sistema con exito";

                return "No se pudo modificar el usuario";
            }
            catch (Exception e) { 
                throw e;
            }
            finally { }

        }

        public string EliminarUsuario(Usuario user)
        {
            AccesoDatos acceso = new AccesoDatos();
            try
            {
                //enviar los datos como parametros para modificar

                string consulta = "Update Users set Estado=@estado where UserId=@id";

                SqlParameter[] parametros = new SqlParameter[]{

                    new SqlParameter("@estado",false),
                    
                    new SqlParameter("@id",user.Id),

                };

                int filas = acceso.EjecutarComandoConParametros(consulta, parametros);

                if (filas > 0) return "Se elimino el usuario con exito";

                return "No se pudo Eliminar el usuario";
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { }
        }


    }
}
