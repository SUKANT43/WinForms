using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace expenseTracker
{
    class ExpenseData
    {
        public int Id { get; }
        public DateTime SelectedDate { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public float Amount { get; set; }
        public string Description { get; set; }

        private static int idGenerator=1;
        public static float Balance { get; private set; }

        public ExpenseData(DateTime selectedDate,string type,string category,float amount,string description)
        {
            Id = idGenerator++;
            SelectedDate = selectedDate;
            Type = type;
            Category = category;
            Amount = amount;
            Description = description;
            if (type == "Income")
            {
                Balance += amount;
            }
            else
            {
                if (Balance < 0)
                {
                    Balance -= amount;
                }
                else
                {
                    Balance -= amount;
                }
            }
        }
    }
}
