using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace storev.Models
{
    public class Meals
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public string Photo { get; set; }
    }
}