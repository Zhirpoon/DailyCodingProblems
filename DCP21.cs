using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    #21
    Given an array of time intervals (start, end) for classroom lectures (possibly overlapping), find the minimum number of rooms required.

    For example, given [(30, 75), (0, 50), (60, 150)], you should return 2.
*/
namespace DCP21
{
    public class DCP21
    {
        public class TimeInterval
        {
            public TimeInterval(int start, int end)
            {
                Start = start;
                End = end;
            }

            public int Start;
            public int End;
        }

        public static void Main(string[] args)
        {
            var times = new TimeInterval[] { new TimeInterval(30,75), new TimeInterval(0, 50), new TimeInterval(60, 150)};

            Console.WriteLine(GetRequiredRoomAmount(times));
        }

        public static int GetRequiredRoomAmount(TimeInterval[] times)
        {
            var rooms = new List<List<TimeInterval>>();

            if(times.Length == 0)
            {
                return 0;
            }
            else
            {
                rooms.Add(new List<TimeInterval>());
            }

            foreach(var ti in times)
            {
                var newRoomRequired = true;

                foreach (var room in rooms)
                {
                    if(room.Any(l => ti.End < l.Start || ti.Start > l.End) || room.Count == 0)
                    {
                        room.Add(ti);
                        newRoomRequired = false;
                        break;
                    }
                }

                if (newRoomRequired)
                {
                    var newRoom = new List<TimeInterval>();
                    newRoom.Add(ti);
                    rooms.Add(newRoom);
                }
            }

            return rooms.Count();
        }
    }
}
