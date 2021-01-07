using System;
using Flunt.Notifications;
using Flunt.Validations;
using SiteMercado.Domain.Commands.Contracts;

namespace SiteMercado.Domain.Commands
{
    public class UpdateProductCommand: Notifiable, ICommand
    {
        public UpdateProductCommand() { }
        public UpdateProductCommand(Guid id, string name, decimal value, string image)
        {
            Id = Id;
            Name = name;
            Value = value;
            Image = image;
        }
        public Guid Id {get; set;}
        public string Name {get; set;}
        public decimal Value {get; set;}
        public string Image {get; set;}
        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNull(Id, "Id", "Identificador é obrigatório")
                .IsNotNullOrEmpty(Name, "Name", "Atributo Name é obrigatório")
                .IsGreaterThan(Value, 0, "Value", "Valor precisa ser maior que zero")
            );
        }
        
    }
}