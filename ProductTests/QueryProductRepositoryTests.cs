using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Products;
using Products.Repository;

namespace ProductTests
{
    [TestClass]
    public class QueryProductRepositoryTests
    {
        [TestMethod]
        public void When_RetriveActiveProductsCalled_ShouldReturn_TheFirstProduct()
        {
            //Arange
            var productsRepo = CreateSUT();
            IEnumerable<Product> expectedProducts = new ReadOnlyCollection<Product>(
                new[]
                {
                    new Product("name1", "description1", new DateTime(2017, 10, 14), new DateTime(2017, 10, 30), 1000.0)
                });
            //Act
            var activeProducts = productsRepo.RetriveActiveProducts();

            //Assert
            activeProducts.ShouldBeEquivalentTo(expectedProducts);
        }

        [TestMethod]
        public void When_RetriveInactiveProductsCalled_ShouldReturn_AllProductsWithoutTheFirstOne()
        {
            //Arange
            var productsRepo = CreateSUT();
            IEnumerable<Product> expectedProducts = new ReadOnlyCollection<Product>(
                new[]
                {
                    new Product("name2", "description2", new DateTime(2017, 9, 14), new DateTime(2017, 9, 18), 999),
                    new Product("name3", "description3", new DateTime(2017, 8, 14), new DateTime(2017, 8, 18), 8888),
                    new Product("name4", "description4", new DateTime(2017, 7, 14), new DateTime(2017, 7, 18), 7777),
                    new Product("name5", "description5", new DateTime(2017, 6, 14), new DateTime(2017, 6, 18), 6666),
                    new Product("name6", "description6", new DateTime(2017, 5, 14), new DateTime(2017, 5, 18), 5555),
                    new Product("name7", "description7", new DateTime(2017, 4, 14), new DateTime(2017, 4, 18), 1044400.0),
                    new Product("name8", "description8", new DateTime(2017, 3, 14), new DateTime(2017, 3, 18), 103300.0),
                    new Product("name9", "description9", new DateTime(2017, 2, 14), new DateTime(2017, 2, 18), 22),
                    new Product("name10", "description10", new DateTime(2017, 1, 14), new DateTime(2017, 1, 18), 10100.0)
                });
            //Act
            var inactiveProducts = productsRepo.RetriveInactiveProducts();

            //Assert
            inactiveProducts.ShouldBeEquivalentTo(expectedProducts);
        }

        [TestMethod]
        public void When_RetriveAllOrderByPriceDescendingCalled_ShouldReturn_AllProductsOrderedDescending()
        {
            //Arange
            var productsRepo = CreateSUT();

            //Act
            var orderedProducts = productsRepo.RetriveAllOrderByPriceDescending();

            //Assert
            orderedProducts.Should().BeInDescendingOrder(x => x.Price);
        }

        [TestMethod]
        public void When_RetriveAllOrderByPriceAscendingCalled_ShouldReturn_AllProductsOrderedAscending()
        {
            //Arange
            var productsRepo = CreateSUT();

            //Act
            var orderedProducts = productsRepo.RetriveAllOrderByPriceAscending();

            //Assert
            orderedProducts.Should().BeInAscendingOrder(x => x.Price);
        }

        [TestMethod]
        public void When_RetriveAllThatContainsNameCalled_ShouldReturn_AllProductsWhoContainsname1()
        {
            //Arange
            var productsRepo = CreateSUT();
            IEnumerable<Product> expectedProducts = new ReadOnlyCollection<Product>(
                new[]
                {
                    new Product("name1", "description1", new DateTime(2017, 10, 14), new DateTime(2017, 10, 30), 1000.0),
                    new Product("name10", "description10", new DateTime(2017, 1, 14), new DateTime(2017, 1, 18), 10100.0)
                });

            //Act
            var filteredProducts = productsRepo.RetriveAll("name1");

            //Assert
            filteredProducts.ShouldBeEquivalentTo(expectedProducts);
        }

        [TestMethod]
        public void When_RetriveAllByDateTime_ShouldReturn_AllProductsBetween14102017and18102017()
        {
            //Arange
            var productsRepo = CreateSUT();
            IEnumerable<Product> expectedProducts = new ReadOnlyCollection<Product>(
                new[]
                {
                    new Product("name1", "description1", new DateTime(2017, 10, 14), new DateTime(2017, 10, 30), 1000.0),
                    new Product("name2", "description2", new DateTime(2017, 9, 14), new DateTime(2017, 9, 18), 999),
                    new Product("name3", "description3", new DateTime(2017, 8, 14), new DateTime(2017, 8, 18), 8888),
                    new Product("name4", "description4", new DateTime(2017, 7, 14), new DateTime(2017, 7, 18), 7777),
                    new Product("name5", "description5", new DateTime(2017, 6, 14), new DateTime(2017, 6, 18), 6666),
                    new Product("name6", "description6", new DateTime(2017, 5, 14), new DateTime(2017, 5, 18), 5555)
                });

            //Act
            var retriveAll = productsRepo.RetriveAll(new DateTime(2017, 5, 14), new DateTime(2017, 10, 30));

            //Assert
            retriveAll.ShouldBeEquivalentTo(expectedProducts);
        }

        private static IProductRepository CreateSUT()
        {
            IEnumerable<Product> products =  new ReadOnlyCollection<Product>(
                new[]
                {
                    new Product("name1", "description1", new DateTime(2017, 10, 14), new DateTime(2017, 10, 30), 1000.0),
                    new Product("name2", "description2", new DateTime(2017, 9, 14), new DateTime(2017, 9, 18), 999),
                    new Product("name3", "description3", new DateTime(2017, 8, 14), new DateTime(2017, 8, 18), 8888),
                    new Product("name4", "description4", new DateTime(2017, 7, 14), new DateTime(2017, 7, 18), 7777),
                    new Product("name5", "description5", new DateTime(2017, 6, 14), new DateTime(2017, 6, 18), 6666),
                    new Product("name6", "description6", new DateTime(2017, 5, 14), new DateTime(2017, 5, 18), 5555),
                    new Product("name7", "description7", new DateTime(2017, 4, 14), new DateTime(2017, 4, 18), 1044400.0),
                    new Product("name8", "description8", new DateTime(2017, 3, 14), new DateTime(2017, 3, 18), 103300.0),
                    new Product("name9", "description9", new DateTime(2017, 2, 14), new DateTime(2017, 2, 18), 22),
                    new Product("name10", "description10", new DateTime(2017, 1, 14), new DateTime(2017, 1, 18), 10100.0)
                });
            return new QueryProductRepository(products);
        }
    }
}
