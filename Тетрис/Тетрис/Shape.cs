using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//создание фигур
namespace Тетрис
{
    internal class Shape
    {
        public int x;
        public int y;
        public int[,] matrix;

        public Shape(int _x, int _y) //создание фигуры
        {
            x = _x;
            y = _y;
            matrix = new int[3, 3]
            {
                {0,1,0 },
                {0,1,1 },
                {0,0,1 },
            };
        }

    public void MoveDown() //передвижение фигуры вниз
    {
        y++;
    }
    public void MoveRight() //передвижение фигуры вправо
    {
        x++;
    }
    public void MoveLeft() //передвижение фигуры влево
    {
        x++;
    }
    }
}
