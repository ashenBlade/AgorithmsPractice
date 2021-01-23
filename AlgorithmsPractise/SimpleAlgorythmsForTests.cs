using System.IO;

namespace AlgorithmsPractise
{
    public class SimpleAlgorythmsForTests
    {
        public static void KolatecAlgorithm(TextWriter writer, int n)
        {
            while (n != 1)
            {
                writer.Write(n);
                writer.Write(" ");
                n = n % 2 == 0
                        ? n / 2
                        : n * 3 + 1;
            }
            writer.Write(n);
        }
    }
}