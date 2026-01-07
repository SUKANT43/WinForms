using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
   public class InventoryItem
    {
        
        public int Id { get; }
        public string Category { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        
        private static int idGenerator = 1;

        public InventoryItem(string productName, string category, double price,double discount,int stock)
        {
            Id = idGenerator++;
            Category = category;
            ProductName = productName;
            Price = price;
            Discount = discount;
            Stock = stock;
        }

    }
}
