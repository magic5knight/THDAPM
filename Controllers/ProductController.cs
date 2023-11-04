using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using THDAPM.Models;

public class ProductController : Controller
{
    IList<ProductModel> products = new List<ProductModel>();
    
    public ProductController()
    {
        products.Add(new ProductModel()
        {
            Id = 1000,
            Name = "Iphone X",
            Quantity = 100,
            Price = 1200
        });
        products.Add(new ProductModel()
        {
            Id = 1001,
            Name = "Iphone 6",
            Quantity = 20,
            Price = 300
        });
        products.Add(new ProductModel()
        {
            Id = 1002,
            Name = "Iphone 8s",
            Quantity = 100,
            Price = 800
        });
        products.Add(new ProductModel()
        {
            Id = 1003,
            Name = "Iphone 7 plus",
            Quantity = 100,
            Price = 700
        });
    }

    public IActionResult Index()
    {
        ViewBag.products = products;
        return View();
    }
}