using System;
using System.Collections.Generic;
using System.Linq;

namespace Products.Repository
{
    public class MethodProductRepository : IProductRepository
    {
        public MethodProductRepository(IEnumerable<Product> products)
        {
            Products = products;
        }

        public IEnumerable<Product> Products { get; set; }

        public IEnumerable<Product> RetriveActiveProducts() =>
            Products.Where(p => p.EndDate >= DateTime.Now && p.StartDate <= DateTime.Now);
        
        public IEnumerable<Product> RetriveInactiveProducts() =>
            Products.Where(p => p.EndDate < DateTime.Now || p.StartDate > DateTime.Now);

        public IEnumerable<Product> RetriveAllOrderByPriceDescending() =>
            Products.OrderByDescending(p => p.Price);

        public IEnumerable<Product> RetriveAllOrderByPriceAscending() =>
            Products.OrderBy(p => p.Price);

        public IEnumerable<Product> RetriveAll(string productName) =>
            Products.Where(p => p.ProductName.Contains(productName));

        public IEnumerable<Product> RetriveAll(DateTime startDate, DateTime endDate) =>
            Products.Where(p => p.StartDate >= startDate && p.EndDate <= endDate);
    }
}