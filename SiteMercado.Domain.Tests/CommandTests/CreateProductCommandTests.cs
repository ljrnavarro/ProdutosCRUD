using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiteMercado.Domain.Commands;

namespace SiteMercado.Domain.Tests
{
    [TestClass]
    public class CreateProductCommandTests
    {
        [TestMethod]
        public void CreateProductInvalidCommand()
        {
            var command = new CreateProductCommand("", decimal.Parse("0"), null );
            command.Validate();
            Assert.AreEqual(command.Valid, false);
        }
       
       
        [TestMethod]
        public void CreateProductValidCommand()
        {
            var command = new CreateProductCommand("Nome Produto 1", decimal.Parse("10,00"), "stringbase64");
            command.Validate();
            Assert.AreEqual(command.Valid, true);
        }
    }
}
