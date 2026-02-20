using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomaizablePanel
{
    public class DragControl:Control
    {
        public int Row { get; set; } = 10;
        public int Column { get; set; } = 10;

        private List<int> rowHeight = new List<int>();
        private List<int> colWidth = new List<int>();

        private int height, width;

        int MIN = 25;

        bool isDrag = false;

        enum ResizeType
        {
            None,
            Row,
            Column
        }

        ResizeType selectedType = ResizeType.None;
        int resizedIndex = -1;

        public DragControl()
        {
            DoubleBuffered = true;
            InitiallizeGrid();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            InitiallizeGrid();
        }

        private void InitiallizeGrid()
        {
            rowHeight.Clear();
            colWidth.Clear();

            height = Height / Row;
            width = Width / Column;

            rowHeight.Add(0);
            for (int i = 1; i <= Row; i++)
                rowHeight.Add(i * height);

            colWidth.Add(0);
            for (int i = 1; i <= Column; i++)
                colWidth.Add(i * width);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Black,2);
            Pen redPen = new Pen(Color.Red, 2);
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            Font f = new Font("Segoe UI", 9);

            for (int i = 0; i < rowHeight.Count; i++)
            {
                int y = rowHeight[i];
                if (isDrag && resizedIndex == i && selectedType == ResizeType.Row)
                {
                    g.DrawLine(redPen, 0, y, Width, y);
                }
                else
                {
                    g.DrawLine(p, 0, y, Width, y);
                }

            }

            for (int j = 0; j < colWidth.Count; j++)
            {
                int x = colWidth[j];
                if (isDrag && resizedIndex == j && selectedType==ResizeType.Column)
                {
                    g.DrawLine(redPen, x, 0, x, Height);
                }
                else
                {
                    g.DrawLine(p, x, 0, x, Height);
                }
            }
            for (int r = 0; r < Row; r++)
            {
                for (int c = 0; c < Column; c++)
                {
                    int x = colWidth[c];
                    int y = rowHeight[r];
                    int w = colWidth[c + 1] - colWidth[c];
                    int h = rowHeight[r + 1] - rowHeight[r];

                    string txt = $"W:{w} H:{h}";
                    SizeF sz = g.MeasureString(txt, Font);

                    g.DrawString(txt, Font, Brushes.Black,
                        x + (w - sz.Width) / 2,
                        y + (h - sz.Height) / 2);
                }
            }

        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            isDrag = true;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            isDrag = false;
            selectedType = ResizeType.None;
            Cursor = Cursors.Default;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (!isDrag)
            {
                FindIndex(e);
                return;
            }
            ResizeGrid(e);
        }

        private void FindIndex(MouseEventArgs e)
        {
            Cursor = Cursors.Default;
            selectedType = ResizeType.None;

            int y = rowHeight[0];
            for(int i = 1; i <Row; i++)
            {
                y = rowHeight[i];
                if ((Math.Abs(e.Y - y) < 4))
                {
                    selectedType = ResizeType.Row;
                    Cursor = Cursors.HSplit;
                    resizedIndex = i;
                    return;
                }
            }

            int x = colWidth[0];
            for(int i = 1; i < Column; i++)
            {
                x = colWidth[i];
                if (Math.Abs(e.X - x) < 4)
                {
                    selectedType = ResizeType.Column;
                    Cursor = Cursors.VSplit;
                    resizedIndex = i;
                    return;
                }
            }
            Invalidate();
        }

        private void ResizeGrid(MouseEventArgs e)
        {
            if (selectedType == ResizeType.Row)
            {
                int y = rowHeight[resizedIndex];
                if (e.Y<=rowHeight[resizedIndex-1]+MIN || e.Y >= rowHeight[resizedIndex + 1] - MIN)
                {
                    return;
                }
                rowHeight[resizedIndex] = e.Y; 
            }

            if (selectedType == ResizeType.Column)
            {
                int x = colWidth[resizedIndex];
                if (e.X <= colWidth[resizedIndex - 1] + MIN || e.X >= colWidth[resizedIndex + 1] - MIN)
                {
                    return;
                }
                colWidth[resizedIndex] = e.X;
            }
            Invalidate();
        }


    }
}
