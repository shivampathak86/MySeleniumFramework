
using System.Diagnostics;

namespace Utilities
{
    public class TimeMeasurement
    {
        public static Stopwatch Stopwatch
        {
            get => _stopwatch ?? (_stopwatch = new Stopwatch());
            set => _stopwatch = value;
        }

        private static Stopwatch _stopwatch;
    }
}
