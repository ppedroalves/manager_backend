namespace Manager.Util
{
    public static class Roleta
    {
        private static Random rnd = new Random();

        public static T PickRandom<T>(this IList<T> lista)
        {
            int randIndex = rnd.Next(lista.Count);
            return lista[randIndex];
        }
    }
}
