using SiteMercado.Domain.Commands.Contracts;

namespace SiteMercado.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
      ICommandResult Handle(T command);
    }
}