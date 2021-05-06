using storev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using storev.ViewModels;

namespace storev.Controllers
{
    public class MenuController : Controller
    {
        private ApplicationDbContext _context;
        public static string catigoryId = "Pizza"; //Of the standard category to view on the index

        public MenuController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Menu
        public ActionResult Index()
        {
            ViewData["x"] = _context.Meals;
            var standardCategory = _context.Meals.Where(x => x.Category == catigoryId);
            ShowCart();
            return View(standardCategory);
        }
        public ActionResult Details(string id)
        {
            ViewData["x"] = _context.Meals;
            catigoryId = id;
            var meals = _context.Meals.Where(m => m.Category == catigoryId);
            if (meals==null)
                return HttpNotFound();
            ShowCart();
            
            return View("index", meals);
        }

        [Authorize]
        public ActionResult AddToCart(byte id)
        {
            var cart = _context.Carts.SingleOrDefault(c => c.MealId == id && c.Email == User.Identity.Name);
          

            if (cart == null)
            {
                var newCart = new Cart();
                newCart.Email = User.Identity.Name;
                newCart.MealId = id;
                newCart.Qty = 1;
                _context.Carts.Add(newCart);

            }
            else if (cart != null)
            {
                cart.Qty++;
            }
            _context.SaveChanges();

            ShowCart();

            return RedirectToAction("index");
        }

        public ActionResult ShowCart()
        {
            var query = from m in _context.Meals
                        join c in _context.Carts
                        on m.Id equals c.MealId
                        where c.Email == User.Identity.Name
                        select new CartMealVM { Cart = c, Meal = m };

            ViewData["cm"] = query;

            return RedirectToAction("index");
        }

        public ActionResult DeleteFromCart(int id)
        {
            var cart = _context.Carts.SingleOrDefault(c => c.Id == id);

            if (cart.Qty == 1)
            {
                _context.Carts.Remove(cart);
            }
            else if (cart.Qty > 1)
            {
                cart.Qty--;
            }

            _context.SaveChanges();
             return RedirectToAction("index");
        }
    }
}