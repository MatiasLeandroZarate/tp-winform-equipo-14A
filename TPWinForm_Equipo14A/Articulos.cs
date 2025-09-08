using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPWinForm_Equipo14A
{
    class Articulos
    {
        public string CodigoArticulo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        Marca Marca { get; set; }
        Categoria Categoria { get; set; }
        public string Imagen { get; set;}
        public decimal Precio { get; set; }

        
        /*public List<Articulos> Listar()
        {
            List<Articulos> listado = new List<Articulos>();
            return listado;
        }
        
        public void Agregar()
        {
        
        }
        

        public void Modificar()
        {
            
        }
        
        public void Eliminar()
        {
            
        }
        
        public void VerDetalle()
        {
            
        }*/
    }
}
