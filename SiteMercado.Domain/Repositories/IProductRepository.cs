using System;
using System.Collections.Generic;
using SiteMercado.Domain.Entities;

namespace SiteMercado.Domain.Repositories
{
    public interface IProductRepository
    {
        void Create(Product product);
        void Update(Product product);
        void Delete(Guid id);
        Product GetById(Guid id);
        IEnumerable<Product> GetAll();
     }
}