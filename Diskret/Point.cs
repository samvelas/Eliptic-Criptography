using System;

namespace Diskret
{
    public class Point
    {
        public int x, y;
        static int q = 12721, a = -5;
        static int px = 9686;
        static int py = 764;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        // a mod 12721
        public static int mod(int a)
        {
            return a % q < 0 ? a % q + q : a % q;
        }

        public static bool operator ==(Point p1, Point p2)
        {
            return (p1.x == p2.x && p1.y == p2.y) ? true : false;
        }

        public static bool operator !=(Point p1, Point p2)
        {
            return (p1.x == p2.x && p1.y == p2.y) ? false : true;
        }

        /// <summary>
        /// Порядок точки
        /// </summary>
        /// <returns></returns>
        public int n()
        {
            Point p2 = this;
            //Нахождение порядка первой точки
            for (int i = 2; ; i++)
            {
                Point p3 = p2 + this;

                if (p3 == this)
                {
                    return i;
                }

                p2 = p3;
            }
        }

        //Сложение точек
        public static Point operator +(Point p1, Point p2)
        {
            if (p2 == new Point(-1, -1))
            {
                return p1;
            }

            if (p1 == -1 * p2)
            {
                return new Point(-1, 0);
            }

            int x, y, lambda = 0;

            //Если равны, то lambda = (3 * (x1)^2 + a) / (2 * y1)
            if (p1 == p2)
            {
                int up = mod(mod(p1.x * p1.x * 3) + a);
                int down = mod(2 * p1.y);


                while (true)
                {
                    if (mod(down * (lambda++)) == up)
                    {
                        lambda--;
                        break;
                    }

                    if (lambda - 1 > q)
                    {
                        return p2;
                    }
                }

            }

            //Если точки разные, то lambda = (y2 - y1)/(x2 - x1)
            else
            {
                int up = mod(p2.y - p1.y);
                int down = mod(p2.x - p1.x);

                while (true)
                {
                    if (mod(down * (lambda++)) == up)
                    {
                        lambda--;
                        break;
                    }

                    if (lambda - 1 > q)
                    {
                        return new Point(px, py);
                    }
                }
            }

            // x = lambda ^ 2 - x1 - x2
            x = mod(mod(lambda * lambda) - p1.x - p2.x);

            // y = lambda * (x1 - x) - y1
            y = mod(mod(lambda * mod(p1.x - x)) - p1.y);

            return new Point(x, y);
        }

        /// <summary>
        /// Умножение число на точку
        /// </summary>
        /// <param name="a">Число</param>
        /// <param name="P">Точка</param>
        /// <returns>а*Р</returns>
        public static Point operator *(int a, Point P)
        {

            Point p1 = P;

            //Для умножения числа а на точку Р нужно сложить точку Р с собой а раз 
            for (int i = 0; i < Math.Abs(a) - 1; i++)
            {
                p1 = p1 + P;
                

                if (p1 == P)
                {
                    return new Point(-1, -1);
                }
            }

            //Если а отрицательное число возвращает -р1
            if (a < 0)
            {
                return new Point(-p1.x, - p1.y);
            }

            return p1;
        }



    }
}
