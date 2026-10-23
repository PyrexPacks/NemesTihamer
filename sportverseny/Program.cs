using System.Runtime.InteropServices;

namespace sportverseny
{
    internal class Program
    {
        static (long kovegso, long kevegso, long fovegso, long maradekvegso) bruteforce(long n)
        {
            long kovegso = 0;
            long kevegso = 0;
            long fovegso = 0;
            long maradekvegso = n;

            for (long ko = 0; ko <= n / 5; ko++)
            {
                for (long ke = 0; ke <= (n - ko * 5) / 7; ke++)
                {
                        long fo = (n - ko * 5 - ke * 7) / 11;
                        long maradek = n - (ko * 5 + ke * 7 + fo * 11);
                        //Console.WriteLine($"{ko} {ke} {fo} {maradek}");

                        if (maradek < maradekvegso || (ko + ke + fo > kovegso + kevegso + fovegso && maradek == maradekvegso))
                        {
                            kovegso = ko;
                            kevegso = ke;
                            fovegso = fo;
                            maradekvegso = maradek;
                        
                    }
                }
            }
            return (kovegso, kevegso, fovegso, maradekvegso);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Mi legyen az N szám?");
            long n = Convert.ToInt64(Console.ReadLine());

            var (ko, ke, fo, maradek) = bruteforce(n);

            Console.WriteLine($"{ko} {ke} {fo} {maradek}");
        }
    }
}
