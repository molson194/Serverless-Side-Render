namespace serverSide
{
    public static class Data
    {
        private static IList<string> RawData = new List<string>
        {
            "a",
            "b",
        };

        public static IList<string> GetData()
        {
            return RawData;
        }

        public static void AppendData(string data)
        {
            RawData.Add(data);
        }
    }
}
