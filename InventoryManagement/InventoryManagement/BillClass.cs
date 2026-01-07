using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    public class BillClass
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public double OriginalPrice { get; set; }
        public double OfferedPrice { get; set; }
        public BillClass(int id,string product,int quantity, double originalPrice, double offeredPrice)
        {
            Id = id;
            Product = product;
            Quantity = quantity;
            OriginalPrice = originalPrice;
            OfferedPrice = offeredPrice;
        }
    }
}
