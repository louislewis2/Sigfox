namespace System
{
    using System.Linq;

    public static class RandomExtensions
    {
        /// <summary>
        /// Generates Alpha Numeric Characters
        /// </summary>
        public static string Generate(this Random random, int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var result = new string(
                Enumerable.Repeat(element: chars, count: length)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());

            return result;
        }
    }
}
