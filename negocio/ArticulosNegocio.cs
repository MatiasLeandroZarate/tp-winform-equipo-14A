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
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            string datos = "";

            try
            {

                conexion.ConnectionString = Conexion(datos);
                comando.CommandType = System.Data.CommandType.Text;
                //comando.CommandText = "Select Codigo,Nombre,Descripcion,Precio From ARTICULOS";
                comando.CommandText = "Select ART.Id, ART.Nombre , ART.Precio, I.ImagenUrl from ARTICULOS as ART inner join IMAGENES as I on ART.Id = I.IdArticulo";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Articulos aux = new Articulos();
                    /*
                    aux.CodigoArticulo = (string)lector["Codigo"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.Precio = (decimal)lector["Precio"];
                    */
                    aux.ID = (int)lector["Id"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Precio = (decimal)lector["Precio"];
                    aux.UrlImagen = (string)lector["ImagenUrl"];

                    lista.Add(aux);
                }
                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
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

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            string datos = "";
            try {

                conexion.ConnectionString = Conexion(datos);
                comando.CommandType = System.Data.CommandType.Text;
                
                comando.CommandText = "Select ART.Id ,ART.Codigo,M.Descripcion as Marca,  ART.Nombre , ART.Descripcion, ART.Precio,  C.Descripcion as Categoria, I.ImagenUrl from ARTICULOS as ART"
                + " inner join IMAGENES as I on ART.Id = I.IdArticulo"
                + " inner join MARCAS as M on ART.IdMarca = M.Id"
                + " inner join CATEGORIAS as C on ART.IdCategoria = C.Id";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.Marca = new Marca();
                    aux.Categoria = new Categoria();
                   

                    aux.ID = (int)lector["Id"];
                    aux.CodigoArticulo = (string)lector["Codigo"];

                    aux.Marca.DescripcionMarca = (string)lector["Marca"];
                    
                    aux.Nombre = (string)lector["Nombre"];
                    aux.DescripcionART = (string)lector["Descripcion"];
                    aux.Precio = (decimal)lector["Precio"];

                    aux.Categoria.DescripcionCategoria = (string)lector["Categoria"];
                    aux.UrlImagen = (string)lector["ImagenUrl"];

                    lista.Add(aux);
                   
                }
                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Conexion(string conexion)
            {
                conexion = "server=(local)\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
                return conexion;
            } 
        
    }
}
