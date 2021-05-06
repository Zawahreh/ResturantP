using storev.Models;
using storev.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace storev.Controllers.Api
{
    public class OrdersController : ApiController
    {
        private ApplicationDbContext _context;
        public OrdersController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IEnumerable<Bill> GetBills()
        {
            return _context.Bills.Where(b=>b.Status != "Delivered");
        }

        [HttpGet]
        public IEnumerable<BillMealDeatailsVM> GetBillMealDeatails(int id)
        {
            return from b in _context.Bills
                   join d in _context.BillDetails on b.Id equals d.BillId
                   join m in _context.Meals on d.MealId equals m.Id
                   where b.Id == id
                   select new BillMealDeatailsVM
                   {
                       Meals = m,
                       Bill = b,
                       BillDetail = d
                   };
        }

        [HttpPut]
        public void ChangeBillStatus(int id)
        {
            var bill = _context.Bills.SingleOrDefault(b => b.Id == id);
            bill.Status = "Read";
            _context.SaveChanges ();
        }

        [HttpGet]
        public void DeliveredBillStatus(int billNo)
        {
            _context.Database.ExecuteSqlCommand("UPDATE bills set status= 'Delivered' WHERE id = {0}",billNo);
            _context.SaveChanges();
        }

    }
}
