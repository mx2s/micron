using System;

namespace Core.DL.Misc {
    public static class Randomizer {
        public static int SmallInt() => new Random().Next(UInt16.MaxValue);
        public static int Int() => new Random().Next();
        public static int IntRange(int min, int max) => new Random().Next(min, max);
    }
}