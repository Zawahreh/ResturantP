using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using storev.Models;

namespace storev.ViewModels
{
    public class CartMealVM
    {
        public Meals Meal { get; set; }
        public Cart Cart { get; set; }
    }
}