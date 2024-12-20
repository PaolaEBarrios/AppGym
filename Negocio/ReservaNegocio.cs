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
    public class ReservaNegocio
    {
        public ReservaNegocio() { }


        public string eliminarReserva(int reservaId)
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "update reservaciones set estado = 0 where reservacionid = @reservacionid";
                
                SqlParameter[] parametros = {
                    new SqlParameter("@reservacionid", reservaId)
                };

                int filas = datos.EjecutarComandoConParametros(consulta, parametros);

                if (filas > 0) {

                    return "Exito al eliminar reserva";
                
                }
                else
                {
                    return "Error al eliminar reserva";
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
        public List<Reserva> getReservasXcliente(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Reserva> listaReserva = new List<Reserva>();

            try
            {
                string consulta = "select * from reservaciones where clienteid = @clienteid and estado = 1";

                SqlParameter[] parametros = {
                    new SqlParameter("@clienteid", id)
                };

                SqlDataReader reader = datos.EjecutarLecturaConParametros(consulta, parametros);

                while (reader.Read())
                {
                    Reserva reserva = new Reserva();

                    reserva.Id = (int)reader["ReservacionId"];
                    reserva.ClaseId = (int)reader["ClaseId"];
                    reserva.Dia = reader["Dia"].ToString();
                    reserva.HoraInicio = reader["HoraInico"].ToString();
                    reserva.HoraFin = reader["HoraFin"].ToString();
                    reserva.estado = (bool)reader["Estado"];
                    reserva.nombreClase = reader["ClaseName"].ToString();


                    listaReserva.Add(reserva);
                }

                return listaReserva;
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
        public string registrarInscripcion(int clienteId, int claseId, string dia, TimeSpan horaInicio, TimeSpan horaFin, string claseNombre)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                // Consulta para insertar la inscripción
                string consulta = "insert into reservaciones (clienteId, claseId, dia, horaInico, horaFin, estado, claseNombre) values (@clienteId, @claseId, @dia, @horaInicio, @horaFin, @estado, @claseName)";

                // Parámetros para la consulta
                SqlParameter[] parametros = {
                    new SqlParameter("@clienteId", clienteId),
                    new SqlParameter("@claseId", claseId),
                    new SqlParameter("@dia", dia),
                    new SqlParameter("@horaInicio", horaInicio),
                    new SqlParameter("@horaFin", horaFin),
                    new SqlParameter("@estado", 1), 
                    new SqlParameter("@claseName", claseNombre)
                };

                
                int filas = datos.EjecutarComandoConParametros(consulta, parametros);

                if (filas > 0) {
                    return "Exito al registrar";
                }
                else
                {
                    return "Error al registrar la inscripcion";
                }
                
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public bool verificarSuperposicion(int clienteId, string dia, TimeSpan horaInicio, TimeSpan horaFin)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "select count(*) from diasclases dc inner join reservaciones r on dc.claseid = r.claseid where r.clienteid = @clienteid and dc.dayofweek = @dia and (@horainicio < dc.fin and @horafin > dc.inicio)";


                SqlParameter[] parametros = {
                    new SqlParameter("@Clienteid", clienteId),
                    new SqlParameter("@dia", dia),
                    new SqlParameter("@horainicio", horaInicio),
                    new SqlParameter("@horafin", horaFin)
                };

                SqlDataReader reader = datos.EjecutarLecturaConParametros(consulta, parametros);

                if (reader.Read())
                {
                    int count = Convert.ToInt32(reader[0]);

                    if (count > 0) { 
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


    }
}
