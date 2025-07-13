using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using EasyPark.Backend.Entidad;

namespace EasyPark.Backend.Datos
{
    public class dRol
    {
        //connection string to sql
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        DataTable dt;
        SqlDataAdapter da;


        //dropdown de roles
        public List<eRol> obtenerRoles()
        {
            List<eRol> lista = new List<eRol>();

            try
            {
                SqlCommand cmd = new SqlCommand("obtener_roles", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    eRol rol = new eRol
                    {
                        IdRol = Convert.ToInt32(dr["id_rol"]),
                        NombreRol = dr["nombre_rol"].ToString()
                    };
                    lista.Add(rol);
                }

                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                throw new Exception("Error al obtener roles: " + ex.Message);
            }

            return lista;
        }

        //INSERT usuarios ejemplo:
        /*
         public void insertClient(eClient Client)
        {
            //SQL commmand for query
            SqlCommand cmd = new SqlCommand("insClient", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            //Parameters
            cmd.Parameters.Add("@id_client",SqlDbType.Int).Value=Client.idClient;
            cmd.Parameters.Add("@client_name", SqlDbType.VarChar).Value=Client.nameCl;
            cmd.Parameters.Add("@client_lastname", SqlDbType.VarChar).Value=Client.lastNameCl;
            cmd.Parameters.Add("@birthday", SqlDbType.Date).Value=Client.bithday;
            cmd.Parameters.Add("@bithcountry", SqlDbType.VarChar).Value=Client.countryCl;
            cmd.Parameters.Add("@phone", SqlDbType.Int).Value=Client.phoneCl;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value= Client.emailCl;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = Client.password;

            //execute query
            cmd.ExecuteNonQuery();
            con.Close();
        }
         */
    }
}