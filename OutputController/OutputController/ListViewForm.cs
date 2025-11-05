using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutputController
{
    public partial class ListViewForm : Form
    {

        public ListViewForm()
        {
            List<UserDetails> users = new List<UserDetails>();

            for (int i = 1; i <= 30; i++)
            {
                users.Add(new UserDetails(
                    i,
                    $"User{i}",
                    $"user{i}@example.com",
                    20 + (i % 10),        
                    GetCity(i)            
                ));
            }

            //for manula adding datas
            // 🔹 Step 1: Add Columns manually
            //dgv.Columns.Add("Id", "User ID");
            //dgv.Columns.Add("Name", "Name");
            //dgv.Columns.Add("Email", "Email");
            //dgv.Columns.Add("Age", "Age");
            //dgv.Columns.Add("City", "City");

            //// 🔹 Step 2: Add Rows manually
            //for (int i = 1; i <= 30; i++)
            //{
            //    dgv.Rows.Add(
            //        i,
            //        $"User{i}",
            //        $"user{i}@example.com",
            //        20 + (i % 10),
            //        GetCity(i)
            //    );
            //}


            DataGridView data = new DataGridView
            {
                Dock=DockStyle.Fill,
                AutoGenerateColumns=true,
                ReadOnly=true,
                AllowUserToAddRows = false

            };

            data.DataSource = users;
            Controls.Add(data);
        }
        static string GetCity(int index)
        {
            string[] cities = {
                "Bangalore", "Chennai", "Delhi", "Mumbai", "Pune",
                "Kolkata", "Hyderabad", "Ahmedabad", "Jaipur", "Lucknow"
            };
            return cities[index % cities.Length];
        }

        public class UserDetails
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public int Age { get; set; }
            public string City { get; set; }

            public UserDetails(int id, string name, string email, int age, string city)
            {
                Id = id;
                Name = name;
                Email = email;
                Age = age;
                City = city;
            }
        }
    }
}
