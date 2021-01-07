using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiteMercado.Domain.Entities;
using SiteMercado.Domain.Queries;

namespace SiteMercado.Domain.Tests.QueryTests
{
    [TestClass]
    public class ProductQueryTests
    {
        private List<Product> _items;

        public ProductQueryTests()
        {
            _items = new List<Product>();
            _items.Add(new Product("Nome Produto 1", decimal.Parse("10,00"), "stringBase64"));
            _items.Add(new Product("Nome Produto 2", decimal.Parse("20,00"), "stringBase64"));
        }

        [TestMethod]
        public void QueryProducts()
        {
           var result = _items.AsQueryable().Where(ProductQueries.GetAll()).OrderBy(ProductQueries.WhereOrderBy());
           Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void QueryProductById()
        {
           var result = _items.AsQueryable().Where(ProductQueries.GetById(_items[0].Id)).OrderBy(ProductQueries.WhereOrderBy());
           Assert.AreEqual(1, result.Count());
        }
        
    }
}