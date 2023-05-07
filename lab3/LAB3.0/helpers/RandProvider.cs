namespace LAB3._0.helpers
{
    public static class RandProvider
    {
        public static Random Random { get; }
        static RandProvider()
        {
            Random = new Random();
        }
    }
}
