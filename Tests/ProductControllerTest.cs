using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Shop.API.Controllers;
using Shop.API.Models;

namespace Test;

public class ProductControllerTest
{
    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void ShouldGetAllProducts()
    {
        var item = new Product()
        {
            CategoryId = 1,
            Description = null,
            StockId = 1,
            Name = "Bermuda",
            Price = 33.15M,
            Sku = "mmonwa",
            Category = null,
            Stock = null

        };
        Assert.Pass();

    }

}