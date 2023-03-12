namespace HW_10_GDI
{
    public partial class Task4 : Form
    {
        private const int MAZE_SIZE = 15;
        private const int CELL_SIZE = 20;
        private const int WALL_SIZE = 3;

        private Point playerPosition = new Point(0, 0);

        private int[,] maze = new int[MAZE_SIZE, MAZE_SIZE] {
        {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        {0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1},
        {1, 1, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 0, 1},
        {1, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 1},
        {1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 1},
        {1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1},
        {1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1},
        {1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1},
        {1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 0, 1},
        {1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1},
        {1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1},
        {1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1},
        {1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1},
        {1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1},
        {1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1}
        };

        public Task4()
        {
            InitializeComponent();
        }
        private void DrawMaze(Graphics g)
        {
            for (int i = 0; i < MAZE_SIZE; i++)
            {
                for (int j = 0; j < MAZE_SIZE; j++)
                {
                    int x = j * CELL_SIZE;
                    int y = i * CELL_SIZE;

                    if (maze[i, j] == 1)
                    {
                        g.FillRectangle(Brushes.Black, x, y, CELL_SIZE, CELL_SIZE);
                    }
                    else
                    {
                        g.FillRectangle(Brushes.White, x, y, CELL_SIZE, CELL_SIZE);
                    }
                }
            }
            int playerX = playerPosition.X * CELL_SIZE + CELL_SIZE / 2;
            int playerY = playerPosition.Y * CELL_SIZE + CELL_SIZE / 2;
            g.FillEllipse(Brushes.Red, playerX - CELL_SIZE / 4, playerY - CELL_SIZE / 4, CELL_SIZE / 2, CELL_SIZE / 2);
        }

        private void Task4_Paint(object sender, PaintEventArgs e)
        {
            DrawMaze(e.Graphics);
        }

        private void Task4_KeyDown(object sender, KeyEventArgs e)
        {
            int newX = playerPosition.X;
            int newY = playerPosition.Y;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    newY--;
                    break;
                case Keys.Down:
                    newY++;
                    break;
                case Keys.Left:
                    newX--;
                    break;
                case Keys.Right:
                    newX++;
                    break;
            }

            if (newX >= 0 && newX < MAZE_SIZE && newY >= 0 && newY < MAZE_SIZE && maze[newY, newX] == 0)
            {
                playerPosition.X = newX;
                playerPosition.Y = newY;
                Refresh();
            }

            if (playerPosition.X == 8 && playerPosition.Y == 14 || playerPosition.X == 10 && playerPosition.Y == 14)
            {
                MessageBox.Show("You won!");
                this.Close();
            }
        }
    }
}
