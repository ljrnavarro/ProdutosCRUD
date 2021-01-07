using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiteMercado.Domain.Commands;

namespace SiteMercado.Domain.Tests
{
    [TestClass]
    public class DeleteProductCommandTests
    {
        [TestMethod]
        public void DeleteProductInvalidCommand()
        {
            Guid guidID = Guid.Empty;
            var command = new DeleteProductCommand(guidID);
            command.Validate();
            Assert.AreEqual(command.Valid, false);
        }
       
        [TestMethod]
        public void DeleteProductValidCommand()
        {
            var command = new DeleteProductCommand(new Guid("11111111111111111111111111111111"));
            command.Validate();
            Assert.AreEqual(command.Valid, true);
        }
    }
}
