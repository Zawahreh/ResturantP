using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using storev.Models;

namespace storev.Controllers.Api
{
    public class CMSController : ApiController
    {
        private ApplicationDbContext _context;
        public CMSController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpGet]
        public IEnumerable<Meals> GetMeals()
        {
            return _context.Meals;
        }

        [HttpGet]
        public Meals GetMeal(int id)
        {
            var meal = _context.Meals.SingleOrDefault(m => m.Id == id);

            return meal;
        }

        [HttpPost]
        public void AddMeal()
        {
            var req = HttpContext.Current.Request;
            if (req.Files.Count > 0)
            {
                foreach (string ph in req.Files)
                {
                    var postedFile = req.Files[ph];
                    var filePath = HttpContext.Current.Server.MapPath("~/Content/images/"+postedFile.FileName);
                    postedFile.SaveAs(filePath);
                }

                var nameValueCollection = HttpContext.Current.Request.Form;
                var m = new Meals
                {
                    Name = nameValueCollection["Name"],
                    Price = Convert.ToDouble(nameValueCollection["Price"]),
                    Category = nameValueCollection["Category"],
                    Photo = nameValueCollection["Photo"],
                };

                _context.Meals.Add(m);
                _context.SaveChanges();
            }
        }

        [HttpDelete]
        public void DeleteMeal(int id)
        {
            var meal = _context.Meals.SingleOrDefault(m=>m.Id == id);
            File.Delete(HttpContext.Current.Server.MapPath("~/Content/images/" + meal.Photo));
            _context.Meals.Remove(meal);
            _context.SaveChanges();
        }
        [HttpDelete]
        public void DeleteMeals()
        {
            var all = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/content/images"));
            var f = all.GetFiles();
            foreach (var item in f)
            {
                File.Delete(HttpContext.Current.Server.MapPath("~/content/images" + item.Name));
            }
            _context.Meals.RemoveRange(_context.Meals);
            _context.SaveChanges();
        }

        [HttpPut]
        public void EditMeal()
        {
            var req = HttpContext.Current.Request;
            if (req.Files.Count > 0)
            {
                foreach (string ph in req.Files)
                {
                    var postedFile = req.Files[ph];
                    var filePath = HttpContext.Current.Server.MapPath("~/Content/images/" + postedFile.FileName);
                    postedFile.SaveAs(filePath);
                }

                var nvc = HttpContext.Current.Request.Form;
                var id = Convert.ToInt32(nvc["Id"]);
                var meal = _context.Meals.SingleOrDefault(m => m.Id == id);
                meal.Name = nvc["Name"];
                meal.Price = Convert.ToDouble(nvc["Price"]);
                meal.Category = nvc["Category"];
                meal.Photo = nvc["Photo"];

                _context.SaveChanges();
            }
        }
    }
}
