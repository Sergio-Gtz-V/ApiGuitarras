namespace ApiGuitarras.Entidades
{
    public class Guitarra
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Name { get; set; }

        public List<Tienda> Tiendas { get; set; }
    }
}
