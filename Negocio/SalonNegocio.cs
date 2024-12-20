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
    public class SalonNegocio
    {
        public SalonNegocio() { }


        //busca coinicidencias con el nombre en la base de datos, si no encuentra retorna 1
        //si encuentra retorna -2
        //si es excepcion retorna -1
        public int buscarNombreSalon(string name)
        {
            AccesoDatos datos = new AccesoDatos();
            SqlDataReader reader = null;

            try
            {
                datos.AbrirConexion();

                string consulta = "Select * from salones where nombresalon = @nombre";

                SqlParameter[] parametros = new SqlParameter[] {

                    new SqlParameter("@nombre",name)
                };


                reader = datos.EjecutarLecturaConParametros(consulta, parametros);

                if (reader.Read())
                {
                    int count = Convert.ToInt32(reader[0]);
                    if (count > 0)
                    {
                        //encontro datos
                        return -2;
                    }
                }

                //no encontro datos
                return 1;

            }
            catch (Exception)
            {

                return -1;
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


        public string eliminarSalon(Salon salon)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            string respuesta = "";

            try
            {

                string consulta = "Delete Salones where salonId = @id";

                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@id",salon.IdSalon),
                };


                int filas = accesoDatos.EjecutarComandoConParametros(consulta, parametros);

                if (filas > 0)
                {
                    respuesta = "Exito al eliminar el salon";
                }
                else
                {
                    respuesta = "Ocurrio un error al eliminarlo, no se concreto el eliminar";
                }

                return respuesta;
            }
            catch (Exception ex)
            {

                return "OCURRIO UNA EXCEPCION: " + ex.ToString();
            }
            finally
            {

            }
        }

        public string editarNombreSalon(Salon salon, string nombreNuevo)
        {
            try
            {
                //antes no dejar cambiar el nombre si existe otro igual 

                string respuesta = "";
                int banderaExiste = buscarNombreSalon(nombreNuevo);


                if (banderaExiste == 1)
                {

                    AccesoDatos datos = new AccesoDatos();

                    string consulta = "Update Salones Set NombreSalon = @nombre where salonid= @id ";

                    SqlParameter[] parametros = new SqlParameter[] {

                        new SqlParameter ("@nombre",nombreNuevo),
                        new SqlParameter ("@id",salon.IdSalon),

                    };


                    int filas = datos.EjecutarComandoConParametros(consulta, parametros);

                    if (filas > 0)
                    {
                        respuesta = "Exito al editar el nombre del salon";

                    }
                    else
                    {
                        respuesta = "Ocurrio un error al intentar editar";
                        
                    }

                    return respuesta;

                }
                else if (banderaExiste == -2)
                {
                    respuesta = "YA EXISTE EL ESE NOMBRE REGISTRADO, POR FAVOR VERIFIQUE QUE SEA DISTINTO";
                    
                }
                else {

                    respuesta = "Ocurrio una excepcion en la busqueda del nombre del salon";
                    
                }

                return respuesta;


            }
            catch (Exception ex)
            {

                return "Ocurrio una excepcion: "+ex.ToString();
            }
        }
        public string agregarSalon(Salon salon)
        {
            AccesoDatos datos = new AccesoDatos();  

            try
            {
                datos.AbrirConexion();
                //busca coinicidencias con el nombre en la base de datos, si no encuentra retorna 1
                //si encuentra retorna -2
                //si es excepcion retorna -1
                int bandera = buscarNombreSalon(salon.Name);


                if (bandera > 0) {


                    string consulta = "Insert into Salones (NombreSalon) values (@nombre)";

                    SqlParameter[] sp = new SqlParameter[] {

                    new SqlParameter("@nombre",salon.Name)

                    };


                    int filas = datos.EjecutarComandoConParametros(consulta, sp);

                    if (filas > 0)
                    {
                        return "El salon se creo exitosamente";
                    }
                    else
                    {
                        return "Ocurrio un error al cargar el salon a la tabla salones";
                    }

                }
                else if(bandera == -1)
                {
                    return "Ocurrio una excepcion al buscar el nombre en la base de datos salones";
                }
                else
                {
                    return "Ya existe ese nombre en la base de datos";
                }
                

            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
            finally
            {
                datos.CerrarConexion();
            }
        }


        public List<Salon> getSalones() {

            AccesoDatos datos = new AccesoDatos();
            SqlDataReader reader = null;

            List<Salon> salones = new List<Salon>();
            


            try
            {


                string consulta = "Select salonid, nombreSalon from Salones";

                reader = datos.EjecutarLectura(consulta);
                datos.AbrirConexion();



                while (reader.Read())
                {
                    Salon salon = new Salon();

                    salon.IdSalon = (int)reader["salonid"];
                    salon.Name = reader["NombreSalon"].ToString();

                    salones.Add(salon);
                }

                return salones;
            }
            catch (Exception ex)
            {
                salones = null;
                return salones;
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close(); // Cierra el lector si está abierto
                }

                datos.CerrarConexion();

            }
        
        
        }


    }
}
