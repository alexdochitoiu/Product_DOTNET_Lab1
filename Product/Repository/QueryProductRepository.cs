using System;
using System.Collections.Generic;
using System.Linq;

namespace Products.Repository
{
    public class QueryProductRepository : IProductRepository
    {
        public IEnumerable<Product> Products { get; set; }

        public QueryProductRepository(IEnumerable<Product> products)
        {
            Products = products;
        }

        public IEnumerable<Product> RetriveActiveProducts() =>
            from p in Products where p.EndDate >= DateTime.Now && p.StartDate <= DateTime.Now select p;

        public IEnumerable<Product> RetriveInactiveProducts() =>
            from p in Products where p.EndDate < DateTime.Now || p.StartDate > DateTime.Now select p;

        public IEnumerable<Product> RetriveAllOrderByPriceDescending() =>
            from p in Products orderby p.Price descending select p;

        public IEnumerable<Product> RetriveAllOrderByPriceAscending() =>
            from p in Products orderby p.Price select p;

        public IEnumerable<Product> RetriveAll(string productName) =>
            from p in Products where p.ProductName.Contains(productName) select p;

        public IEnumerable<Product> RetriveAll(DateTime startDate, DateTime endDate) =>
            from p in Products where p.StartDate >= startDate && p.EndDate <= endDate select p;
    }
}
