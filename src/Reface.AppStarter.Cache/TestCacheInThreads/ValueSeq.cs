namespace TestCacheInThreads
{
    public static class ValueSeq
    {
        private static int value = 0;
        private static readonly object LOCKER = new object();

        public static int Next()
        {
            lock (LOCKER)
                return value++;
        }
    }
}
