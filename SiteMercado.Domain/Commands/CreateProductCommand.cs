using Flunt.Notifications;
using Flunt.Validations;
using SiteMercado.Domain.Commands.Contracts;

namespace SiteMercado.Domain.Commands
{
    public class CreateProductCommand: Notifiable, ICommand
    {
        public CreateProductCommand() { }
        public CreateProductCommand(string name, decimal value, string image)
        {
            Name = name;
            Value = value;
            Image = image;
        }
        public string Name {get; set;}
        public decimal Value {get; set;}
        public string Image {get; set;}
        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNullOrEmpty(Name, "Name", "Atributo Name é obrigatório")
                .IsGreaterThan(Value, 0, "Value", "Valor precisa ser maior que zero")
                .IsNotNullOrEmpty(Image, "Imagem", "Imagem é obrigatória")
            );
        }
    }
}