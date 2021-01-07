using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiteMercado.Domain.Entities;

namespace SiteMercado.Domain.Tests.EntityTests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void InvalidValidEntity()
        {
            var product = new Product("", 0, null);
            bool valid = !(string.IsNullOrEmpty(product.Name) || product.Value < 0 || product.Image == null);
            Assert.AreEqual(valid, false);
        }

        [TestMethod]
        public void ValidEntity()
        {
            var product = new Product("Nome Produto 1", decimal.Parse("10,00"), "stringBase64");
            bool valid = !(string.IsNullOrEmpty(product.Name) || product.Value < 0 || product.Image == null);
            Assert.AreEqual(valid, true);
        }
    }
}