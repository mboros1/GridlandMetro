using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using ExtensionMethods;

namespace ExtensionMethods
{
    public static class Methods
    {
        public static IEnumerable<int> AllIndexesOf(this string s, string value)
        {
            for (int i = 0; ; i++)
            {
                i = s.IndexOf(value, i);
                if (i == -1) break;
                yield return i;
            }
        }
        
    }

    public class Track
    {
        public int r { get; set; }
        public List<Interval> interval { get; set; }
    }

    public class Interval
    {
        public int c1 { get; set; }
        public int c2 { get; set; }
    }

    
}

class Solution
{
    static void Main(String[] args)
    {
        int[] temp = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        BigInteger n = temp[0];
        BigInteger m = temp[1];
        int k = temp[2];

        List<Track> tracks = new List<Track>();

        

        BigInteger answer = n*m;

        for (int i = 0; i < k; i++)
        {
            int[] track = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            int r = track[0];
            int c1 = track[1];
            int c2 = track[2];

            if (tracks.Find(x => x.r == r) == null)
            {
                Track y = new Track();
                y.r = r;
                Interval z = new Interval();
                z.c1 = c1;
                z.c2 = c2;
                List<Interval> templist = new List<Interval>();
                templist.Add(z);
                y.interval = templist;
                tracks.Add(y);
            }
            else
            {
                Track current = tracks.Find(x => x.r == r);
                Interval tempinterval = new Interval();
                tempinterval.c1 = c1;
                tempinterval.c2 = c2;
                for (int j = 0; j < current.interval.Count; j++)
                {
                    if (
                        (current.interval[j].c1 <= tempinterval.c1 && tempinterval.c1 <= current.interval[j].c2 && current.interval[j].c2 <= tempinterval.c2) ||
                        (tempinterval.c1 <= current.interval[j].c1 && current.interval[j].c1 <= tempinterval.c2 && tempinterval.c2 <= current.interval[j].c2 ) ||
                        (current.interval[j].c1 <= tempinterval.c1 && tempinterval.c2 <= current.interval[j].c2) ||
                        (tempinterval.c1 <= current.interval[j].c1 && current.interval[j].c2 <= tempinterval.c2)
                        )
                    {
                        tempinterval.c1 = Math.Min(current.interval[j].c1, tempinterval.c1);
                        tempinterval.c2 = Math.Max(current.interval[j].c2, tempinterval.c2);
                        current.interval.RemoveAt(j);
                        j = 0;
                    }
                    else
                    {

                    }
                }
                current.interval.Add(tempinterval);
            }
        }
        for (int i = 0; i < tracks.Count; i++)
        {
            for (int j = 0; j < tracks[i].interval.Count; j++)
            {
                answer -= tracks[i].interval[j].c2 - (tracks[i].interval[j].c1 - 1);
            }
        }
        Console.WriteLine(answer);

    }
}