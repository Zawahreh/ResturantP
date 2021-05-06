using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace storev.Models
{
    public class BillDetail
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public int MealId { get; set; }
        public int Qty { get; set; }
    }
}