using ApiGuitarras.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGuitarras.Entidades
{
    public class Guitarra
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [StringLength(maximumLength: 20, ErrorMessage = "El campo {0} superó los 20 caracteres.")]
        [PrimeraLetraMayuscula]
        public string Brand { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [StringLength(maximumLength:30, ErrorMessage = "El campo {0} superó los 30 caracteres.")]
        [PrimeraLetraMayuscula]
        public string Name { get; set; }

        [Range(1,5,ErrorMessage ="El campo {0} no cumple con el rango de tipos de guitarra disponibles (1-5).")]
        [NotMapped]
        public int Type { get; set; }

        [Url(ErrorMessage = "El string no cumple con caracteristicas de un URL")]
        [NotMapped]
        public string BrandURL { get; set; }


        public List<Tienda> Tiendas { get; set; }
    }
}
