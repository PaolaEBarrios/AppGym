using Dominio;
using Negocio.Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ClaseNegocio
    {
        public ClaseNegocio() { }


        public void decrementarInscriptos(int claseId)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "update classes set inscriptos = inscritos - 1 where claseid = @claseid";
                SqlParameter[] parametros = {
                     new SqlParameter("@claseid", claseId)
                };

                datos.EjecutarComandoConParametros(consulta, parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        public bool verificarDisponibilidad(int claseId)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "select capacidad - (select count(*) from reservaciones where claseid = @claseid) as disponibles from classes where claseid = @claseid";

                SqlParameter[] parametros = {
                    new SqlParameter("@claseid", claseId)
                };

                SqlDataReader reader = datos.EjecutarLecturaConParametros(consulta, parametros);

                if (reader.Read())
                {
                    int disponibles = Convert.ToInt32(reader["disponibles"]);

                    if (disponibles > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public string rechazarClase(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "update classes set detalle = 'Rechazado' where claseid = @id";

                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@id", id)
                };

                int filasAfectadas = datos.EjecutarComandoConParametros(consulta, parametros);

                if (filasAfectadas > 0)
                {
                    return "Exito";
                }
                else
                {
                    return "Error: No se pudo rechazar la clase (ver metodo rechazarClase en ClaseNegocio)";
                }
            }
            catch (Exception ex)
            {
                return "Excepcion: " + ex.Message;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        public string activarClase(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "update classes set estado = 1, inscriptos = 0 where claseid = @id";

                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@id", id)
                };

                int filasAfectadas = datos.EjecutarComandoConParametros(consulta, parametros);

                if (filasAfectadas > 0)
                {
                    return "Exito";
                }
                else
                {
                    return "Error: No se pudo activar la clase";
                }
            }
            catch (Exception ex)
            {
                return "Excepcion: " + ex.Message;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        public bool eliminarClase(int claseId)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "delete from diasclases where claseid = @id; delete from classes where claseid = @id";

                SqlParameter[] parametros = new SqlParameter[]
                {
                        new SqlParameter("@id", claseId)
                };

                int filasAfectadas = datos.EjecutarComandoConParametros(consulta, parametros);

                if( filasAfectadas > 0)
                {
                    return true;
                }
                return false; 
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        public List<Clase> getClases()
        {
            AccesoDatos datos = new AccesoDatos();
            SqlDataReader reader = null;
            List<Clase> listaClases = new List<Clase>();

            try
            {
                //accesoDatos.AbrirConexion();

                string consulta = "select c.claseid, c.clasename, c.detalle, c.instructorid, c.capacidad, c.estado, dc.dayofweek as dia, dc.inicio as horainicio, dc.fin as horafin, dc.salonid from classes as c inner join diasclases as dc on c.claseid = dc.claseid";
                reader = datos.EjecutarLectura(consulta);

                while (reader.Read())
                {
                    Clase clase = new Clase();
                    clase.instructor = new Teacher();

                    clase.detalle = reader["Detalle"]?.ToString();
                    clase.Id = (int)reader["ClaseId"];
                    clase.Name = reader["ClaseName"].ToString();
                    clase.InstructorId = reader["InstructorId"].ToString();
                    clase.Capacidad = (int)reader["Capacidad"];
                    clase.estado = (bool)reader["Estado"];
                    clase.Dia = reader["Dia"].ToString();
                    clase.HoraInicio = ((TimeSpan)reader["HoraInicio"]).ToString(@"hh\:mm");
                    clase.HoraFin = ((TimeSpan)reader["HoraFin"]).ToString(@"hh\:mm");
                    clase.idSalon = (int)reader["SalonId"];
                    listaClases.Add(clase);
                }


                return listaClases;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                reader?.Close();
                datos.CerrarConexion();
            }
        }

        public string editarClase(Clase clase)
        {

            AccesoDatos datos = new AccesoDatos();
            string respuesta = "";

            try
            {
               
                string consulta = "update classes set clasename = @nombre, instructorid = @id, capacidad = @capacidad,  estado = @estado  where claseid = @claseId";

                SqlParameter[] parametros = new SqlParameter[]
                {
                        new SqlParameter("@claseId", clase.Id),
                        new SqlParameter("@nombre", clase.Name),
                        new SqlParameter("@id", clase.instructor.Id),
                        new SqlParameter("@capacidad", clase.Capacidad),
                        new SqlParameter("@estado", clase.estado)
                };

                int filasAfectadas = datos.EjecutarComandoConParametros(consulta, parametros);

                if (filasAfectadas > 0)
                {

                    string consultaDias = "update diasclases set dayofweek = @dayofweek, inicio = @inicio, fin = @fin, instructorid = @instructorid, salonid = @salonid where claseid = @claseid";


                    SqlParameter[] parametrosDias = new SqlParameter[]
                    {
                        new SqlParameter("@claseid", clase.Id),
                        new SqlParameter("@dayofweek", clase.Dia),
                        new SqlParameter("@inicio", TimeSpan.Parse(clase.HoraInicio)),
                        new SqlParameter("@fin", TimeSpan.Parse(clase.HoraFin)),
                        new SqlParameter("@instructorid", clase.instructor.Id),
                        new SqlParameter("@salonid", clase.idSalon)
                    };

                    int filasAfectadasDias = datos.EjecutarComandoConParametros(consultaDias, parametrosDias);

                    if (filasAfectadasDias > 0)
                    {
                        respuesta = "Exito al editar la clase";
                    }
                    else
                    {
                        respuesta = "Error al actualizar la clase";
                    }
                }
                else
                {
                    respuesta = "Error al actualizar";
                }
            }
            catch (Exception ex)
            {
                respuesta = "Ocurrio una excepcion: " + ex.Message;
            }
            finally
            {
                datos.CerrarConexion();
            }

            return respuesta;

        }

        public string cargarClase(Clase clase)
        {
            AccesoDatos datos = new AccesoDatos();
            string respuesta = "";

            try
            {

                string consulta = "insert into classes (clasename, instructorid, capacidad, estado) output inserted.claseid values (@clasename, @instructorid, @capacidad, @estado)";

                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@ClaseName", clase.Name),
                    new SqlParameter("@InstructorId", clase.instructor.Id),
                    
                    new SqlParameter("@Capacidad", clase.Capacidad),
                    new SqlParameter("@Estado", clase.estado)
                };
                int claseId = (int)datos.EjecutarEscalarConParametros(consulta, parametros);

                if (claseId > 0)
                {
                    // Insertar en DiasClases usando el ClaseId obtenido
                    string consultaDias = @"INSERT INTO DiasClases (ClaseId, DayOfWeek, Inicio, Fin, InstructorId, SalonId) values (@ClaseId, @DayOfWeek, @Inicio, @Fin, @InstructorId, @SalonId)";

                    SqlParameter[] parametrosDias = new SqlParameter[]
                    {
                        new SqlParameter("@ClaseId", claseId),
                        new SqlParameter("@DayOfWeek", clase.Dia),
                        new SqlParameter("@Inicio", TimeSpan.Parse(clase.HoraInicio)),
                        new SqlParameter("@Fin", TimeSpan.Parse(clase.HoraFin)),
                        new SqlParameter("@InstructorId", clase.instructor.Id),
                        new SqlParameter("@SalonId", clase.idSalon),

                    };

                    int filasAfectadas = datos.EjecutarComandoConParametros(consultaDias, parametrosDias);

                    if (filasAfectadas > 0)
                    {
                        respuesta = "Exito al cargar la clase";
                    }
                    else
                    {
                        respuesta = "Error al cargar en DiasClases";
                    }
                }
                else
                {
                    respuesta = "Error al cargar la tabla  Classes";
                }
                return respuesta;
            }
            catch (Exception ex) { 
            
                return "Ocurrio una excepcion: "+ ex.Message;
            }
            finally
            {

            }
        }

        public bool disponibidadInstructor(int idInstructor, Clase  clase)
        {
            AccesoDatos datos = new AccesoDatos();
            SqlDataReader reader = null;

            try
            {

                string consulta = "select count(*) from diasclases where instructorid = @idInstructor and dayofweek = @dia and (@horaInicio < fin and @horaFin > inicio)";


                SqlParameter[] parametros = new SqlParameter[]
{
                    new SqlParameter("@idInstructor", idInstructor),
                    new SqlParameter("@dia", clase.Dia),
                    new SqlParameter("@horaInicio", TimeSpan.Parse(clase.HoraInicio)),
                    new SqlParameter("@horaFin", TimeSpan.Parse(clase.HoraFin))
                };


                reader = datos.EjecutarLecturaConParametros(consulta, parametros);

                if (reader != null && reader.Read())
                {
                    int count = reader.GetInt32(0);
                    if (count == 0)
                    {
                        return true; 
                    }
                    else
                    {
                        return false; 
                    }
                }
                return false; 
            }
            catch (Exception ex)
            {
                
                return false;
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }
                datos.CerrarConexion();
            }
        }
        public bool disponibidadSalon(Clase clase)
        {
            AccesoDatos datos = new AccesoDatos();
            SqlDataReader reader = null;
            try
            {
                //hacemos un join para buscar el salon feo
                string consulta = "select count(*) from diasclases dc join diashorarios dh on dc.dayofweek = dh.diadelasemana where dc.salonid = @idSalon and dc.dayofweek = @dia and (@horaInicio < dh.horariofin and @horaFin > dh.horarioinicio)";
;


                SqlParameter[] parametros = new SqlParameter[]
                {
                new SqlParameter("@idSalon", clase.idSalon),
                new SqlParameter("@dia", clase.Dia),
                new SqlParameter("@horaInicio", TimeSpan.Parse(clase.HoraInicio)),
                new SqlParameter("@horaFin", TimeSpan.Parse(clase.HoraFin))
                };


                reader = datos.EjecutarLecturaConParametros(consulta, parametros);

                if (reader != null && reader.Read())
                {
                    int count = reader.GetInt32(0); //se obtiene de la primera fila o sea el contador si se trajo algo si es cero es que no hay nada
                    if (count == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false; //se superpone
                    }
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                return false;
            }

            finally { }
        }

    }



}
