using System;
using System.Collections.Generic;

namespace AStar_KTQT2
{
    class AStarAlg
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

        public struct Cell
        {
            public int parent_i, parent_j;
            public double f, g, h;
        }

        public void AStar(DoThi dothi)
        {
            int ROW = dothi.rows;
            int COL = dothi.cols;
            int[,] grid = dothi.Matran;
            Pair src = new Pair(dothi.start.X, dothi.start.Y);
            Pair dest = new Pair(dothi.goal.X, dothi.goal.Y);

            if (!IsValid(src.first, src.second, ROW, COL) || !IsValid(dest.first, dest.second, ROW, COL))
            {
                Console.WriteLine("Start hoặc Goal không hợp lệ");
                return;
            }

            if (!IsUnBlocked(grid, src.first, src.second) || !IsUnBlocked(grid, dest.first, dest.second))
            {
                Console.WriteLine("Start hoặc Goal bị chặn");
                return;
            }

            if (src.first == dest.first && src.second == dest.second)
            {
                Console.WriteLine("Chúng ta đã đến đích rồi");
                return;
            }

            bool[,] closedList = new bool[ROW, COL];
            Cell[,] cellDetails = new Cell[ROW, COL];

            for (int i = 0; i < ROW; i++)
            {
                for (int j = 0; j < COL; j++)
                {
                    cellDetails[i, j].f = double.MaxValue;
                    cellDetails[i, j].g = double.MaxValue;
                    cellDetails[i, j].h = double.MaxValue;
                    cellDetails[i, j].parent_i = -1;
                    cellDetails[i, j].parent_j = -1;
                }
            }

            int x = src.first, y = src.second;
            cellDetails[x, y].f = 0.0;
            cellDetails[x, y].g = 0.0;
            cellDetails[x, y].h = 0.0;
            cellDetails[x, y].parent_i = x;
            cellDetails[x, y].parent_j = y;

            SortedSet<Tuple<double, Pair>> openList = new SortedSet<Tuple<double, Pair>>(
                Comparer<Tuple<double, Pair>>.Create((a, b) => a.Item1.CompareTo(b.Item1)));

            openList.Add(new Tuple<double, Pair>(0.0, new Pair(x, y)));
            bool foundDest = false;

            while (openList.Count > 0)
            {
                Tuple<double, Pair> p = openList.Min;
                openList.Remove(p);

                x = p.Item2.first;
                y = p.Item2.second;
                closedList[x, y] = true;

                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if (i == 0 && j == 0)
                            continue;

                        if ((i == -1 && j == -1) || (i == -1 && j == 1) || (i == 1 && j == -1) || (i == 1 && j == 1))
                            continue;

                        //if (i == -1 && j == 1)
                        //    continue;

                        //if (i == 1 && j == -1)
                        //    continue;

                        //if (i == 1 && j == 1)
                        //    continue;

                        int newX = x + i;
                        int newY = y + j;

                        if (IsValid(newX, newY, ROW, COL))
                        {
                            if (IsDestination(newX, newY, dest))
                            {
                                cellDetails[newX, newY].parent_i = x;
                                cellDetails[newX, newY].parent_j = y;
                                Console.WriteLine("Đường đi được tìm thấy:");
                                TracePath(cellDetails, dest);
                                foundDest = true;
                                return;
                            }

                            if (!closedList[newX, newY] && IsUnBlocked(grid, newX, newY))
                            {
                                double gNew = cellDetails[x, y].g + 1.0;
                                double hNew = CalculateHValue(newX, newY, dest);
                                double fNew = gNew + hNew;

                                if (cellDetails[newX, newY].f == double.MaxValue || cellDetails[newX, newY].f > fNew)
                                {
                                    openList.Add(new Tuple<double, Pair>(fNew, new Pair(newX, newY)));
                                    cellDetails[newX, newY].f = fNew;
                                    cellDetails[newX, newY].g = gNew;
                                    cellDetails[newX, newY].h = hNew;
                                    cellDetails[newX, newY].parent_i = x;
                                    cellDetails[newX, newY].parent_j = y;
                                }
                            }
                        }
                    }
                }
            }

            if (!foundDest)
                Console.WriteLine("Không tìm thấy đường đi");
        }

        public static bool IsValid(int row, int col, int ROW, int COL)
        {
            return (row >= 0) && (row < ROW) && (col >= 0) && (col < COL);
        }

        public static bool IsUnBlocked(int[,] grid, int row, int col)
        {
            return grid[row, col] == 1;
        }

        public static bool IsDestination(int row, int col, Pair dest)
        {
            return (row == dest.first && col == dest.second);
        }

        public static double CalculateHValue(int row, int col, Pair dest)
        {
            return Math.Sqrt(Math.Pow(row - dest.first, 2) + Math.Pow(col - dest.second, 2));
        }

        public static void TracePath(Cell[,] cellDetails, Pair dest)
        {
            Console.WriteLine("\nCon đường là ");
            int row = dest.first;
            int col = dest.second;
            Stack<Pair> Path = new Stack<Pair>();

            while (!(cellDetails[row, col].parent_i == row && cellDetails[row, col].parent_j == col))
            {
                Path.Push(new Pair(row, col));
                int temp_row = cellDetails[row, col].parent_i;
                int temp_col = cellDetails[row, col].parent_j;
                row = temp_row;
                col = temp_col;
            }

            Path.Push(new Pair(row, col));

            while (Path.Count > 0)
            {
                Pair p = Path.Peek();
                Path.Pop();
                Console.Write(" -> ({0},{1}) ", p.first, p.second);
            }
        }
    }
}
