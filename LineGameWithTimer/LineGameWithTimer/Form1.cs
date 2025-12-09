using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace LineGameWithTimer
{
    public class Preview
    {
        public Color Color { get; set; }
        public Point Point { get; set; }
        public Preview(Color c, Point p)
        {
            Color = c;
            Point = p;
        }
    }

    public partial class Form1 : Form
    {
        bool level1, level2, level3, level4, level5;
        int cellSize = 80;
        int gridCount = 3;

        Dictionary<Color, List<EndPoint>> dict = new Dictionary<Color, List<EndPoint>>();
        Dictionary<Color, List<Point>> paths = new Dictionary<Color, List<Point>>();
        List<Preview> previewList = new List<Preview>();

        bool isDrawing = false;
        bool isPreviewMode = false;
        Color activeColor = Color.Empty;

        Timer previewTimer;
        int previewIndex = 0;

        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered",
            System.Reflection.BindingFlags.SetProperty |
            System.Reflection.BindingFlags.Instance |
            System.Reflection.BindingFlags.NonPublic,
            null, mainPanel, new object[] { true });

            level1 = true;
            mainPanel.Paint += PanelPaint;

            mainPanel.MouseDown += MainPanel_MouseDown;
            mainPanel.MouseMove += MainPanel_MouseMove;
            mainPanel.MouseUp += MainPanel_MouseUp;

            MaximumSize = new Size(900, 800);
            MinimumSize = new Size(900, 800);

            previewTimer = new Timer();
            previewTimer.Interval = 500;
            previewTimer.Tick += PreviewTimer_Tick;

            setupLevel1();
        }

        public void PanelPaint(object s, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen p = new Pen(Color.Black, 2))
            {
                for (int i = 0; i <= gridCount; i++)
                {
                    g.DrawLine(p, i * cellSize, 0, i * cellSize, cellSize * gridCount);
                    g.DrawLine(p, 0, i * cellSize, cellSize * gridCount, i * cellSize);
                }
            }

            foreach (var items in dict)
            {
                Color c = items.Key;
                foreach (var it in items.Value)
                {
                    drawEndPoint(g, c, it.Start);
                    drawEndPoint(g, c, it.End);
                }
            }

            if (isPreviewMode)
            {
                drawPreviewLine(g);
            }
            else
            {
                foreach (var kv in paths)
                {
                    Color c = kv.Key;
                    var pts = kv.Value;
                    if (pts == null || pts.Count < 2) continue;

                    using (Pen pen = new Pen(c, 12))
                    {
                        pen.StartCap = LineCap.Round;
                        pen.EndCap = LineCap.Round;
                        pen.LineJoin = LineJoin.Round;

                        for (int i = 0; i < pts.Count - 1; i++)
                        {
                            Point p1 = GridToPixelCenter(pts[i]);
                            Point p2 = GridToPixelCenter(pts[i + 1]);
                            g.DrawLine(pen, p1, p2);
                        }
                    }
                }
            }
        }

        private void drawEndPoint(Graphics g, Color c, Point gridPos)
        {
            int radius = 20;
            Point center = GridToPixelCenter(gridPos);

            int x = center.X - radius / 2;
            int y = center.Y - radius / 2;

            using (SolidBrush b = new SolidBrush(c))
            {
                g.FillEllipse(b, x, y, radius, radius);
            }
        }

        private Point GridToPixelCenter(Point gridPos)
        {
            int x = gridPos.X * cellSize + (cellSize / 2);
            int y = gridPos.Y * cellSize + (cellSize / 2);
            return new Point(x, y);
        }

        private Point PixelToGrid(Point pixel)
        {
            int gx = pixel.X / cellSize;
            int gy = pixel.Y / cellSize;
            return new Point(gx, gy);
        }

        private void level1ButtonClick(object sender, EventArgs e)
        {
            StopPreview();
            dict.Clear();
            paths.Clear();
            level1 = true;
            level2 = level3 = level4 = level5 = false;
            gridCount = 3;
            setupLevel1();
            mainPanel.Invalidate();
        }

        private void level2ButtonClick(object sender, EventArgs e)
        {
            StopPreview();
            dict.Clear();
            paths.Clear();
            level2 = true;
            level1 = level3 = level4 = level5 = false;
            gridCount = 5;
            setupLevel2();
            mainPanel.Invalidate();
        }

        private void level3ButtonClick(object sender, EventArgs e)
        {
            StopPreview();
            dict.Clear();
            paths.Clear();
            level3 = true;
            level1 = level2 = level4 = level5 = false;
            gridCount = 5;
            setupLevel3();
            mainPanel.Invalidate();
        }

        private void level4ButtonClick(object sender, EventArgs e)
        {
            StopPreview();
            dict.Clear();
            paths.Clear();
            level4 = true;
            level1 = level2 = level3 = level5 = false;
            gridCount = 6;
            setupLevel4();
            mainPanel.Invalidate();
        }

        private void level5ButtonClick(object sender, EventArgs e)
        {
            StopPreview();
            dict.Clear();
            paths.Clear();
            level5 = true;
            level1 = level2 = level3 = level4 = false;
            gridCount = 7;
            setupLevel5();
            mainPanel.Invalidate();
        }

        private void MainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (isPreviewMode) return;
            if (e.Button != MouseButtons.Left) return;

            if (TryGetEndpointAt(e.Location, out Color color, out Point gridPos))
            {
                isDrawing = true;
                activeColor = color;

                if (!paths.ContainsKey(color))
                    paths[color] = new List<Point>();
                else
                    paths[color].Clear();

                paths[color].Add(gridPos);
                mainPanel.Invalidate();
            }
        }

        private void MainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPreviewMode) return;
            if (!isDrawing || activeColor == Color.Empty) return;

            Point gridPos = PixelToGrid(e.Location);
            if (gridPos.X < 0 || gridPos.Y < 0 ||
                gridPos.X >= gridCount || gridPos.Y >= gridCount)
                return;

            var currentPath = paths[activeColor];
            if (currentPath.Count == 0) return;

            Point last = currentPath[currentPath.Count - 1];
            if (!IsNeighbor(last, gridPos)) return;
            if (gridPos == last) return;

            if (IsEndPointOfOtherColor(gridPos, activeColor))
                return;

            if (IsEndPointOfColor(gridPos, activeColor) && !currentPath.Contains(gridPos))
            {
                currentPath.Add(gridPos);
                isDrawing = false;
                activeColor = Color.Empty;
                mainPanel.Invalidate();
                CheckLevelCompleted();
                return;
            }

            int existingIndex = currentPath.IndexOf(gridPos);
            if (existingIndex >= 0)
            {
                currentPath.RemoveRange(existingIndex + 1, currentPath.Count - existingIndex - 1);
                mainPanel.Invalidate();
                return;
            }

            if (IsCellUsedByOtherPath(gridPos, activeColor))
                return;

            currentPath.Add(gridPos);
            mainPanel.Invalidate();
        }

        private void MainPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            if (isPreviewMode) return;
            isDrawing = false;
            activeColor = Color.Empty;
        }

        private bool IsNeighbor(Point a, Point b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y) == 1;
        }

        private bool TryGetEndpointAt(Point mouse, out Color color, out Point gridPos)
        {
            int radius = 20;
            int r2 = radius * radius;

            foreach (var kv in dict)
            {
                Color c = kv.Key;
                foreach (var ep in kv.Value)
                {
                    foreach (Point gp in new[] { ep.Start, ep.End })
                    {
                        Point center = GridToPixelCenter(gp);
                        int dx = mouse.X - center.X;
                        int dy = mouse.Y - center.Y;
                        if (dx * dx + dy * dy <= r2)
                        {
                            color = c;
                            gridPos = gp;
                            return true;
                        }
                    }
                }
            }

            color = Color.Empty;
            gridPos = Point.Empty;
            return false;
        }

        private bool IsEndPointOfColor(Point cell, Color c)
        {
            if (!dict.ContainsKey(c)) return false;
            foreach (var ep in dict[c])
            {
                if (ep.Start == cell || ep.End == cell)
                    return true;
            }
            return false;
        }

        private bool IsEndPointOfOtherColor(Point cell, Color c)
        {
            foreach (var kv in dict)
            {
                if (kv.Key == c) continue;

                foreach (var ep in kv.Value)
                {
                    if (ep.Start == cell || ep.End == cell)
                        return true;
                }
            }
            return false;
        }

        private bool IsCellUsedByOtherPath(Point cell, Color c)
        {
            foreach (var kv in paths)
            {
                if (kv.Key == c) continue;
                if (kv.Value.Contains(cell))
                    return true;
            }
            return false;
        }

        private void CheckLevelCompleted()
        {
            foreach (var kv in dict)
            {
                Color c = kv.Key;
                var eps = kv.Value;
                if (eps.Count == 0) return;

                var ep = eps[0];

                if (!paths.TryGetValue(c, out var path))
                    return;

                if (path == null || path.Count < 2)
                    return;

                Point first = path.First();
                Point last = path.Last();

                bool ok = (first == ep.Start && last == ep.End) ||
                          (first == ep.End && last == ep.Start);
                if (!ok) return;
            }
                MessageBox.Show("Level Completed");
            

            previewList.Clear();
            foreach (var path in paths)
            {
                Color c = path.Key;
                foreach (var po in path.Value)
                {
                    previewList.Add(new Preview(c, po));
                }
            }

            if (previewList.Count < 2) return;

            isPreviewMode = true;
            previewIndex = 1;
            previewTimer.Start();
            mainPanel.Invalidate();
        }

        private void drawPreviewLine(Graphics g)
        {
            if (previewList.Count < 2) return;
            int max = Math.Min(previewIndex, previewList.Count - 1);

            for (int i = 1; i <= max; i++)
            {
                Preview prev = previewList[i - 1];
                Preview curr = previewList[i];

                if (prev.Color != curr.Color) continue;

                using (Pen pen = new Pen(curr.Color, 12))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    pen.LineJoin = LineJoin.Round;

                    Point p1 = GridToPixelCenter(prev.Point);
                    Point p2 = GridToPixelCenter(curr.Point);
                    g.DrawLine(pen, p1, p2);
                }
            }
        }

        private void PreviewTimer_Tick(object sender, EventArgs e)
        {
            if (!isPreviewMode) return;

            if (previewIndex < previewList.Count - 1)
            {
                previewIndex++;
                mainPanel.Invalidate();
            }
            else
            {
               
                previewTimer.Stop();
                isPreviewMode = false;
                mainPanel.Invalidate();

                if (level5)
                    MessageBox.Show("You completed Level 5.\nYou won all the levels! 🎉", "You Won");
                else
                    MessageBox.Show("Level completed!", "Nice!");
            }
        }

        private void StopPreview()
        {
            if (previewTimer != null && previewTimer.Enabled)
                previewTimer.Stop();
            isPreviewMode = false;
            previewIndex = 0;
            previewList.Clear();
        }

        private void setupLevel1()
        {
            paths.Clear();
            dict = new Dictionary<Color, List<EndPoint>>() {
                { Color.Gold, new List<EndPoint>{ new EndPoint(new Point(0,0), new Point(0,2)) } },
                { Color.Red,  new List<EndPoint>{ new EndPoint(new Point(1,0), new Point(1,2)) } },
                { Color.Blue, new List<EndPoint>{ new EndPoint(new Point(2,0), new Point(2,2)) } },
            };
        }

        private void setupLevel2()
        {
            paths.Clear();
            dict = new Dictionary<Color, List<EndPoint>>
            {
                { Color.Red, new List<EndPoint> { new EndPoint(new Point(0,0), new Point(1,3)) } },
                { Color.Lime, new List<EndPoint> { new EndPoint(new Point(1,0), new Point(4,1)) } },
                { Color.Gold, new List<EndPoint> { new EndPoint(new Point(3,1), new Point(4,3)) } },
                { Color.Orange, new List<EndPoint> { new EndPoint(new Point(0,2), new Point(2,1)) } },
                { Color.Cyan, new List<EndPoint> { new EndPoint(new Point(3,3), new Point(4,4)) } }
            };
        }

        private void setupLevel3()
        {
            paths.Clear();
            dict = new Dictionary<Color, List<EndPoint>>
            {
                { Color.Red, new List<EndPoint>{ new EndPoint(new Point(4,0), new Point(0,1)) } },
                { Color.Blue, new List<EndPoint>{ new EndPoint(new Point(1,1), new Point(0,4)) } },
                { Color.Green, new List<EndPoint>{ new EndPoint(new Point(3,2), new Point(4,4)) } },
                { Color.Gold, new List<EndPoint>{ new EndPoint(new Point(4,1), new Point(1,4)) } },
                { Color.Orange, new List<EndPoint>{ new EndPoint(new Point(2,4), new Point(3,3)) } },
            };
        }

        private void setupLevel4()
        {
            paths.Clear();
            dict = new Dictionary<Color, List<EndPoint>>
            {
                { Color.Red, new List<EndPoint>{ new EndPoint(new Point(2,0), new Point(1,4)) } },
                { Color.Yellow, new List<EndPoint>{ new EndPoint(new Point(1,1), new Point(3,4)) } },
                { Color.Violet, new List<EndPoint>{ new EndPoint(new Point(2,1), new Point(3,3)) } },
                { Color.Green, new List<EndPoint>{ new EndPoint(new Point(2,5), new Point(5,5)) } },
                { Color.Pink, new List<EndPoint>{ new EndPoint(new Point(5,2), new Point(4,3)) } },
                { Color.Blue, new List<EndPoint>{ new EndPoint(new Point(5,1), new Point(4,2)) } },
            };
        }

        private void setupLevel5()
        {
            paths.Clear();
            dict = new Dictionary<Color, List<EndPoint>>
            {
                { Color.Red, new List<EndPoint>{ new EndPoint(new Point(0,0), new Point(3,1)) } },
                { Color.Blue, new List<EndPoint>{ new EndPoint(new Point(0,1), new Point(2,1)) } },
                { Color.Green, new List<EndPoint>{ new EndPoint(new Point(6,0), new Point(4,1)) } },
                { Color.Purple, new List<EndPoint>{ new EndPoint(new Point(6,1), new Point(5,5)) } },
                { Color.Orange, new List<EndPoint>{ new EndPoint(new Point(6,2), new Point(1,4)) } },
                { Color.Gold, new List<EndPoint>{ new EndPoint(new Point(1,5), new Point(4,6)) } },
            };
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
