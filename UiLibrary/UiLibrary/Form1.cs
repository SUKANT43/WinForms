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
using System.Xml.Serialization;
using GoLibrary;
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

            Data data = new Data(1, "Sukant C", 10000);
            ObjectWriter.WriteXML(data, "data.xml",null);

        }
    }

    [Serializable]
    public class Data
    {
        [XmlElement]
        public int Id { get; set; }

        [XmlElement]
        public string Name { get; set; }

        [XmlElement]
        public decimal Price { get; set; }

        public Data(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
