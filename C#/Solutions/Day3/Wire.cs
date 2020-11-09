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

        public Wire(string[] directions)
        {
            Segments = new HashSet<Segment>();
            addSegments(directions);
        }

        private void addSegments(string[] directions)
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

        public HashSet<Segment> Segments { get; }

        private void addNextSegment(char dir, int length)
        {
            switch (dir)
            {
                case Up:
                    Segments.Add(new Segment(_currPos, new Point(_currPos.X, _currPos.Y+length)));
                    updateCurrPos(0,length);
                    break;
                case Down:
                    Segments.Add(new Segment(_currPos, new Point(_currPos.X, _currPos.Y - length)));
                    updateCurrPos(0, -length);
                    break;
                case Left:
                    Segments.Add(new Segment(_currPos, new Point(_currPos.X - length, _currPos.Y)));
                    updateCurrPos(-length,0);
                    break;
                case Right:
                    Segments.Add(new Segment(_currPos, new Point(_currPos.X + length, _currPos.Y)));
                    updateCurrPos(length, 0);
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
