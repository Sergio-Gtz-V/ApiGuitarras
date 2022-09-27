namespace ApiGuitarras.Entidades
{
    public class Tienda
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public Guitarra Guitarra { get; set; }

        
    }
}
