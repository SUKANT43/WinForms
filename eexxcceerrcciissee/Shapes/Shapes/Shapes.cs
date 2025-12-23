using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Shapes
{
   abstract class Shapes
    {
        public abstract bool Contains(Point p);
        public abstract void Draw(Graphics g);
        public abstract void Move(int dx, int dy,Size s);
        public abstract bool IsSelected { get; set; }
        public abstract void Resize(int dx,int dy,Size s);
    }
}
