using Dominio;
using Negocio.Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class InstructorNegocio
    {
        public InstructorNegocio() { }

        AccesoDatos accesoDatos = new AccesoDatos();

        public int getIdInstructorXIdUsuario(int id)
        {
            
            SqlDataReader reader = null;
            int instructorId = -1; // Default if not found

            try
            {
                string consulta = "select InstructorId from Instructors where userId = @Id";
                SqlParameter[] parametros = new SqlParameter[]
                {
                     new SqlParameter("@Id", id)
                };

                reader = accesoDatos.EjecutarLecturaConParametros(consulta, parametros);

                if (reader != null && reader.Read())
                {
                    instructorId = (int)reader["InstructorId"];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar el InstructorId: " + ex.Message);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }
                accesoDatos.CerrarConexion();
            }

            return instructorId;
        }
        public string activarInstructor(Teacher teacher)
        {
            try
            {
                //Al activar el instructor se activa el usuario del mismo y viceversa
                string consulta = "Update Instructors set Estado=@estado where InstructorId=@id";

                SqlParameter[] parametros = new SqlParameter[] { 
                
                    new SqlParameter("@estado",true),
                    new SqlParameter("@id",teacher.Id),
                
                };

                int filas = accesoDatos.EjecutarComandoConParametros(consulta, parametros);
                ////////////////////////////////////////////////////////////////////////////7
                //////////////////////////////////////////////////////////////
                UsuarioNegocio negocio = new UsuarioNegocio();

                int filasUsuarios = negocio.activarUsuario(teacher.Dni);
                

                if (filas > 0 && filasUsuarios > 0) { 
                
                    return "Exito, se activo el instructor y su usuario con DNI: "+ teacher.Dni;
                
                }
                else
                {

                    return "Ocurrio un error al intentar activar el instructor";
                }
            }
            catch (Exception ex)
            {

                return "Ocurrio una excepcion: " + ex.Message;
            }
        }
        public bool actualizarUserId(int userid, string dni)
        {
            bool respuesta = false;

            try
            {
                string consulta = "Update Instructors set  userid = @userId where dni = @dni";

                SqlParameter[] parametros = new SqlParameter[] {
                    new SqlParameter("@dni",dni),
                    new SqlParameter("@userid",userid),
                };

                int response = accesoDatos.EjecutarComandoConParametros(consulta, parametros);

                if (response != 0) {

                    respuesta = true;

                    return respuesta;
                }

                
                return respuesta;
            }
            catch (Exception ex)
            {

                return false;
            }
            finally { }

        }
        public Teacher getInstructorXdni(string dni)
        {
            SqlDataReader reader = null;
            Teacher teacher = new Teacher();

            try
            {

                string consulta = "Select * From Instructors where dni  = @dni";

                SqlParameter[] parametros = new SqlParameter[] {

                    new SqlParameter("@dni",dni)

                };


                reader = accesoDatos.EjecutarLecturaConParametros(consulta, parametros);


                if (reader.HasRows)
                {
                    reader.Read();

                    teacher.detalle = reader["detalles"].ToString();
                    teacher.Dni = reader["DNI"].ToString();
                    teacher.LastName = reader["Apellido"].ToString();
                    teacher.Name = reader["nombre"].ToString();
                    teacher.Id = (int)reader["instructorId"];
                    teacher.State = (bool)reader["estado"];
                    return teacher;

                }

                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { }
        }

        public string registrarInstructor(Teacher teacher)
        {
            

            try
            {
                if (teacher.Dni != "" && teacher.Dni != null)
                {
                    bool bandera = buscarDNIinstructor(teacher.Dni);

                    if (bandera == false)
                    {

                        string insert = "INSERT INTO INSTRUCTORS (dni,apellido,nombre,detalles,estado) VALUES (@dni,@apellido,@nombre,@detalles,@estado)";

                        SqlParameter[] insertParameter = {

                        new SqlParameter("@dni",teacher.Dni),
                        new SqlParameter("@apellido",teacher.LastName),
                        new SqlParameter("@nombre",teacher.Name),
                        new SqlParameter("@detalles",teacher.detalle),
                        new SqlParameter("@estado",teacher.State),

                    };

                        int contador = accesoDatos.EjecutarComandoConParametros(insert, insertParameter);

                        if (contador > 0)
                        {
                            return "Instructor cargado en sistema";
                        }
                        else
                        {

                            return "Error al cargar en sistema";
                        }

                    }
                    else
                    {
                        return "El Instructor con el dni ya existe";
                    }
                }
                else
                { return "Por favor cargue el DNI ES REQUERIDO";  }


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
            }


            bool buscarDNIinstructor(string dni)
            {
               

                try
                {
                    string consulta = "Select count(*) from Instructors where dni = @dni";

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
                finally {
                   
                }

            }

        }

        public string modificarInstructor(Teacher teacher)
        {
            var respuesta = "";
            try
            {
                string consulta = "Update Instructors set  apellido = @apellido, nombre = @nombre, dni =@dni where instructorid = @id";

                SqlParameter[] parametros = new SqlParameter[] {
                    
                    new SqlParameter("@apellido",teacher.LastName),
                    new SqlParameter("@nombre",teacher.Name),
                    new SqlParameter("@dni",teacher.Dni),
                    new SqlParameter("@id",teacher.Id),
                };

                int response = accesoDatos.EjecutarComandoConParametros(consulta, parametros);

                if (response != 0) {

                    respuesta = "El instructor se modifico correctamente";

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

        public Teacher getInstructorPorId(string id)
        {
            SqlDataReader reader = null;
            Teacher teacher= new Teacher();

            try
            {

                string consulta = "Select * From Instructors where instructorId  = @id";

                SqlParameter[] parametros = new SqlParameter[] {

                    new SqlParameter("@id",id)

                };


                reader = accesoDatos.EjecutarLecturaConParametros(consulta, parametros);  


                if(reader.HasRows)
                {
                    reader.Read();

                    teacher.detalle = reader["detalles"].ToString();
                    teacher.Dni = reader["DNI"].ToString() ;
                    teacher.LastName = reader["Apellido"].ToString();
                    teacher.Name = reader["nombre"].ToString();
                    teacher.Id = (int)reader["instructorId"];

                    return teacher;

                }

                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally {}
        }

        public string eliminarInstructor(Teacher teacher)
        {
            try
            {

                string consulta = "Update Instructors set Estado = @estado where InstructorId = @id";

                SqlParameter[] parametros = new SqlParameter[] {

                    new SqlParameter ("@id", teacher.Id),

                    new SqlParameter ("@estado", teacher.State)
                };


                int bandera = accesoDatos.EjecutarComandoConParametros(consulta,parametros);

                if(bandera > 0)
                {
                    return "Se elimino el Instructor con Exito";
                }

                return "";

                

            }
            catch (Exception ex)
            {

                return "Ocurrio una excepcion en eliminarInstructor "+ ex.ToString();
            }

        }

        public List<Teacher> getInstructores()
        {
            

            SqlDataReader reader = null;
            List<Teacher> listaTeacher = new List<Teacher>();

            try
            {

                //accesoDatos.AbrirConexion();

                string consulta = "Select * from Instructors";
                reader = accesoDatos.EjecutarLectura(consulta);

                while (reader.Read())
                {
                    Teacher teacher = new Teacher();

                    teacher.Id = (int)reader["InstructorId"];
                    teacher.Name = reader["Nombre"].ToString();
                    teacher.LastName = reader["Apellido"].ToString();
                    //teacher.userid = (int)reader["userId"];
                    teacher.Dni = reader["DNI"].ToString() ;
                    teacher.State = (bool)reader["Estado"];
                    listaTeacher.Add(teacher);
                }


                return listaTeacher;
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
    }
}
