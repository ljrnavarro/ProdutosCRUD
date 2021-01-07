using System.Collections.Generic;
using System.Linq;
using SiteMercado.Domain.Entities;
using SiteMercado.Domain.Queries;
using SiteMercado.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using CursoOnline.Domain.Infra.Contexts;
using System;

namespace CursoOnline.Domain.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Product product)
        {
            _context.Product.Add(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
           _context.Entry(product).State = EntityState.Modified;
           _context.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var product = _context.Product
                          .AsNoTracking()
                          .AsQueryable()
                          .FirstOrDefault(ProductQueries.GetById(id));
            _context.Product.Remove(product);
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Product
                   .Where(ProductQueries.GetAll())
                   .OrderBy(ProductQueries.WhereOrderBy());
        }

        public Product GetById(Guid id)
        {
           return _context.Product
                  .AsNoTracking()
                  .Where(ProductQueries.GetById(id))
                  .FirstOrDefault();
        }
    }
}