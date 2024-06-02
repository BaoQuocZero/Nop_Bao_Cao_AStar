using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar_KTQT2
{
    class Program
    {
        public struct Pair
        {
            public int first, second;

            public Pair(int x, int y)
            {
                first = x;
                second = y;
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            DoThi dt = new DoThi();
            dt.readDothi();
            dt.printDothi();

            int[,] grid = dt.Matran;

            // Điểm bắt đầu
            AStarAlg aStar = new AStarAlg();
            aStar.AStar(dt);



















            //Kiểm tra hàng đợi
            //Element el1 = new Element(4, 9, 18, 0);
            //Element el2 = new Element(5, 1, 12, 0);

            //HDUT q = new HDUT();
            //q.enQueue(el1);
            //q.enQueue(el2);
            //Element X = q.deQueue(); //Kết quả phải là (5, 1, 12, 0);
            //X.printElmt();

            Console.ReadKey();
        }
    }
}
