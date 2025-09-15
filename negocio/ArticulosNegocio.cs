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
            AccesoBD datosImagen = new AccesoBD();

            try
            {
                datos.setearQuery("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, " +
                                  "M.Descripcion AS MarcaDescripcion, M.Id as IdMarca, " +
                                  "C.Descripcion AS CategoriaDescripcion, C.Id as IdCategoria FROM ARTICULOS A " + 
                                  "INNER JOIN MARCAS M ON M.Id = A.IdMarca " +
                                  "INNER JOIN CATEGORIAS C ON C.Id = A.IdCategoria");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    Marca auxM = new Marca();
                    Categoria auxC = new Categoria();

                    aux.ID = (int)datos.Lector["Id"];
                    aux.CodigoArticulo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.DescripcionART = (string)datos.Lector["Descripcion"];
                    auxM.ID = (int)datos.Lector["IdMarca"];
                    auxM.DescripcionMarca = (string)datos.Lector["MarcaDescripcion"];
                    auxC.ID = (int)datos.Lector["IdCategoria"];
                    auxC.DescripcionCategoria = (string)datos.Lector["CategoriaDescripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.UrlImagen = "";

                    aux.Marca = auxM;
                    aux.Categoria = auxC;

                    lista.Add(aux);
                }
                datos.cerrarLector();

                datosImagen.setearQuery("SELECT IdArticulo, ImagenUrl FROM IMAGENES");
                datosImagen.ejecutarLectura();

                while (datosImagen.Lector.Read())
                {
                    int idArticulo = (int)datosImagen.Lector["IdArticulo"];
                    string url = (string)datosImagen.Lector["ImagenUrl"];

                    Articulos articulo = lista.Find(a => a.ID == idArticulo);
                    if (articulo != null)
                    {
                        articulo.UrlImagen = url;
                    }
                }
                datosImagen.cerrarLector();

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
                datosImagen.cerrarConexion();
            }
        }
        
        public void Agregar(Articulos nuevo)
        {
            AccesoBD datos = new AccesoBD();
            AccesoBD datosImagen = new AccesoBD();

            try
            {
                datos.setearQuery("insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) Values(@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @precio);" + "Select cast (SCOPE_IDENTITY() AS INT) AS ID");
                datos.setearParametro("@codigo", nuevo.CodigoArticulo);
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@descripcion", nuevo.DescripcionART);
                datos.setearParametro("@idMarca", nuevo.Marca.ID);
                datos.setearParametro("@idCategoria", nuevo.Categoria.ID);
                datos.setearParametro("@precio", nuevo.Precio);

                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    nuevo.ID = Convert.ToInt32(datos.Lector["ID"]);
                }
                datos.cerrarLector();

                datosImagen.setearQuery("insert into IMAGENES (IdArticulo, ImagenUrl) Values(@idArticulo, @imagenUrl)");
                datosImagen.setearParametro("@idArticulo", nuevo.ID);
                datosImagen.setearParametro("@imagenUrl", nuevo.UrlImagen);
                datosImagen.ejecutarAccion();

            }
            catch (Exception ex)
            { 
                throw ex;
            }

            finally 
            { 
                datos.cerrarConexion();
                datosImagen.cerrarConexion();
            }
        }

        public void Modificar(Articulos modificar)
        {
            AccesoBD datos = new AccesoBD();
            AccesoBD datosImagen = new AccesoBD();
            try
            {
                datos.setearQuery("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca, IdCategoria = @idCategoria, Precio = @precio where id = @id");
                datos.setearParametro("@codigo", modificar.CodigoArticulo);
                datos.setearParametro("@nombre", modificar.Nombre);
                datos.setearParametro("@descripcion", modificar.DescripcionART);
                datos.setearParametro("@idMarca", modificar.Marca.ID);
                datos.setearParametro("@idCategoria", modificar.Categoria.ID);
                datos.setearParametro("@precio", modificar.Precio);
                datos.ejecutarAccion();

                datosImagen.setearQuery("update IMAGENES set ImagenUrl = @imagenUrl where Id = @id");
                datosImagen.setearParametro("@imagenUrl", modificar.UrlImagen);
                datosImagen.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                datos.cerrarConexion();
                datosImagen.cerrarConexion();
            }
        }

        // EN LA BASE DE DATOS, NO EXISTE UN CAMPO "Activo", HAY QUE CREARLO. 
        //IGUALMENTE SE DEJA EL METODO POR SI SE DESEA IMPLEMENTAR.
        /*
        public void EliminarLogico(int id)
        {
            try
            {
                AccesoBD datos = new AccesoBD();
                datos.setearQuery("Update ARTICULOS set Activo = 0 where Id = @Id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        */
        public void EliminarDB(int id)
        {
            try
            {
                AccesoBD datos = new AccesoBD();
                datos.setearQuery("Delete from ARTICULOS where Id = @Id");
                datos.setearParametro("@id",id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        
        public List<Articulos> VerDetalle()
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearQuery("Select ART.Id ,ART.Codigo,M.Descripcion as Marca,  ART.Nombre , ART.Descripcion, ART.Precio,  C.Descripcion as Categoria, I.ImagenUrl from ARTICULOS as ART"
                + " full join IMAGENES as I on ART.Id = I.IdArticulo"
                + " full join MARCAS as M on ART.IdMarca = M.Id"
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
                    
                if (!(datos.Lector["ImagenUrl"] is DBNull))
                    { aux.UrlImagen = (string)datos.Lector["ImagenUrl"]; }

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
