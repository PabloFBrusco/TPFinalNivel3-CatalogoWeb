using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Modelo
{
    public class Articulo
    {
        public int id { get; set; }
        [DisplayName("Código")]
        public string codigo { get; set; }
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        [DisplayName("Descripción")]
        public string descripcion { get; set; }
        [DisplayName("Foto")]
        public string imagen { get; set; }
        [DisplayName("Precio")]
        public float precio { get; set; }
        [DisplayName("Categoría")]
        public  Categoria categoria { get; set; }
        [DisplayName("Marca")]
        public Marca marca { get; set; }
    }
}
