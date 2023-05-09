using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//отрисовка карты
namespace Тетрис
{
    public partial class Form1 : Form
    {
        Shape currenShape;
        int size;
        int[,] map = new int[16, 8]; //карта для взаимодейсвтия с фигурами и отрисовкой

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        public void Init() //иниициализация переменных
        {
            size = 25;

            currenShape = new Shape(3, 0);

            timer1.Interval = 100;
            timer1.Tick += new EventHandler(update);

            Invalidate();//каждый катэр отрисовывался на холст
        }

        private void update(object sender, EventArgs e) //здесь двигаем фигуру вниз
        {
            currenShape.MoveDown();
            Merge();
            Invalidate();
        }

        public void Merge() //синхранизация матрицы в классе Shape с основной картой
        {
            for (int i = currenShape.y; i < currenShape.y + 3; i++)
            {
                for (int j = currenShape.x; j < currenShape.x + 3; j++)
                {
                    map[i, j] = currenShape.matrix[i - currenShape.y, j - currenShape.x];
                }
            }
        }

        public void DrawMap(Graphics e) //отрисовка фигур на карте в зависимости от переменной
        {
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (map[i,j] == 1)
                    {
                        e.FillRectangle(Brushes.Red, new Rectangle(50 + j * size + 1, 50 + i * size + 1, size - 1, size - 1));
                    }
                }
            }
        }

        public void DrawGrid(Graphics g) 
        {
            for (int i = 0; i <= 16; i++) //функиця для отрисовки линий горизонтальных
            {
                g.DrawLine(Pens.Black, new Point(50, 50 + i * size), new Point(50 + 8 * size, 50 + i * size));
            }
            for (int i = 0; i <= 8; i++) //функиця для отрисовки линий вертикальных
            {
                g.DrawLine(Pens.Black, new Point(50 + i * size, 50), new Point(50 + i * size, 50 + 16 * size));
            }
        }

        private void OnPaint(object sender, PaintEventArgs e) //перересовка холста
        {
            DrawGrid(e.Graphics);
            currenShape.MoveDown();
            Merge();
            DrawMap(e.Graphics);

        }
    }
}
