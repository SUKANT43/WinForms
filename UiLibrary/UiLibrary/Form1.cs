using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialLibrary;
namespace UiLibrary
{
    public partial class Form1 : Form
    {
        private List<Data> items;

        public Form1()
        {
            InitializeComponent();
            items = new List<Data>
        {
            new Data(1, "Laptop", 55000),
            new Data(2, "Mouse", 1200),
            new Data(3, "Keyboard", 2500),
            new Data(4, "Monitor", 15000)
        };

            LinearGradientBrush brush = new LinearGradientBrush(new PointF(0,0),new PointF(Width,Height),Color.Red,Color.Black);

        }
    }

    public class Data
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Data(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
