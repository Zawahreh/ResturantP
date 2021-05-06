using storev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace storev.ViewModels
{
    public class BillMealDeatailsVM
    {
        public Bill Bill { get; set; }
        public BillDetail BillDetail { get; set; }
        public Meals Meals { get; set; }

    }
}