namespace Syntax.Practice.OOP.Inheritance
{
    public static class Product
    {
        public static int lonelyinteger(List<int> a)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int res = -1;
            foreach (var item in a)
            {
                if (!dict.ContainsKey(item))
                {
                    dict.Add(item, 1);
                }
                else
                {
                    dict[item]++;
                }
            }

            return dict.Where(x => x.Value == 1).Select(x => x.Key).FirstOrDefault();
        }
    }
}
