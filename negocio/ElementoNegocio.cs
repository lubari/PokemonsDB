using System;
using System.Collections.Generic;
using dominio;

namespace negocio
{
    public class ElementoNegocio
    {
        public List<Elemento> listar()
        {
            List<Elemento> lista = new List<Elemento>();
            AccesoDatos datos= new AccesoDatos();
            
            try
            {
                datos.setearConsulta("SELECT Id, Descripcion From ELEMENTOS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Elemento aux = new Elemento();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    lista.Add(aux);
                }

                return lista;
            }
            catch(Exception e) 
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
