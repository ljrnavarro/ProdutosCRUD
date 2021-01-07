using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiteMercado.Domain.Commands;
using SiteMercado.Domain.Handlers;
using SiteMercado.Domain.Tests.Repositories;

namespace SiteMercado.Domain.Tests.HandlerTests
{
   [TestClass]
   public class UpdateProductHandlerTests
   {
      [TestMethod]
      public void UpdateProductInValidTest()
      {
          var command = new UpdateProductCommand(new Guid(), "", decimal.Parse("0"), null );
          var handler = new ProductHandler(new FakeProductsRepository());
          var result = (GenericCommandResult)handler.Handle(command);
          Assert.AreEqual(result.Sucess, false);
      }

      [TestMethod]
      public void UpdateProductValidTest()
      {
         var command = new UpdateProductCommand(new Guid(), "Nome Produto 1", decimal.Parse("10,00"), "stringBase64");
         var handler = new ProductHandler(new FakeProductsRepository());
         var result = (GenericCommandResult)handler.Handle(command);
         Assert.AreEqual(result.Sucess, true);
      }
   }
}