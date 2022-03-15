using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherChart
{
    public class ChartPainter
    {
        private Graphics Canvas { get; set; }
        private int Height { get; set; }
        private int Width { get; set; }
        private int Min { get; set; }
        private int Max { get; set; }
        private int Padding { get; set; } = 20;
        
        public ChartPainter(Graphics graphics, int width, int height, int min = -30, int max = 30)
        {
            Canvas = graphics;
            Width = width;
            Height = height;
            Min = min;
            Max = max;
        }

        public void DrawAxis()
        {
            var min = Min;
            var max = Max;

            Canvas.DrawLine(new Pen(Color.Gray, 2), Padding, Padding, Padding, Height - Padding);

            for (int i = min; i <= max; i++)
            {
                if (i % 5 != 0)
                {
                    continue;
                }
                int y = GetY(i);
                if (i == 0)
                {
                    Canvas.DrawLine(new Pen(Color.Gray, 2), Padding, y, Width - Padding, y);
                }
                Canvas.DrawLine(new Pen(Color.Gray, 2), Padding - 5, y, Padding + 5, y);
                Canvas.DrawString(i.ToString(), new Font("Courier new", 10), new SolidBrush(Color.Black), Padding + 15, Height - y - 7);
            }
        }

        public void DrawValues(List<int> values, Color color)
        {
            var segment = (Width - 2 * Padding) / (double)(values.Count - 1);
            var hSegment = (Height - 2 * Padding) / (double)(Max - Min);
            var y0 = GetY(0);

            for (int i = 1; i < values.Count; i++)
            {
                var y1 = GetY(values[i - 1]);
                var y2 = GetY(values[i]);
                var x1 = GetX(i - 1, values.Count);
                var x2 = GetX(i, values.Count);
                Canvas.DrawLine(new Pen(Color.Gray, 2), x2, y0 - 5, x2, y0 + 5);
                Canvas.DrawLine(new Pen(color, 3), x1, y1, x2, y2);
                Canvas.FillEllipse(new SolidBrush(color), x1 - 3, y1 - 3, 6, 6);
                
            }
            for (int i = 1; i < values.Count; i++)
            {
                Canvas.DrawString(
                    values[i].ToString(), 
                    new Font("Courier new", 10), 
                    new SolidBrush(Color.Black), 
                    GetX(i, values.Count) + 5, 
                    GetY(values[i]) - 7
                );
            }
        }

        public void Clear()
        {
            Canvas.Clear(Color.White);
        }

        private int GetY(int y)
        {
            var segment = (double)(Height - 2 * Padding) / (Max - Min);
            y -= Min;
            return (int)(Height - Padding - segment * y);
        }

        private int GetX(int x, int count)
        {
            var segment = (double)(Width - 2 * Padding) / (count - 1);
            return (int)(segment * x + Padding);
        }
    }
}
