using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    #23
    You are given an M by N matrix consisting of booleans that represents a board. Each True boolean represents a wall. Each False boolean represents a tile you can walk on.

    Given this matrix, a start coordinate, and an end coordinate, return the minimum number of steps required to reach the end coordinate from the start. 
    If there is no possible path, then return null. You can move up, left, down, and right. You cannot move through walls. You cannot wrap around the edges of the board.

    For example, given the following board:

    [[f, f, f, f],
    [t, t, f, t],
    [f, f, f, f],
    [f, f, f, f]]

    and start = (3, 0) (bottom left) and end = (0, 0) (top left), the minimum number of steps required to reach the end is 7, 
    since we would need to go through (1, 2) because there is a wall everywhere else on the second row.
*/
namespace DCP23
{
    public class DCP23
    {
        public class Point
        {
            public Tuple<int, int> Position;
            public Point Parent;

            public Point(Tuple<int, int> pos, Point parent)
            {
                Position = pos;
                Parent = parent;
            }
        }

        public static Queue<Point> queue = new Queue<Point>();

        public static bool IsValid(bool[,] matrix, Tuple<int, int> pos)
        {
            return !(pos.Item1 < 0 
                || pos.Item2 < 0 
                || pos.Item1 > matrix.GetLength(0) - 1
                || pos.Item2 > matrix.GetLength(1) - 1
                || matrix[pos.Item1, pos.Item2]
            );
        }

        public static Point GetBFSPath(bool[,] matrix, Tuple<int, int> start, Tuple<int, int> end)
        {
            queue.Enqueue(new Point(start, null));

            while(queue.Count != 0 && queue.Peek() != null)
            {
                Point p = queue.Dequeue();

                if(p.Position.Item1 == end.Item1 && p.Position.Item2 == end.Item2)
                {
                    return p;
                }

                if(IsValid(matrix, new Tuple<int, int>(p.Position.Item1+1, p.Position.Item2)))
                {
                    matrix[p.Position.Item1, p.Position.Item2] = true;
                    queue.Enqueue(new Point(new Tuple<int, int>(p.Position.Item1 + 1, p.Position.Item2), p));
                }

                if (IsValid(matrix, new Tuple<int, int>(p.Position.Item1 - 1, p.Position.Item2)))
                {
                    matrix[p.Position.Item1, p.Position.Item2] = true;
                    queue.Enqueue(new Point(new Tuple<int, int>(p.Position.Item1 - 1, p.Position.Item2), p));
                }

                if (IsValid(matrix, new Tuple<int, int>(p.Position.Item1, p.Position.Item2 + 1)))
                {
                    matrix[p.Position.Item1, p.Position.Item2] = true;
                    queue.Enqueue(new Point(new Tuple<int, int>(p.Position.Item1, p.Position.Item2 + 1), p));
                }

                if (IsValid(matrix, new Tuple<int, int>(p.Position.Item1, p.Position.Item2 - 1)))
                {
                    matrix[p.Position.Item1, p.Position.Item2] = true;
                    queue.Enqueue(new Point(new Tuple<int, int>(p.Position.Item1, p.Position.Item2 - 1), p));
                }
            }
            return null;
        }

        public static void Main(string[] args)
        {
            var matrix = new bool[,] {
                { false, false, false, false },
                { true, true, false, true },
                { false, false, false, false },
                { false, false, false, false }
            };

            var start = new Tuple<int, int>(3, 0);
            var end = new Tuple<int, int>(0,0);

            var point = GetBFSPath(matrix, start, end);

            var count = 0;

            if(point == null)
            {
                Console.WriteLine("No available path");
            }
            else
            {
                while (point.Parent != null)
                {
                    count++;
                    point = point.Parent;
                }

                Console.WriteLine($"The shortest path has {count} step(s)");
            }
        }
    }
}
