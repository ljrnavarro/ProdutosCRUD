using System;
using System.Linq.Expressions;
using SiteMercado.Domain.Entities;

namespace SiteMercado.Domain.Queries
{
    public static class ProductQueries
    {
        public static Expression<Func<Product, bool>> GetAll()
        {
            return x => x.Id != Guid.Empty;
        }

         public static Expression<Func<Product, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }
        public static Expression<Func<Product, string>> WhereOrderBy()
        {
            return x => x.Name;
        }
    }
}