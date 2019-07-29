namespace Sample.Struct.Summators
{
    public static class IntAdditive
    {
        public static Additive<int, IntSummator> AsAdditive(this int value) => Additive<int, IntSummator>.Wrap(value);
    }
}
