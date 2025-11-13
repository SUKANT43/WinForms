using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LineGame
{
    public partial class Form1 : Form
    {
        bool lev1 = false, lev2 = false, lev3 = false, lev4 = false, lev5 = false;

        int gridCount = 5;
        int cellSize = 80;

        bool isDrawing = false;
        Color activeColor = Color.Empty;
        List<Point> currentPath = new List<Point>();

        Dictionary<Color, List<EndPoint>> dict = new Dictionary<Color, List<EndPoint>>();
        Dictionary<Color, List<Point>> drawnPaths = new Dictionary<Color, List<Point>>();

        public Form1()
        {
            InitializeComponent();
            MinimumSize = new Size(900, 600);
            MaximumSize = new Size(900, 600);

            leftPanel.Paint += LeftPanelPaint;
            leftPanel.MouseDown += LeftPanelMouseDown;
            leftPanel.MouseMove += LeftPanelMouseMove;
            leftPanel.MouseUp += LeftPanelMouseUp;
        }

        private void LeftPanelPaint(object s, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen gridPen = new Pen(Color.LightGray, 2))
            {
                for (int i = 0; i <= gridCount; i++)
                {
                    g.DrawLine(gridPen, i * cellSize, 0, i * cellSize, gridCount * cellSize);
                    g.DrawLine(gridPen, 0, i * cellSize, gridCount * cellSize, i * cellSize);
                }
            }

            foreach (var kv in drawnPaths)
            {
                using (Pen p = new Pen(kv.Key, 8) { StartCap = LineCap.Round, EndCap = LineCap.Round })
                {
                    var pts = kv.Value;
                    for (int i = 0; i < pts.Count - 1; i++)
                    {
                        g.DrawLine(p, ToPixel(pts[i]), ToPixel(pts[i + 1]));
                    }
                }
            }

            foreach (var kv in dict)
            {
                Color color = kv.Key;
                foreach (var ep in kv.Value)
                {
                    DrawEndPoint(g, color, ep.Start);
                    DrawEndPoint(g, color, ep.End);
                }
            }

            if (isDrawing && activeColor != Color.Empty && currentPath.Count > 1)
            {
                using (Pen p = new Pen(activeColor, 6) { DashStyle = DashStyle.Dot })
                {
                    for (int i = 0; i < currentPath.Count - 1; i++)
                        g.DrawLine(p, ToPixel(currentPath[i]), ToPixel(currentPath[i + 1]));
                }
            }
        }

        private void DrawEndPoint(Graphics g, Color c, Point gridPos)
        {
            int radius = 20;
            int x = (gridPos.X * cellSize + (cellSize / 2) - radius / 2);
            int y = (gridPos.Y * cellSize + (cellSize / 2) - radius / 2);

            using (SolidBrush brush = new SolidBrush(c))
            {
                g.FillEllipse(brush, x, y, radius, radius);
            }
        }

        private void LeftPanelMouseDown(object sender, MouseEventArgs e)
        {
            Point grid = ToGrid(e.Location);

            foreach (var kv in dict)
            {
                foreach (var ep in kv.Value)
                {
                    if (grid == ep.Start || grid == ep.End)
                    {
                        isDrawing = true;
                        activeColor = kv.Key;
                        currentPath.Clear();
                        currentPath.Add(grid);
                        leftPanel.Invalidate();
                        return;
                    }
                }
            }
        }

        private void LeftPanelMouseMove(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;

            Point grid = ToGrid(e.Location);
            Point last = currentPath[currentPath.Count - 1];

            if (IsAdjacent(grid, last))
            {
                if (!currentPath.Contains(grid))
                {
                    currentPath.Add(grid);
                    leftPanel.Invalidate();
                }
            }
        }

        private void LeftPanelMouseUp(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;
            isDrawing = false;

            Point endGrid = ToGrid(e.Location);

            foreach (var ep in dict[activeColor])
            {
                if ((currentPath[0] == ep.Start && endGrid == ep.End) ||
                    (currentPath[0] == ep.End && endGrid == ep.Start))
                {
                    drawnPaths[activeColor] = new List<Point>(currentPath);
                    break;
                }
            }

            currentPath.Clear();
            activeColor = Color.Empty;
            leftPanel.Invalidate();
        }

        private bool IsAdjacent(Point a, Point b)
        {
            int dx = Math.Abs(a.X - b.X);
            int dy = Math.Abs(a.Y - b.Y);
            return (dx + dy == 1);
        }

        private Point ToGrid(Point p)
        {
            int x = Math.Max(0, Math.Min(gridCount - 1, p.X / cellSize));
            int y = Math.Max(0, Math.Min(gridCount - 1, p.Y / cellSize));
            return new Point(x, y);
        }

        private Point ToPixel(Point grid)
        {
            return new Point(grid.X * cellSize + cellSize / 2, grid.Y * cellSize + cellSize / 2);
        }


        private void Level1ButtonClick(object sender, EventArgs e)
        {
            lev1 = true; lev2 = lev3 = lev4 = lev5 = false;
            SetupLevel1();
        }

        private void Level2buttonClick(object sender, EventArgs e)
        {
            lev2 = true; lev1 = lev3 = lev4 = lev5 = false;
            SetupLevel2();
        }

        private void Level3ButtonClick(object sender, EventArgs e)
        {
            lev3 = true; lev1 = lev2 = lev4 = lev5 = false;
            SetupLevel3();
        }

        private void Level4ButtonClick(object sender, EventArgs e)
        {
            lev4 = true; lev1 = lev2 = lev3 = lev5 = false;
            SetupLevel4();
        }

        private void Level5ButoonClick(object sender, EventArgs e)
        {
            lev5 = true; lev1 = lev2 = lev3 = lev4 = false;
            SetupLevel5();
        }


        private void SetupLevel1()
        {
            dict = new Dictionary<Color, List<EndPoint>>
            {
                { Color.Gold, new List<EndPoint>{ new EndPoint(new Point(0,0), new Point(0,2)) } },
                { Color.Red,  new List<EndPoint>{ new EndPoint(new Point(1,0), new Point(1,2)) } },
                { Color.Blue, new List<EndPoint>{ new EndPoint(new Point(2,0), new Point(2,2)) } },
            };

            gridCount = 3;
            drawnPaths.Clear();
            leftPanel.Invalidate();
        }


        private void SetupLevel2()
        {
            dict = new Dictionary<Color, List<EndPoint>>
            {
                { Color.Red,   new List<EndPoint>{ new EndPoint(new Point(0,0), new Point(3,0)) } },
                { Color.Blue,  new List<EndPoint>{ new EndPoint(new Point(1,1), new Point(3,2)) } },
                { Color.Green, new List<EndPoint>{ new EndPoint(new Point(0,3), new Point(2,2)) } },
                { Color.Gold,  new List<EndPoint>{ new EndPoint(new Point(2,0), new Point(1,3)) } },
            };

            gridCount = 4;
            drawnPaths.Clear();
            leftPanel.Invalidate();
        }

        private void SetupLevel3()
        {
            dict = new Dictionary<Color, List<EndPoint>>
            {
                { Color.Red, new List<EndPoint>{ new EndPoint(new Point(0,0), new Point(4,4)) } },
                { Color.Blue, new List<EndPoint>{ new EndPoint(new Point(0,4), new Point(4,0)) } },
                { Color.Green, new List<EndPoint>{ new EndPoint(new Point(1,1), new Point(3,3)) } },
                { Color.Gold, new List<EndPoint>{ new EndPoint(new Point(2,0), new Point(2,4)) } },
                { Color.Orange, new List<EndPoint>{ new EndPoint(new Point(0,2), new Point(4,2)) } },
            };

            gridCount = 5;
            drawnPaths.Clear();
            leftPanel.Invalidate();
        }

        private void SetupLevel4()
        {
            dict = new Dictionary<Color, List<EndPoint>>
            {
                { Color.Red, new List<EndPoint>{ new EndPoint(new Point(0,0), new Point(5,5)) } },
                { Color.Blue, new List<EndPoint>{ new EndPoint(new Point(1,5), new Point(5,1)) } },
                { Color.Green, new List<EndPoint>{ new EndPoint(new Point(0,5), new Point(5,0)) } },
                { Color.Purple, new List<EndPoint>{ new EndPoint(new Point(2,2), new Point(4,4)) } },
                { Color.Orange, new List<EndPoint>{ new EndPoint(new Point(3,0), new Point(3,5)) } },
                { Color.Gold, new List<EndPoint>{ new EndPoint(new Point(0,3), new Point(5,2)) } },
            };

            gridCount = 6;
            drawnPaths.Clear();
            leftPanel.Invalidate();
        }

        private void SetupLevel5()
        {
            dict = new Dictionary<Color, List<EndPoint>>
            {
                { Color.Red, new List<EndPoint>{ new EndPoint(new Point(0,0), new Point(6,6)) } },
                { Color.Blue, new List<EndPoint>{ new EndPoint(new Point(0,6), new Point(6,0)) } },
                { Color.Green, new List<EndPoint>{ new EndPoint(new Point(3,0), new Point(3,6)) } },
                { Color.Purple, new List<EndPoint>{ new EndPoint(new Point(1,1), new Point(5,5)) } },
                { Color.Orange, new List<EndPoint>{ new EndPoint(new Point(0,3), new Point(6,3)) } },
                { Color.Cyan, new List<EndPoint>{ new EndPoint(new Point(2,5), new Point(5,2)) } },
                { Color.Gold, new List<EndPoint>{ new EndPoint(new Point(1,5), new Point(5,1)) } },
            };

            gridCount = 7;
            drawnPaths.Clear();
            leftPanel.Invalidate();
        }
    }

    public class EndPoint
    {
        public Point Start { get; set; }
        public Point End { get; set; }

        public EndPoint(Point s, Point e)
        {
            Start = s;
            End = e;
        }
    }
}
