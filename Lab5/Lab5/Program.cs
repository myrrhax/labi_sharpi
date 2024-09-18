namespace Lab5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите X: ");
            int.TryParse(Console.ReadLine(), out int x);

            foreach (double res in Dop(x, 25))
            {
                Console.WriteLine(res);
            }

            Console.WriteLine("ENUMERATOR");
            IEnumerator<double> en = Dop2(x, 25);
            while (en.MoveNext())
            {
                Console.WriteLine(en.Current);
            }
        }

        static IEnumerable<double> Range(double y, double e) {
            if (y <= 1)
            {
                Console.WriteLine("y >= 1");
                yield break;
            };
            int n = 0;
            double x = 1 / Math.Pow(y, n);
            n++;
            while (x < e)
            {
                yield return x;
                x = 1 / Math.Pow(y, n);
                n++;
            }
        }

        static IEnumerable<double> Dop(double x, double e)
        {
            double n = 0;
            double y = Math.Pow(x, n / 4);
            while (y <= e)
            {
                yield return y;
                n++;
                y = Math.Pow(x, n / 4);
            }
        }

        static IEnumerator<double> Dop2(double x, double e)
        {
            double n = 0;
            double y = Math.Pow(x, n / 4);
            while (y <= e)
            {
                yield return y;
                n++;
                y = Math.Pow(x, n / 4);
            }
        }
    }
}
