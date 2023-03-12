using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW_10_GDI
{
    public partial class Task2 : Form
    {
        public Task2()
        {
            InitializeComponent();

            Bitmap logo = new Bitmap(200, 100);
            Graphics g = Graphics.FromImage(logo);

            g.Clear(Color.White);

            Pen outlinePen = new Pen(Color.Black, 3);
            g.DrawString("My Company", new Font("Arial", 20), Brushes.Red, 10, 10);
            g.DrawRectangle(outlinePen, 10, 10, 180, 80);

            logo.Save("logo.png", ImageFormat.Png);

            pictureBox1.Image = Image.FromFile("logo.png");
        }
    }
}
