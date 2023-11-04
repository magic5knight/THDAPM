using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using THDAPM.Models;
using System.Linq;
using THDAPM.Models;

public class ProductController : Controller
{
    IList<ProductModel> products = new List<ProductModel>();
    int nextID = 1;

    public ProductController()
    {
        products.Add(
            new ProductModel()
            {
                Id = nextID++,
                Name = "Iphone X",
                Quantity = 100,
                Price = 1200
            }
        );
        products.Add(
            new ProductModel()
            {
                Id = nextID++,
                Name = "Iphone 6",
                Quantity = 20,
                Price = 300
            }
        );
        products.Add(
            new ProductModel()
            {
                Id = nextID++,
                Name = "Iphone 8s",
                Quantity = 100,
                Price = 800
            }
        );
        products.Add(
            new ProductModel()
            {
                Id = nextID++,
                Name = "Iphone 7 plus",
                Quantity = 100,
                Price = 700
            }
        );
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(products);
    }

    [HttpGet]
    public IActionResult Create()
    {
        ProductModel productModel = new ProductModel();
        return View(productModel);
    }

    [HttpPost]
    public IActionResult Create(ProductModel productModel)
    {
        if (ModelState.IsValid)
        {
            ProductModel newProduct = new ProductModel();
            newProduct.Id = nextID++;
            newProduct.Name = productModel.Name;
            newProduct.Quantity = productModel.Quantity;
            newProduct.Price = productModel.Price;
            products.Add(newProduct);
            return View("Index", products);
        }
        else
        {
            return View(productModel);
        }
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        ProductModel oldProduct = products.FirstOrDefault(p => p.Id == id);
        return View(oldProduct);
    }

    [HttpPost]
    public IActionResult Edit(int id, ProductModel productModel)
    {
        if (ModelState.IsValid)
        {
            ProductModel oldProduct = products.FirstOrDefault(p => p.Id == id);
            oldProduct.Name = productModel.Name;
            oldProduct.Quantity = productModel.Quantity;
            oldProduct.Price = productModel.Price;
            ViewBag.Status = 1;
        }
        return View(productModel);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        ProductModel oldProduct = products.FirstOrDefault(p => p.Id == id);
        return View(oldProduct);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        ((List<ProductModel>)products).RemoveAll(p => p.Id == id);
        return View("Index", products);
    }
}
