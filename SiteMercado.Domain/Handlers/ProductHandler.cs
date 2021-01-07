using System;
using Flunt.Notifications;
using SiteMercado.Domain.Commands;
using SiteMercado.Domain.Commands.Contracts;
using SiteMercado.Domain.Entities;
using SiteMercado.Domain.Handlers.Contracts;
using SiteMercado.Domain.Repositories;

namespace SiteMercado.Domain.Handlers
{
    public class ProductHandler : 
    Notifiable,
    IHandler<CreateProductCommand>,
    IHandler<UpdateProductCommand>,
    IHandler<DeleteProductCommand>

    {
       private readonly IProductRepository _repository;

       public ProductHandler(IProductRepository repository)
       {
           _repository = repository;
       }
        public ICommandResult Handle(CreateProductCommand command)
        {
           command.Validate(); 
           if (command.Invalid)
            return new GenericCommandResult(false, "Ocorreu um erro na criação do produto, verifique os dados...", command.Notifications);

           Product product = new Product(command.Name, command.Value, command.Image);

           _repository.Create(product);

           return new GenericCommandResult(true, "Produto registrado com sucesso", product);
            
        }

        public ICommandResult Handle(UpdateProductCommand command)
        {
           command.Validate(); 
           if (command.Invalid)
            return new GenericCommandResult(false, "Ocorreu um erro na atualização do produto, verifique os dados...", command.Notifications);

          Product product = _repository.GetById(command.Id);

          product.Name = command.Name;
          product.Value = command.Value;
          product.Image = command.Image;

           _repository.Update(product);

           return new GenericCommandResult(true, "Produto atualizado com sucesso", product);
        }

        public ICommandResult Handle(DeleteProductCommand command)
        {
           command.Validate(); 
           if (command.Invalid)
            return new GenericCommandResult(false, "Ocorreu um erro na exclusão do produto, verifique os dados...", command.Notifications);
           
           Product product = _repository.GetById(command.Id);
          
           _repository.Delete(command.Id);

           return new GenericCommandResult(true, "Produto excluido com sucesso", product);
        }
    }
}
