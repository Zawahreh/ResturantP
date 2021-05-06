using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Schema;
using storev.Models;

namespace storev.Controllers
{
    public class BillsController : Controller
    {
        public static double Total = 0;
        private ApplicationDbContext _context;
        public BillsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Bills
        public ActionResult Save()
        {
            //Select Cart of The user:
            IEnumerable<Cart> itemsInCart = from c in _context.Carts
                                            where c.Email == User.Identity.Name
                                            select c;
         
            if (itemsInCart == null)
            {
                return Content("Cart is empty");
            }

           
            //Add to Bill:
            var bill = new Bill
            {
                Date = DateTime.Now,
                Email = User.Identity.Name,
                Status = "Received"
            };
            _context.Bills.Add(bill);
            _context.SaveChanges();


            //Last Bill:
            var lastBillId = (from b in _context.Bills
                                where b.Email == User.Identity.Name
                                select b.Id).Max();
            
            //Add bill Details:
            foreach (var item in itemsInCart)
            {
                _context.BillDetails.Add(new BillDetail
                {
                    BillId = lastBillId,
                    MealId = item.MealId,
                    Qty = item.Qty
                });
            }

            //Delete Data from cart:
            _context.Carts.RemoveRange(itemsInCart);

            _context.SaveChanges();
            return View();
            
        }
    }
}