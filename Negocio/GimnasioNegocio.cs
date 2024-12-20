using Dominio;
using Negocio.Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class GimnasioNegocio
    {
        public GimnasioNegocio() { }


        public string editarHorarioxDia(Gimnasio gimnasio)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                string consulta = "update diashorarios set horarioinicio = @horarioInicio, horarioFin = @horarioFin where diadelasemana = @dia";

                SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@dia", gimnasio.dia),
                    new SqlParameter("@horarioInicio", gimnasio.horaInicio),
                    new SqlParameter("@horarioFin", gimnasio.horaFin)
                };

                int filas = datos.EjecutarComandoConParametros(consulta, sp);

                if (filas > 0)
                {
                    return "Exito";
                }
                else
                {
                    return "Error en ejecutar comando";
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

        public List<Gimnasio> getAllDiasHorarios()
        {
            AccesoDatos datos = new AccesoDatos();
            SqlDataReader reader = null;
            List<Gimnasio> listaGimnasio = new List<Gimnasio>();

            try
            {
                string consulta = "select diadelasemana, horarioInicio, horarioFin from diashorarios";
                reader = datos.EjecutarLectura(consulta);

                while (reader.Read())
                {
                    Gimnasio gim = new Gimnasio();
                    gim.dia = reader["diadelasemana"].ToString();
                    gim.horaInicio = reader["horarioInicio"].ToString();
                    gim.horaFin = reader["horarioFin"].ToString();
                    listaGimnasio.Add(gim);
                }

                return listaGimnasio;
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
                datos.CerrarConexion();
            }
        }
        public string existeDia(Gimnasio gimnasio)
        {
            string respuesta = "";
            AccesoDatos datos = new AccesoDatos();
            SqlDataReader reader = null;

            try
            {

                //recuperar el dia si existe
                //leer base de datos
                string consulta = "Select DiaDeLaSemana from DiasHorarios where diaDelasemana = @dia";

                SqlParameter[] parametros = new SqlParameter[]{

                    new SqlParameter("@dia",gimnasio.dia)

                };



                reader = datos.EjecutarLecturaConParametros(consulta, parametros);

                if (reader != null && reader.Read())
                {
                    respuesta = "Existe";
                }
                else
                {
                    respuesta = "NoExiste";
                }


                return respuesta;
            }
            catch (Exception ex)
            {
                return "Excepcion";
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
        public string agregarDiasHorarios(Gimnasio gimnasio)
        {
            AccesoDatos datos = new AccesoDatos();
            string respuesta = "";

            try
            {
                string consulta = "INSERT INTO DiasHorarios(DiaDeLaSemana,Horario) VALUES(@dia,@horario)";


                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter ("@dia",gimnasio.dia),
                    new SqlParameter ("@horario",gimnasio.hora)
                };


                int filas = datos.EjecutarComandoConParametros(consulta, parametros);

                if(filas > 0)
                {
                    respuesta = "Exito al agregar el dia";
                    
                }
                else
                {
                    respuesta = "Ocurrio un error al intentar agregar el dia";
                    
                }
                return respuesta;
            }
            catch (Exception ex)
            {

                return "Excepcion";
            }
            finally
            {

            }
        }
    }
}
