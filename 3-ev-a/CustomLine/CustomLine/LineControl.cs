using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace CustomLine
{


    class LineControl : Control
    {

        private int _horizontalLine;

        public int HorizontalLine
        {
            get => _horizontalLine;
            set
            {
                _horizontalLine = Math.Max(0, value);
            }
        }

        private int _verticalLine;

        public int VerticalLine
        {
            get => _verticalLine;
            set
            {
                _verticalLine = Math.Max(0, value);

            }
        }


        List<Point> horizontolList;
        List<Point> verticalList;

        Point selectedLine;

        bool isHorizontal;
        bool isVertical;

        int width, height;

        bool isDragging;

        public LineControl()
        {
            ;
            DoubleBuffered = true;
            horizontolList = new List<Point>();
            verticalList = new List<Point>();
            Paint += PaintLine;

        }


        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            InitializeLine();
        }


        private void InitializeLine()
        {
            horizontolList.Clear();
            verticalList.Clear();

            isHorizontal = false;
            isVertical = false;

            width = Width;
            height = Height;

            for (int i = 1; i <= _horizontalLine; i++)
            {
                int y = (height / (_horizontalLine + 1)) * i;
                horizontolList.Add(new Point(0, y));
            }
            for (int i = 1; i <= _verticalLine; i++)
            {
                int x = (width / (_verticalLine + 1)) * i;
                verticalList.Add(new Point(x, 0));
            }

            Invalidate();
        }


        private void PaintLine(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            DrawBorder(g);
            DrawLine(g);
            WriteMeasurement(g);
        }


        private void DrawBorder(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 2);
            g.DrawRectangle(pen, 0, 0, width - 1, height - 1);
        }

        private void DrawLine(Graphics g)
        {
            using (Pen pen = new Pen(Color.Black, 2))
            using (Pen redPen = new Pen(Color.Red, 2))
            {
                pen.DashStyle = DashStyle.DashDotDot;
                redPen.DashStyle = DashStyle.DashDotDot;

                foreach (Point p in horizontolList)
                {
                    Pen currentPen = p == selectedLine ? redPen : pen;
                    g.DrawLine(currentPen, 0, p.Y, width - 1, p.Y);
                }

                foreach (Point p in verticalList)
                {
                    Pen currentPen = p == selectedLine ? redPen : pen;
                    g.DrawLine(currentPen, p.X, 0, p.X, height - 1);
                }
            }
        }

        private void WriteMeasurement(Graphics g)
        {
            List<int> xPoints = new List<int> { 0 };
            List<int> yPoints = new List<int> { 0 };

            xPoints.AddRange(verticalList.Select(p => p.X));
            yPoints.AddRange(horizontolList.Select(p => p.Y));



            using (Font font = new Font("Arial", 9))
            using (Brush brush = new SolidBrush(Color.Blue))
            {
                for (int row = 0; row < yPoints.Count - 1; row++)
                {
                    for (int col = 0; col < xPoints.Count - 1; col++)
                    {
                        int cellWidth = xPoints[col + 1] - xPoints[col];
                        int cellHeight = yPoints[row + 1] - yPoints[row];

                        int centerX = xPoints[col] + cellWidth / 2 - 25;
                        int centerY = yPoints[row] + cellHeight / 2 - 10;

                        string text = $"{cellWidth} x {cellHeight}";

                        g.DrawString(text, font, brush, centerX, centerY);
                    }
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!isDragging)
            {
                selectedLine = Point.Empty;
                isHorizontal = false;
                isVertical = false;
                Cursor = Cursors.Default;


                foreach (Point p in horizontolList)
                {
                    if (Math.Abs(e.Y - p.Y) <= 5)
                    {
                        selectedLine = p;
                        isHorizontal = true;
                        Cursor = Cursors.SizeNS;
                        return;
                    }
                }

                foreach (Point p in verticalList)
                {
                    if (Math.Abs(e.X - p.X) <= 5)
                    {
                        selectedLine = p;
                        isVertical = true;
                        Cursor = Cursors.SizeWE;
                        return;
                    }
                }
            }

            else
            {
                if (isHorizontal)
                {
                    int index = horizontolList.IndexOf(selectedLine);
                    if (index != -1)
                    {
                        int newY = e.Y;
                        int minGap = 20;


                        if (index == 0)
                        {
                            if (horizontolList[0].Y - minGap < 0 && e.Y < minGap)
                            {
                                return;
                            }
                        }

                        if (index == horizontolList.Count - 1)
                        {
                            if (horizontolList[horizontolList.Count - 1].Y + minGap > Height && Height - e.Y < minGap)
                            {
                                return;
                            }

                        }


                        if (index > 0 && newY <= horizontolList[index - 1].Y + minGap)
                            return;

                        if (index < horizontolList.Count - 1 && newY >= horizontolList[index + 1].Y - minGap)
                            return;

                        selectedLine = new Point(0, e.Y);
                        horizontolList[index] = selectedLine;
                        Invalidate();
                    }
                }

                else if (isVertical)
                {
                    int index = verticalList.IndexOf(selectedLine);
                    if (index != -1)
                    {
                        int newX = e.X;
                        int minGap = 20;

                        if (index == 0)
                        {
                            if (verticalList[0].X - minGap < 0 && e.X < minGap)
                            {
                                return;
                            }
                        }

                        if (index == verticalList.Count - 1)
                        {
                            if (verticalList[verticalList.Count - 1].X + minGap > Width && Width - e.X < minGap)
                            {
                                return;
                            }
                        }

                        if (index > 0 && newX <= verticalList[index - 1].X + minGap)
                            return;

                        if (index < verticalList.Count - 1 && newX >= verticalList[index + 1].X - minGap)
                            return;


                        selectedLine = new Point(e.X, 0);
                        verticalList[index] = selectedLine;
                        Invalidate();
                    }
                }
            }

        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (selectedLine != Point.Empty)
            {
                isDragging = true;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            selectedLine = Point.Empty;
            isHorizontal = false;
            isVertical = false;
            isDragging = false;
            Cursor = Cursors.Default;
            Invalidate();
        }

    }
}
