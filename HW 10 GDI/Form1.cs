namespace HW_10_GDI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task1 task1 = new Task1();
            task1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Task2 task2 = new Task2();
            task2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Task3 task3 = new Task3();
            task3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Task4 task = new Task4();
            task.ShowDialog();
        }
    }
}