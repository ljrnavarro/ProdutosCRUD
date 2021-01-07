namespace SiteMercado.Domain.Entities
{
    public class Product: Entity
    {
        public Product(string name, decimal value, string image)
        {
            Name = name;
            Value = value;
            Image = image;
        }

        public string Name {get; set;}
        public decimal Value {get; set;}
        public string Image {get; set;}
    }
}