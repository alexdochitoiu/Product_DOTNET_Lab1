using System;

namespace Products
{
    public class Product
    {
        public Guid Id { get; }

        public string ProductName { get; }

        public string ProductDescription { get; }

        public DateTime StartDate { get; }

        public DateTime EndDate { get; }

        public double Price { get; }

        public Product(string productName, string productDescription, DateTime startDate, DateTime endDate, double price)
        {
            if(productName.Length > 50 || productDescription.Length > 500)
                throw new ArgumentOutOfRangeException();

            Id = new Guid();
            ProductName = productName;
            ProductDescription = productDescription;
            StartDate = startDate;
            EndDate = endDate;
            Price = price;
        }
    }
}
