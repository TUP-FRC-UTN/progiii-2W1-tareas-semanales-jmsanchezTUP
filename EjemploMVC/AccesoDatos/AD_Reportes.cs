using System;
using System.Collections.Generic;
using EjemploMVC.Models;
using EjemploMVC.ViewModels;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EjemploMVC.AccesoDatos
{
    public class AD_Reportes
    {
        public static List<SexoItemVM> obtenerCantidadPorSexo()
        {
            List<SexoItemVM> resultado = new List<SexoItemVM>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "SELECT s.Nombre as 'Sexo',count(*) as 'Cantidad' FROM Sexos s JOIN  Personas p ON p.IdSexo = s.Id GROUP BY s.Nombre";
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
                        aux.Nombre = dr["Sexo"].ToString();
                        aux.Cantidad = int.Parse(dr["Cantidad"].ToString());
                        
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

        public static List<PersonaItemVM> obtenerReportePersona()
        {
            List<PersonaItemVM> resultado = new List<PersonaItemVM>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "SELECT p.Id, p.Nombre, p.Apellido, p.Edad, p.Telefono, s.Nombre as 'Sexo' FROM Personas p JOIN Sexos s ON p.IdSexo = s.Id";
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
                        PersonaItemVM aux = new PersonaItemVM();
                        aux.Id = int.Parse(dr["Id"].ToString());
                        aux.Nombre = dr["Nombre"].ToString();
                        aux.Apellido = dr["Apellido"].ToString();
                        aux.Edad = int.Parse(dr["Edad"].ToString());
                        aux.Telefono = dr["Telefono"].ToString();
                        aux.SexoNombre = dr["Sexo"].ToString();

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