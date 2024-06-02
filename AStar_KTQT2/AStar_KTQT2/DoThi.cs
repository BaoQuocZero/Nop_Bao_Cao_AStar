using System;
using System.IO;

namespace AStar_KTQT2
{
    class DoThi
    {
        public Point start;
        public Point goal;
        public int sodinh;
        public int rows;
        public int cols;
        private int[,] matran;
        public Point[] dsPoint;
        public int index;

        public DoThi()
        {
            start = new Point(-1, -1);
            goal = new Point(-1, -1);
            sodinh = 1;
            rows = 0;
            cols = 0;
            dsPoint = new Point[64];
            matran = new int[100, 100];
            readDothi();
        }

        public void readDothi()
        {
            string textFile = @"C:\Users\admiin\Desktop\Nop_Bao_Cao_AStar\AStar_KTQT2\inputS_G.txt";

            if (File.Exists(textFile))
            {
                string[] lines = File.ReadAllLines(textFile);
                string[] startCoords = lines[0].Split(' ');
                start = new Point(int.Parse(startCoords[0]), int.Parse(startCoords[1]));
                string[] goalCoords = lines[1].Split(' ');
                goal = new Point(int.Parse(goalCoords[0]), int.Parse(goalCoords[1]));
                string[] sodinhCoords = lines[2].Split(' ');
                rows = int.Parse(sodinhCoords[0]);
                cols = int.Parse(sodinhCoords[1]);
                sodinh = rows * cols;
                index = 0;

                for (int x = 0; x < rows; x++)
                {
                    for (int y = 0; y < cols; y++)
                    {
                        dsPoint[index] = new Point(x, y);
                        index++;
                    }
                }

                for (int i = 0; i < rows; i++)
                {
                    string linei = lines[i + 3].Trim();
                    string[] arr = linei.Split(' ');

                    for (int j = 0; j < cols; j++)
                    {
                        matran[i, j] = Convert.ToInt32(arr[j]);
                    }
                }

                //for (int i = 0; i < rows; i++)
                //{
                //    for (int j = 0; j < cols; j++)
                //    {
                //        matran[i, j] = matran[i, j] == 0 ? 1 : 0;
                //    }
                //}
            }
        }

        public void printDothi()
        {
            Console.WriteLine("Số đỉnh: " + sodinh);
            Console.WriteLine("Start: ");
            if (Start != null)
            {
                Start.printPoint(); Console.WriteLine();
            }
            Console.WriteLine("Goal: ");
            if (Goal != null)
            {
                goal.printPoint(); Console.WriteLine();
            }
            Console.WriteLine("Kích thước đồ thị: ({0}, {1})", rows, cols);
            Console.WriteLine("Bắt đầu duyệt đỉnh: ");
            for (int i = 0; i < sodinh; i++)
            {
                dsPoint[i].printPoint(); Console.WriteLine();
            }
            Console.WriteLine("Duyệt xong {0} đỉnh", index);

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matran[i, j] + " ");
                }
            }
            Console.WriteLine();

            // Đổi giá trị trong ma trận sau khi đọc xong 0 thành 1 và 1 thành 0
            // Do AStar chỉ nhận
            // 0 là tường
            // 1 là lối đi
            // như vậy hợp lý hơn
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    this.matran[i, j] = this.matran[i, j] == 0 ? 1 : 0;
                }
            }
        }

        public Point Start
        {
            get { return start; }
            set { start = value; }
        }

        public Point Goal
        {
            get { return goal; }
            set { goal = value; }
        }

        public int Sodinh
        {
            get { return sodinh; }
            set { sodinh = value; }
        }

        public int[,] Matran
        {
            get { return matran; }
            set { matran = value; }
        }

        internal Point[] DsPoint
        {
            get { return dsPoint; }
            set { dsPoint = value; }
        }
    }
}
