namespace CurrencyConverterExample
{
    public static class TupleListExtention
    {
        public static void Add <T1, T2, T3>(this IList<Tuple<T1, T2, T3>> list, T1 string1, T2 string2, T3 double1)
        {
            list.Add(Tuple.Create(string1, string2, double1));
        }
    }
}
