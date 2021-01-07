using System;
using System.Collections.Generic;
using SiteMercado.Domain.Entities;
using SiteMercado.Domain.Repositories;

namespace SiteMercado.Domain.Tests.Repositories
{
    public class FakeProductsRepository : IProductRepository
    {
        
        private readonly IEnumerable<Product> _context;

        public FakeProductsRepository(IEnumerable<Product> context)
        {
            _context = context;
        }

        public FakeProductsRepository(){

        }

        public void Create(Product product)
        {
        }

        public void Delete(Guid id)
        {
        }

        public IEnumerable<Product> GetAll()
        {
            return null;
        }

        public Product GetById(Guid id)
        {
            return new Product(null, 10, null);
        }

        public void Update(Product product)
        {
        }
    }
}