namespace Sample.Struct.Summators
{
    public static class IntAdditive
    {
        public static Additive<int, IntSummator> AsAdditive(this int value) => value;
        public static Additive<int, IntCheckedSummator> AsCheckedAdditive(this int value) => value;
        public static Additive<long, int, IntIncrementalSummator> AsAccumulator(this int value) => value;
    }
}
