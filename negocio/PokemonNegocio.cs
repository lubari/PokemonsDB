using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using dominio;

namespace negocio
{
    public class PokemonNegocio
    {
        public List<Pokemon> Listar()
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            List<Pokemon> lista = new List<Pokemon>();
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlDataReader lector;

            try
            {
                connection.ConnectionString = "server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true";
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT Numero, Nombre, p.Descripcion, UrlImagen, e.Descripcion Tipo, d.Descripcion Debilidad FROM POKEMONS p, ELEMENTOS e, ELEMENTOS d WHERE e.Id=p.IdTipo and d.Id=p.IdDebilidad";
                command.Connection = connection;

                connection.Open();
                lector = command.ExecuteReader();

                while (lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Tipo = new Elemento();
                    aux.Debilidad = new Elemento();
                    aux.Numero = (int)lector["Numero"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.UrlImagen = (string)lector["UrlImagen"];
                    aux.Tipo.Descripcion = (string)lector["Tipo"];
                    aux.Debilidad.Descripcion = (string)lector["Debilidad"];
                    lista.Add(aux);
                }
                connection.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void agregar(Pokemon nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string query = "INSERT INTO POKEMONS (Numero,Nombre, Descripcion, Activo) \r\nVALUES ("+nuevo.Numero+",'"+nuevo.Nombre+"','"+nuevo.Descripcion+"', 1)\r\n";
                datos.setearConsulta(query);
                datos.ejecutarAccion();
            } catch (Exception e)
            {
                throw e;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


    }
}
