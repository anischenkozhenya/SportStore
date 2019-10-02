using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportStore.Models;
using SportStore.Infrastructure;
using SportStore.Models.ViewModels;

namespace SportStore.Controllers
{
    public class CartController:Controller
    {
        private IProductRepository repository;
        private Cart cart;
        public CartController(IProductRepository repo,Cart cartService)
        {
            repository = repo;
            cart = cartService;
        }
        public RedirectToActionResult AddToCart(int productid,string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productid);
            if (product!=null)
            {
                cart.AddItem(product, 1);               
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToActionResult RemoveFromCart(int productid, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productid);
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }


        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }

        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            return cart;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl=returnUrl
            });
        }
    }
}
