using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ArticulosNegocio
    {
        public List<Articulos> listar()
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearQuery("Select ART.Id, ART.Nombre , ART.Precio, I.ImagenUrl from ARTICULOS as ART inner join IMAGENES as I on ART.Id = I.IdArticulo");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    /*
                    aux.CodigoArticulo = (string)lector["Codigo"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.Precio = (decimal)lector["Precio"];
                    */
                    aux.ID = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.UrlImagen = (string)datos.Lector["ImagenUrl"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        /*


        public void Agregar()
        {

        }


        public void Modificar()
        {

        }

        public void Eliminar()
        {

        }

        }*/
        public List<Articulos> VerDetalle()
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearQuery("Select ART.Id ,ART.Codigo,M.Descripcion as Marca,  ART.Nombre , ART.Descripcion, ART.Precio,  C.Descripcion as Categoria, I.ImagenUrl from ARTICULOS as ART"
                + " inner join IMAGENES as I on ART.Id = I.IdArticulo"
                + " inner join MARCAS as M on ART.IdMarca = M.Id"
                + " inner join CATEGORIAS as C on ART.IdCategoria = C.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.Marca = new Marca();
                    aux.Categoria = new Categoria();
                   

                    aux.ID = (int)datos.Lector["Id"];
                    aux.CodigoArticulo = (string)datos.Lector["Codigo"];

                    aux.Marca.DescripcionMarca = (string)datos.Lector["Marca"];
                    
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.DescripcionART = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    aux.Categoria.DescripcionCategoria = (string)datos.Lector["Categoria"];
                    aux.UrlImagen = (string)datos.Lector["ImagenUrl"];

                    lista.Add(aux);
                   
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    
        
    }
}
