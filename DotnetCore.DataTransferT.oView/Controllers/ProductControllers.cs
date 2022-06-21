using DotnetCore.DataTransferT.oView.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotNetCore.DataTransfet.ToView.Controllers
{
    public class ProductController : Controller
    {
        public List<Product> GetProductsList
        {
            get
            {
                List<Product> products = new List<Product>();
                products.Add(new Product { Id = 1, ProductName = "Elma", Price = 20, Stock = 10 });
                products.Add(new Product { Id = 2, ProductName = "Armut", Price = 20, Stock = 10 });
                products.Add(new Product { Id = 3, ProductName = "Karpuz", Price = 20, Stock = 10 });
                products.Add(new Product { Id = 4, ProductName = "Kavun", Price = 20, Stock = 10 });
                return products;
            }
        }
        public IActionResult List()
        {
            TempData["ProductList"] = JsonConvert.SerializeObject(GetProductsList);
            ViewBag.ProductList = JsonConvert.SerializeObject(GetProductsList);
            ViewData["ProdcutList"] = JsonConvert.SerializeObject(GetProductsList);
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            var temDataVeri = TempData["ProductList"];
            var viewBagDataVeri = ViewBag.ProductList;
            var viewDataVeri = ViewData["ProdcutList"];
            return View();
        }
    }
}
