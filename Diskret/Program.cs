using System;

namespace Diskret
{
    class Program
    {
        static void Main(string[] args)
        {
            int px = 9686;
            int py = 764;

            //Точка P
            Point P = new Point(px, py);

            //Вторая точка
            Point p2 = P;

            //Массив первых 10 точек
            Point[] Points = new Point[10];

            //Точка P
            Points[0] = P;

            //Вторая точка
            Points[1] = Points[0] + Points[0];

            //Остальные точки
            for(int i = 2; i <= 9; i++)
            {
                Points[i] = Points[i - 1] + Points[0];
            }

            Console.WriteLine("Первые десять точки, поражденные точкой P\n");

            //Вывод точек
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine(Points[i].x + "\t" + Points[i].y);
            }

            Console.WriteLine("\nПорядок точки P(" + px + "," + py + ") равен " + P.n());


            //а - произвольное число от 1 до порядка точки P
            int a = 35;

            //A - открытый ключ
            Point A = a * P;
            
            //Сообщение Боба
            Point M = Points[3] + Points[7];

            //k - число от 0 до порядка точки P, выбранный Бобом
            int k = 20;

            //Точки B1 и B2, вычисленные Бобом
            Point B1 = k * P;

            Point B2 =  M + k * A;

            //B2 - a * B1 = M + k * A - a * k * P = M + k * a * P - k * A * P = M

            Point help = (-a) * B1 + k * A;

            Point ans = help == new Point(-1, 0) ? M : null;
       
            Console.WriteLine("A\n" + A.x + " " + A.y + "\n");
            Console.WriteLine("M\n" + M.x + " " + M.y + "\n");
            Console.WriteLine("B1\n" + B1.x + " " + B1.y + "\n");
            Console.WriteLine("B2\n" + B2.x + " " + B2.y + "\n");
            Console.WriteLine("Ans\n" + ans.x + " " + ans.y + "\n");

            Console.WriteLine("Нажмите на Enter для решения задачи волка и Бармалея или Esc для выхода");

            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.Escape)
            {
                return;
            }
            else if(key == ConsoleKey.Enter)
            {
                Console.Clear();
            }

            //----------------------Решение дополнительной задачи---------------------------------

            //Секретный ключ волка
            int va = 47;

            //Открытый ключ
            Point vA = va * P;

            //Сообщение Бармалея
            Point vM = Points[2] + Points[6];

            //Случайное число, выбранное Бармалейем
            int vk = 17;
            
            //В1 и В2, рассчитанные Бармалейем
            Point vB1 = vk * P;
            Point vB2 = vk * vA;

            //Бармалей представляет сообщение в виде c1, c2, B1
            int c1 = Point.mod(vB2.x * vM.x);
            int c2 = Point.mod(vB2.y * vM.y);

            //Чтобы расшивровать сообщение нужно с1 / ((a * vB1).x) и с2 / ((a * vB1).y)

            Point vhelp = va * vB1;

            //Расшифрованное сообщение 
            Point vAns = new Point(0, 0);

            //Решение уравнении a*B2.x*Ans.x = c1 mod 12721
            while (true)
            {
                if (Point.mod(vhelp.x * (vAns.x++)) == c1)
                {
                    vAns.x--;
                    break;
                }
            }

            //Решение уравнении a*B2.y*Ans.y = c2 mod 12721
            while (true)
            {
                if (Point.mod(vhelp.y * (vAns.y++)) == c2)
                {
                    vAns.y--;
                    break;
                }
            }

            Console.WriteLine("A\n" + vA.x + " " + vA.y + "\n");
            Console.WriteLine("M\n" + vM.x + " " + vM.y + "\n");
            Console.WriteLine("B1\n" + vB1.x + " " + vB1.y + "\n");
            Console.WriteLine("B2\n" + vB2.x + " " + vB2.y + "\n");
            Console.WriteLine("a * B1\n" + vhelp.x + " " + vhelp.y + "\n");
            Console.WriteLine("c1\n" + c1 + "\n");
            Console.WriteLine("c2\n" + c2 + "\n");
            Console.WriteLine("Ans\n" + vAns.x + " " + vAns.y + "\n");


        }
    }
}
