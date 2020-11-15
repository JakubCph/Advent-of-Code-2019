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
        public HashSet<Point> Points { get; }

        public Wire(string[] directions)
        {
            Points = new HashSet<Point>();
            addPoints(directions);
        }

        private void addPoints(string[] directions)
        {
            char dir;
            int length;
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
                        updateCurrPos(0, 1);
                        Points.Add(_currPos);
                    }
                    break;
                case Down:
                    for (int i = 0; i < length; i++)
                    {
                        updateCurrPos(0, -1);
                        Points.Add(_currPos);
                    }
                    break;
                case Left:
                    for (int i = 0; i < length; i++)
                    {
                        updateCurrPos(-1,0);
                        Points.Add(_currPos);
                    }
                    break;
                case Right:
                    for (int i = 0; i < length; i++)
                    {
                        updateCurrPos(1, 0);
                        Points.Add(_currPos);
                    }
                    break;
                default:
                    break;
            }
        }

        private void updateCurrPos(int dx, int dy)
        {
            _currPos = new Point(_currPos.X + dx, _currPos.Y + dy);
        }

    }
}
