using ConcesionariaMVC.Models;
using ConcesionariaMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConcesionariaMVC.AccesoDatos
{
    public class AD_Autos
    {
        public static List<Auto> listaAutos()
        {
            List<Auto> listado = new List<Auto>();

            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            //string cadenaConexion = @"Data Source=DESKTOP-E21R4UF\SQLEXPRESS;Initial Catalog=Programacion3;Integrated Security=True";
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand comando = new SqlCommand();
                string consulta = "SELECT * FROM Autos";
                comando.Parameters.Clear();

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;

                conexion.Open();
                comando.Connection = conexion;

                SqlDataReader dr = comando.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        Auto aux = new Auto();
                        aux.IdAuto = int.Parse(dr["IdAuto"].ToString());
                        aux.Patente = dr["Patente"].ToString();
                        aux.Kilometros = int.Parse(dr["Km"].ToString());
                        aux.Promocion = Boolean.Parse(dr["Promocion"].ToString());
                        aux.Precio = float.Parse(dr["Precio"].ToString());
                        aux.IdMarca = int.Parse(dr["IdMarca"].ToString());

                        listado.Add(aux);
                    }
                }


            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
            return listado;
        }

        public static List<Auto> listaPromociones()
        {
            List<Auto> listado = new List<Auto>();

            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            //string cadenaConexion = @"Data Source=DESKTOP-E21R4UF\SQLEXPRESS;Initial Catalog=Programacion3;Integrated Security=True";
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand comando = new SqlCommand();
                //string consulta = "SELECT IdAuto, Patente, Kilometros, Promocion, (Precio * 0.90) as 'Precio Promocion', IdMarca FROM Autos WHERE Promocion = 1";
                string consulta = "SELECT Patente, Km, (Precio * 0.90) as 'Precio Promocion', IdMarca FROM Autos WHERE Promocion = 1";

                comando.Parameters.Clear();

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;

                conexion.Open();
                comando.Connection = conexion;

                SqlDataReader dr = comando.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        Auto aux = new Auto();
                        aux.IdAuto = 0;
                        aux.Patente = dr["Patente"].ToString();
                        aux.Kilometros = int.Parse(dr["Km"].ToString());
                        aux.Promocion = false;
                        aux.Precio = float.Parse(dr["Precio Promocion"].ToString());
                        aux.IdMarca = int.Parse(dr["IdMarca"].ToString());

                        listado.Add(aux);
                    }
                }


            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
            return listado;
        }

        public static Boolean agregarNuevoAuto(Auto nuevo)
        {
            Boolean resultado = false;

            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            //string cadenaConexion = @"Data Source=DESKTOP-E21R4UF\SQLEXPRESS;Initial Catalog=Programacion3;Integrated Security=True";
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand comando = new SqlCommand();
                string consulta = "INSERT Into Autos VALUES(@patente,@idMarca,@km,@promocion,@precio)";
                comando.Parameters.Clear();
                
                comando.Parameters.AddWithValue("@patente", nuevo.Patente);
                comando.Parameters.AddWithValue("@idMarca", nuevo.IdMarca);
                comando.Parameters.AddWithValue("@km", nuevo.Kilometros);
                comando.Parameters.AddWithValue("@promocion", nuevo.Promocion);
                comando.Parameters.AddWithValue("@precio", nuevo.Precio);

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;

                conexion.Open();
                comando.Connection = conexion;

                comando.ExecuteNonQuery();

                resultado = true;


            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
            return resultado;
        }

        public static List<MarcaVM> listaMarcas()
        {
            List<MarcaVM> listado = new List<MarcaVM>();

            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            //string cadenaConexion = @"Data Source=DESKTOP-E21R4UF\SQLEXPRESS;Initial Catalog=Programacion3;Integrated Security=True";
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand comando = new SqlCommand();
                string consulta = "SELECT * FROM Marcas";
                comando.Parameters.Clear();

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;

                conexion.Open();
                comando.Connection = conexion;

                SqlDataReader dr = comando.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        MarcaVM aux = new MarcaVM();
                        aux.IdMarca = int.Parse(dr["IdMarca"].ToString());
                        aux.Nombre = dr["Nombre"].ToString();

                        listado.Add(aux);
                    }
                }


            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
            return listado;
        }
    }
}