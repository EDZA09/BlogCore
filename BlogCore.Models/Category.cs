using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="Ingrese un Nombre para la Categoria")]
        [Display(Name = "Nombre Categoría")]
        public string Name { get; set; }
        [Display(Name = "Orden de Visualización")]
        public int? Order { get; set; }

    }
}
