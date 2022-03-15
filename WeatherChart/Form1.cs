using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherChart
{
    public partial class Form1 : Form
    {
        private ChartPainter Painter { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Painter = new ChartPainter(panel1.CreateGraphics(), panel1.Width, panel1.Height);
            var values = Parser.Parse(WeatherService.GetData()).ToList();

            Painter.Clear();
            Painter.DrawAxis();
            Painter.DrawValues(values, Color.Green);
        }
    }
}
