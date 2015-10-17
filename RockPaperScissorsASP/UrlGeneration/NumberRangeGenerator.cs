using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RockPaperScissorsASP.UrlGeneration
{
    public class NumberRangeGenerator
    {
        public int[] GetArrayInts(int start, int end, int step = 1)
        {
            if (start == end)
            {
                return new int[0];
            }
            if (start > end || start < 0)
            {
                throw new InvalidOperationException("start is bigger than end.");
            }

            int length = ((end - start) / step) + step;

            var arr = new int[length];
            for (int i = 0; i < length; i++)
            {
                arr[i] = start;
                start += step;
            }

            return arr;
        }
    }
}