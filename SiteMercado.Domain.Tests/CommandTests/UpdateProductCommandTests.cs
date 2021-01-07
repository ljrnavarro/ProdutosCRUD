using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiteMercado.Domain.Commands;

namespace SiteMercado.Domain.Tests
{
    [TestClass]
    public class UpdateProductCommandTests
    {
        [TestMethod]
        public void UpdateProductInvalidCommand()
        {
            var command = new UpdateProductCommand(new Guid(), "", decimal.Parse("0"), null );
            command.Validate();
            Assert.AreEqual(command.Valid, false);
        }
       
        [TestMethod]
        public void UpdateProductValidCommand()
        {
            var command = new UpdateProductCommand(new Guid(), "Nome Produto 1", decimal.Parse("10,00"), "stringBase64");
            command.Validate();
            Assert.AreEqual(command.Valid, true);
        }
    }
}
