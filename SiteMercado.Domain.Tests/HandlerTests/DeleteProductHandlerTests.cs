using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiteMercado.Domain.Commands;
using SiteMercado.Domain.Handlers;
using SiteMercado.Domain.Tests.Repositories;

namespace SiteMercado.Domain.Tests.HandlerTests
{
   [TestClass]
   public class DeleteProductHandlerTests
   {
      [TestMethod]
      public void DeleteProductInValidTest()
      {
           Guid guidID = Guid.Empty;
           var command = new DeleteProductCommand(guidID);
           var handler = new ProductHandler(new FakeProductsRepository());
           var result = (GenericCommandResult)handler.Handle(command);
           Assert.AreEqual(result.Sucess, false);
      }

      [TestMethod]
      public void DeleteProductValidTest()
      {
           var command = new DeleteProductCommand(new Guid("11111111111111111111111111111111"));
           var handler = new ProductHandler(new FakeProductsRepository());
           var result = (GenericCommandResult)handler.Handle(command);
           Assert.AreEqual(result.Sucess, true);
      }
   }
}