using System.Collections.Generic;

namespace Scripts
{
    public static class Extensions
    {
        public static void Reset(this IEnumerable<Line> lines)
        {
            foreach (var line in lines)
            {
                line.Reset();
            }
        }
    }
}