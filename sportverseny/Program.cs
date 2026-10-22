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

            const int ko_letszam = 5;
            const int ke_letszam = 7;
            const int fo_letszam = 11;
            bool boolread = false;

            if (n < 25)
            {
                cache(n);
                return 
                    // ez itt nem lesz jo, mainben kell ifelni csak mar nincs idom ezt megcsinalni, lenyeg az hogy mainben if 25 ha nem akkor bruteforce ha igen akkor cache, otthon felepitem a cachet, most meg commit es push
            }

            for (long ko = 0; ko <= n / ko_letszam; ko++)
            {
                for (long ke = 0; ke <= (n - ko * ko_letszam) / ke_letszam; ke++)
                {
                    for (long fo = 0; fo <= (n - ko * ko_letszam - ke * ke_letszam) / fo_letszam; fo++)
                    {
                        
                        long maradek = n - (ko * ko_letszam + ke * ke_letszam + fo * fo_letszam);
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
            }
            return (kovegso, kevegso, fovegso, maradekvegso);
        }

        static (long kovegso, long kevegso, long fovegso, long maradekvegso) cache(long n)
        {
            var dictionary = new Dictionary<long, long>();
            using (var read = File.ReadLinesAsync("dictionary.txt").GetAsyncEnumerator(){
                boolread = true;
                for (int i = 0; boolread; i++)
                {
                    if (!read.MoveNextAsync)
                    {
                        continue;
                    }
                    string[] kv = read.Current.Split(":");
                    if (kv.Length == 2)
                    {
                        dictionary.Add(kv[0], kv[1]);
                    }
                }
            }
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
