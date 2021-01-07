using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiteMercado.Domain.Commands;
using SiteMercado.Domain.Handlers;
using SiteMercado.Domain.Tests.Repositories;

namespace SiteMercado.Domain.Tests.HandlerTests
{
   [TestClass]
   public class CreateProductHandlerTests
   {
      [TestMethod]
      public void CreateProductInValidTest()
      {
           var command = new CreateProductCommand("", 0, null);
           var handler = new ProductHandler(new FakeProductsRepository());
           var result = (GenericCommandResult)handler.Handle(command);
           Assert.AreEqual(result.Sucess, false);
      }

      [TestMethod]
      public void CreateProductValidTest()
      {
           var command = new CreateProductCommand("Nome Produto 1", decimal.Parse("10,00"), "stringbase64");
           var handler = new ProductHandler(new FakeProductsRepository());
           var result = (GenericCommandResult)handler.Handle(command);
           Assert.AreEqual(result.Sucess, true);
      }
   }
}