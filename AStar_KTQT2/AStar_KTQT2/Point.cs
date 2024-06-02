using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar_KTQT2
{
    class Point
    {
        private int x;
        private int y;

        public Point()
        {
            x = 0;
            y = 0;
        }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public double h(Point d)
        {
            double kq;
            double kq1 = Math.Pow(this.x - d.x, 2);
            double kq2 = Math.Pow(this.y - d.y, 2);
            kq = Math.Sqrt(kq1 + kq2);
            return kq;
        }

        public void printPoint()
        {
            Console.Write("({0}, {1})", x, y);
        }

        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }
    }
}
