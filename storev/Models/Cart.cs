using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace storev.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public byte MealId { get; set; }
        public int Qty { get; set; }
    }
}