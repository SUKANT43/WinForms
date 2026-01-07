using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    public class BillingData
    {
        public int Id { get;}
        public List<BillClass> ProductList { get; set; }
        private static int idGenerator=1;
        public double Total { get; set; }
        public double Tax { get; set; }
        public double TotalDiscount { get; set; }
        public string CreatedAt { get; private set; }
        public BillingData(List<BillClass> list, double total, double tax, double totalDiscount)
        {
            Id = idGenerator++;
            ProductList=list;
            Total = total;
            Tax = tax;
            TotalDiscount = totalDiscount;
            CreatedAt = DateTime.Now.ToString();
        }
    }
}
