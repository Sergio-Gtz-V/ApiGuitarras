using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGuitarras.Entidades
{
    public class Tienda
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [StringLength(maximumLength: 20, ErrorMessage = "El campo {0} superó los 20 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [StringLength(maximumLength: 50, ErrorMessage = "El campo {0} superó los 50 caracteres.")]
        public string Direccion { get; set; }

        [Url(ErrorMessage = "El string no cumple con caracteristicas de un URL")]
        [NotMapped]
        public string TiendaURL { get; set; }

        public Guitarra Guitarra { get; set; }

        
    }
}
