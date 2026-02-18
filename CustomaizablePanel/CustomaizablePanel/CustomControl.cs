using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CustomaizablePanel
{
    class CustomControl : Control
    {
        public int Row { get; set; } = 10;
        public int Column { get; set; } = 10;

        List<int> rowHeights = new List<int>();
        List<int> colWidths = new List<int>();

        const int MIN = 25;

        enum ResizeType { None, Row, Column }
        ResizeType resizeMode = ResizeType.None;

        int resizeIndex = -1;
        bool dragging = false;

        public CustomControl()
        {
            DoubleBuffered = true;
            BackColor = Color.White;

            Resize += (s, e) => InitGrid();
            MouseDown += OnMouseDownGrid;
            MouseUp += OnMouseUpGrid;
            MouseMove += OnMouseMoveGrid;
            Paint += PaintPage;

            InitGrid();
        }

        // create equal cells
        public void InitGrid()
        {
            if (Row <= 0 || Column <= 0) return;

            rowHeights.Clear();
            colWidths.Clear();

            int h = Height / Row;
            int w = Width / Column;

            for (int i = 0; i < Row; i++)
                rowHeights.Add(h);

            for (int i = 0; i < Column; i++)
                colWidths.Add(w);

            Invalidate();
        }

        // DRAW GRID
        public void PaintPage(object s, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Black, 2);
            Font f = new Font("Segoe UI", 9);

            int y = 0;

            for (int r = 0; r < Row; r++)
            {
                int x = 0;

                for (int c = 0; c < Column; c++)
                {
                    Rectangle rect = new Rectangle(x, y, colWidths[c], rowHeights[r]);

                    g.DrawRectangle(p, rect);

                    string txt = $"R{r + 1},C{c + 1}";
                    SizeF sz = g.MeasureString(txt, f);

                    g.DrawString(txt, f, Brushes.Black,
                        rect.X + (rect.Width - sz.Width) / 2,
                        rect.Y + (rect.Height - sz.Height) / 2);

                    x += colWidths[c];
                }

                y += rowHeights[r];
            }
        }

        // -------- MOUSE LOGIC --------

        void OnMouseDownGrid(object s, MouseEventArgs e)
        {
            dragging = true;
        }

        void OnMouseUpGrid(object s, MouseEventArgs e)
        {
            dragging = false;
            resizeMode = ResizeType.None;
            Cursor = Cursors.Default;
        }

        void OnMouseMoveGrid(object s, MouseEventArgs e)
        {
            if (!dragging)
            {
                DetectResizeLine(e);
                return;
            }

            ResizeGrid(e);
        }

        // detect near line
        void DetectResizeLine(MouseEventArgs e)
        {
            resizeMode = ResizeType.None;
            Cursor = Cursors.Default;

            int y = 0;
            for (int i = 0; i < Row - 1; i++)
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
            for (int i = 0; i < Column - 1; i++)
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

        // resize logic
        void ResizeGrid(MouseEventArgs e)
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

                int newSize = colWidths[resizeIndex] + delta;
                int nextSize = colWidths[resizeIndex + 1] - delta;

                if (newSize > MIN && nextSize > MIN)
                {
                    colWidths[resizeIndex] = newSize;
                    colWidths[resizeIndex + 1] = nextSize;
                }
            }

            Invalidate();
        }

        int GetRowLine(int i)
        {
            int y = 0;
            for (int k = 0; k <= i; k++)
                y += rowHeights[k];
            return y;
        }

        int GetColLine(int i)
        {
            int x = 0;
            for (int k = 0; k <= i; k++)
                x += colWidths[k];
            return x;
        }
    }
}
