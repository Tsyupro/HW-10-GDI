using System.Windows.Forms;
using System.Threading;

namespace HW_10_GDI
{
    public partial class Task3 : Form
    {
        private System.Windows.Forms.Timer timer;

        public Task3()
        {
            InitializeComponent();
            this.Text = "Clock";
            this.Width = 300;
            this.Height = 300;

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int width = this.ClientSize.Width;
            int height = this.ClientSize.Height;
            int centerX = width / 2;
            int centerY = height / 2;

            int seconds = DateTime.Now.Second;
            int minutes = DateTime.Now.Minute;
            int hours = DateTime.Now.Hour;

            e.Graphics.DrawEllipse(Pens.Black, 10, 10, width - 20, height - 20);
            for (int i = 0; i < 12; i++)
            {
                double angle = i * Math.PI / 6;
                int x1 = (int)(centerX + (width / 3.5) * Math.Sin(angle));
                int y1 = (int)(centerY - (height / 3.5) * Math.Cos(angle));
                int x2 = (int)(centerX + (width / 4.0) * Math.Sin(angle));
                int y2 = (int)(centerY - (height / 4.0) * Math.Cos(angle));
                e.Graphics.DrawLine(Pens.Black, x1, y1, x2, y2);
            }

            double hourAngle = (hours % 12 + minutes / 60.0) * Math.PI / 6;
            int hourHandLength = (int)(width / 4.0);
            int hourX = (int)(centerX + hourHandLength * Math.Sin(hourAngle));
            int hourY = (int)(centerY - hourHandLength * Math.Cos(hourAngle));
            e.Graphics.DrawLine(Pens.Black, centerX, centerY, hourX, hourY);

            double minuteAngle = minutes * Math.PI / 30;
            int minuteHandLength = (int)(width / 3.0);
            int minuteX = (int)(centerX + minuteHandLength * Math.Sin(minuteAngle));
            int minuteY = (int)(centerY - minuteHandLength * Math.Cos(minuteAngle));
            e.Graphics.DrawLine(Pens.Black, centerX, centerY, minuteX, minuteY);

            double secondAngle = seconds * Math.PI / 30;
            int secondHandLength = (int)(width / 2.5);
            int secondX = (int)(centerX + secondHandLength * Math.Sin(secondAngle));
            int secondY = (int)(centerY - secondHandLength * Math.Cos(secondAngle));
            e.Graphics.DrawLine(Pens.Red, centerX, centerY, secondX, secondY);
        }
    }
}
