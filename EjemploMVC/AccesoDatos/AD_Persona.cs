using EjemploMVC.Models;
using EjemploMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EjemploMVC.AccesoDatos
{
    public class AD_Persona
    {
        public static bool insertarNuevaPersona(Persona pers)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "INSERT INTO Personas VALUES(@nombre, @apellido, @edad, @telefono, @idsexo)";
                cmd.Parameters.Clear();
                
                cmd.Parameters.AddWithValue("@nombre", pers.Nombre);
                cmd.Parameters.AddWithValue("@apellido", pers.Apellido);
                cmd.Parameters.AddWithValue("@edad", pers.Edad);
                cmd.Parameters.AddWithValue("@telefono", pers.Telefono);
                cmd.Parameters.AddWithValue("@idsexo", pers.IdSexoPersona);
                
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                resultado = true;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return resultado;
        }

        public static List<Persona> obtenerListaPersona()
        {
            List<Persona> resultado = new List<Persona>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "SELECT * FROM Personas";
                cmd.Parameters.Clear();

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();
                
                if(dr != null)
                {
                    while(dr.Read())
                    {
                        Persona aux = new Persona();
                        aux.Id = int.Parse(dr["Id"].ToString());
                        aux.Nombre = dr["Nombre"].ToString();
                        aux.Apellido = dr["Apellido"].ToString();
                        aux.Edad = int.Parse(dr["Edad"].ToString());
                        aux.Telefono = dr["Telefono"].ToString();

                        resultado.Add(aux);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return resultado;
        }

        public static Persona obtenerPersona(int idPersona)
        {
            Persona resultado = new Persona();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "SELECT * FROM Personas WHERE Id = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", idPersona);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {                      
                        resultado.Id = int.Parse(dr["Id"].ToString());
                        resultado.Nombre = dr["Nombre"].ToString();
                        resultado.Apellido = dr["Apellido"].ToString();
                        resultado.Edad = int.Parse(dr["Edad"].ToString());
                        resultado.Telefono = dr["Telefono"].ToString();
                        resultado.IdSexoPersona = int.Parse(dr["IdSexo"].ToString());

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return resultado;
        }

        public static bool actualizarPersona(Persona pers)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "UPDATE Personas SET Nombre = @nombre, Apellido = @apellido, Edad = @edad, Telefono = @telefono, IdSexo = @idsexo WHERE Id = @id";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@nombre", pers.Nombre);
                cmd.Parameters.AddWithValue("@apellido", pers.Apellido);
                cmd.Parameters.AddWithValue("@edad", pers.Edad);
                cmd.Parameters.AddWithValue("@telefono", pers.Telefono);
                cmd.Parameters.AddWithValue("@idsexo", pers.IdSexoPersona);
                cmd.Parameters.AddWithValue("@id", pers.Id);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                resultado = true;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return resultado;
        }

        public static bool eliminarPersona(Persona pers)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "DELETE FROM Personas WHERE Id = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", pers.Id);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                resultado = true;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return resultado;
        }

        public static List<SexoItemVM> obtenerListaSexo()
        {
            List<SexoItemVM> resultado = new List<SexoItemVM>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "SELECT * FROM Sexos";
                cmd.Parameters.Clear();

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        SexoItemVM aux = new SexoItemVM();
                        aux.IdSexo = int.Parse(dr["Id"].ToString());
                        aux.Nombre = dr["Nombre"].ToString();
                        
                        resultado.Add(aux);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return resultado;
        }
    }
}