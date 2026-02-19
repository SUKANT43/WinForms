using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CustomaizablePanel
{

    class CustomControl : Control
    {
        public int Row { get; set; } = 6;
        public int Col { get; set; } = 6;
        List<int> rowHeights = new List<int>();
        List<int> colWidths = new List<int>();
        const int MIN = 25;
        bool dragging = false;
        int resizeIndex = -1;
        enum ResizeType
        {
            None,
            Row,
            Column
        }

        ResizeType resizeMode = ResizeType.None;

        public CustomControl()
        {
            DoubleBuffered = true;
            Paint += PaintPage;
            InitGrid();
        }

        public void InitGrid()
        {
            if (Row <= 0 || Col <= 0) return;
            rowHeights.Clear();
            colWidths.Clear();
            int h = Height / Row;
            int w = Width / Col;
            for (int i = 0; i < Row; i++)
            {
                rowHeights.Add(h);
            }
            for (int i = 0; i < Col; i++)
            {
                colWidths.Add(w);
            }
            Invalidate();
        }

        public void PaintPage(object s, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Black, 2);
            Font f = new Font("Segoe UI", 9);

            int y = 0;

            for (int r = 0; r < Row; r++)
            {
                int x = 0;
                for (int c = 0; c < Col; c++)
                {
                    Rectangle rect = new Rectangle(x, y, colWidths[c], rowHeights[r]);
                    g.DrawRectangle(p, rect);
                    string txt = $"Height:{rect.Height} Width:{rect.Width}";
                    SizeF sz = g.MeasureString(txt, f);
                    g.DrawString(txt, f, Brushes.Black,
                        rect.X + (rect.Width - sz.Width) / 2,
                        rect.Y + (rect.Height - sz.Height) / 2);
                    x += colWidths[c];
                }
                y += rowHeights[r];
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            InitGrid();
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            dragging = true;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            dragging = false;
            resizeMode = ResizeType.None;
            Cursor = Cursors.Default;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (!dragging)
            {
                DetectResizeLine(e);
                return;
            }
            ResizeGrid(e);

        }

        private void DetectResizeLine(MouseEventArgs e)
        {
            resizeMode = ResizeType.None;
            Cursor = Cursors.Default;
            int y = 0;
            for (int i = 0; i < Row; i++)
            {
                y += rowHeights[i];
                if (Math.Abs(e.Y - y) < 4)
                {
                    resizeMode = ResizeType.Row;
                    resizeIndex = i;
                    Cursor = Cursors.HSplit;
                    return;
                }
            }

            int x = 0;
            for (int i = 0; i < Col; i++)
            {
                x += colWidths[i];
                if (Math.Abs(e.X - x) < 4)
                {
                    resizeMode = ResizeType.Column;
                    resizeIndex = i;
                    Cursor = Cursors.VSplit;
                    return;
                }
            }
        }

        private void ResizeGrid(MouseEventArgs e)
        {
            if (resizeMode == ResizeType.Row)
            {
                int line = GetRowLine(resizeIndex);
                int delta = e.Y - line;
                int newSize = rowHeights[resizeIndex] + delta;
                int nextSize = rowHeights[resizeIndex + 1] - delta;

                if (newSize > MIN && nextSize > MIN)
                {
                    rowHeights[resizeIndex] = newSize;
                    rowHeights[resizeIndex + 1] = nextSize;
                }

            }

            if (resizeMode == ResizeType.Column)
            {
                int line = GetColLine(resizeIndex);
                int delta = e.X - line;
                int newSize = colWidths[resizeIndex]+delta;
                int nextSize = colWidths[resizeIndex + 1] - delta;
                if (newSize > MIN && nextSize > MIN)
                {
                    colWidths[resizeIndex] = newSize;
                    colWidths[resizeIndex + 1] = nextSize;
                }
            }
            Invalidate();
        }

        private int GetRowLine(int i)
        {
            int y = 0;
            for(int k = 0; k <= i; k++)
            {
                y += rowHeights[k];
            }
            return y;
        }

        private int GetColLine(int i)
        {
            int x = 0;
            for(int k = 0; k <= i; k++)
            {
                x += colWidths[k];
            }
            return x;
        }

    }
}
