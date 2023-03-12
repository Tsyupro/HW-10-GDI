using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW_10_GDI
{
    public partial class Task1 : Form
    {
        private const int Padding = 40;
        private const int StepSize = 50;
        private readonly Pen _axisPen = new Pen(Color.Black, 2f);
        private readonly Pen _linePen = new Pen(Color.Red, 2f);

        private readonly decimal[] _currencyData = { 1.23m, 2.34m, 3.42m, 1.38m, 4.35m, 5.31m, 1.28m, 2.23m, 4.21m, 5.18m, 7.16m, 100.21m };
        private readonly string[] _months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
        public Task1()
        {
            InitializeComponent();
        }

        private void Task1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.White);

            var x0 = Padding;
            var y0 = this.Height - Padding;
            var width = this.Width - Padding * 2;
            var height = this.Height - Padding * 2;

            g.DrawLine(_axisPen, x0, y0, x0 + width, y0);

            g.DrawLine(_axisPen, x0, y0, x0, y0 - height);

            var xLabelY = y0 + Padding / 2;
            for (var i = 0; i < _months.Length; i++)
            {
                var x = x0 + i * StepSize;
                g.DrawLine(_axisPen, x, y0 - 5, x, y0 + 5);
                g.DrawString(_months[i], Font, Brushes.Black, x, xLabelY);
            }

            var yLabelX = x0 - Padding / 2;
            for (var i = 0; i <= 10; i++)
            {
                var y = y0 - i * StepSize;
                g.DrawLine(_axisPen, x0 - 5, y, x0 + 5, y);
                g.DrawString(i.ToString(), Font, Brushes.Black, yLabelX, y - 10);
            }

            for (var i = 0; i < _currencyData.Length - 1; i++)
            {
                var x1 = x0 + i * StepSize;
                var y1 = y0 - (int)(_currencyData[i] * StepSize);
                var x2 = x0 + (i + 1) * StepSize;
                var y2 = y0 - (int)(_currencyData[i + 1] * StepSize);

                g.DrawLine(_linePen, x1, y1, x2, y2);
            }
        }
    }
}
