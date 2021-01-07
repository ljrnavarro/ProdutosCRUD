using System;
using Flunt.Notifications;
using Flunt.Validations;
using SiteMercado.Domain.Commands.Contracts;

namespace SiteMercado.Domain.Commands
{
    public class DeleteProductCommand: Notifiable, ICommand
    {
        public DeleteProductCommand() { }
        public DeleteProductCommand(Guid id)
        {
           Id = id;
        }
        public Guid Id {get; set;}
        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .AreNotEquals(Id, Guid.Empty, "Id", "Guid não pode ser vazio.")
            );
        }
        
    }
}