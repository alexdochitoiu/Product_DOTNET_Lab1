using System;
using System.Collections.Generic;

namespace Products.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; set; }

        IEnumerable<Product> RetriveActiveProducts();
        IEnumerable<Product> RetriveInactiveProducts();
        IEnumerable<Product> RetriveAllOrderByPriceDescending();
        IEnumerable<Product> RetriveAllOrderByPriceAscending();
        IEnumerable<Product> RetriveAll(string productName);
        IEnumerable<Product> RetriveAll(DateTime startDate, DateTime endDate);
    }
}
