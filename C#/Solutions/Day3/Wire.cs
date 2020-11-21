using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day3
{
    public class Wire
    {
        private const char Right = 'R';
        private const char Left = 'L';
        private const char Up = 'U';
        private const char Down = 'D';

        private Point _currPos = new Point(0,0);
        private int _steps = 0;
        public HashSet<Tuple<Point,int>> Points { get; }
        public Wire(string[] directions)
        {
            Points = new HashSet<Tuple<Point,int>>(new PointDistanceComparer());
            addPoints(directions);
        }

        public int DistanceAt(Point point)
        {
            return Points.Single(t => t.Item1.X == point.X && t.Item1.Y == point.Y).Item2;
        }
        private void addPoints(string[] directions)
        {
            char dir;
            int length;
            Points.Add(new Tuple<Point,int>(_currPos, _steps));
            for (int i = 0; i < directions.Length; i++)
            {
                dir = directions[i].ElementAt(0);
                length = int.Parse(directions[i].Substring(1));

                addNextSegment(dir, length);
            }
        }


        private void addNextSegment(char dir, int length)
        {
            switch (dir)
            {
                case Up:
                    for (int i = 0; i < length; i++)
                    {
                        updateCurrPosAndSteps(0, 1);
                        Points.Add(new Tuple<Point,int>(_currPos,_steps));
                    }
                    break;
                case Down:
                    for (int i = 0; i < length; i++)
                    {
                        updateCurrPosAndSteps(0, -1);
                        Points.Add(new Tuple<Point, int>(_currPos, _steps));
                    }
                    break;
                case Left:
                    for (int i = 0; i < length; i++)
                    {
                        updateCurrPosAndSteps(-1,0);
                        Points.Add(new Tuple<Point, int>(_currPos, _steps));
                    }
                    break;
                case Right:
                    for (int i = 0; i < length; i++)
                    {
                        updateCurrPosAndSteps(1, 0);
                        Points.Add(new Tuple<Point, int>(_currPos, _steps));
                    }
                    break;
                default:
                    break;
            }
        }

        private void updateCurrPosAndSteps(int dx, int dy)
        {
            _currPos = new Point(_currPos.X + dx, _currPos.Y + dy);
            _steps++;
        }

    }
}
