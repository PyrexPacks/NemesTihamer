using System.Runtime.InteropServices;

namespace sportverseny
{
    internal class Program
    {
        static (long kovegso, long kevegso, long fovegso, long maradekvegso) bruteforce(long n) 
        {
            long ko = 0;
            long ke = 0;
            long fo = 0;
            long maradek = 0;
            
            long kovegso = 0;
            long kevegso = 0;
            long fovegso = 0;
            long maradekvegso = 999999999999999999;

            int alap = 3;
            int masodikalap = 3;
            int lépés = 3;
            
            int szamlalo=0;
            
            bool talalt = false;
            bool talaltalltime = false;

            const int ko_letszam = 5;
            const int ke_letszam = 7;
            const int fo_letszam = 11;
            for (int i = 0; i<=alap; i++) {
                ko = 0;
                for (; ko <= alap; ko++)
                {
                    ke = 0;
                    
                    for (; ke <= alap; ke++)
                    {
                        fo = 0;
                        for (; fo <= alap; fo++)
                        {
                            Console.WriteLine($"{ko} {ke} {fo} maradék: {Math.Abs(maradek = n-(ko*ko_letszam+ ke * ke_letszam+ fo * fo_letszam))}");
                            if (Math.Abs(maradek) < maradekvegso || (Math.Abs(maradek) == maradekvegso && ko + ke + fo < kovegso + kevegso + fovegso))
                            {
                                maradek = Math.Abs(n - (ko * ko_letszam + ke * ke_letszam + fo * fo_letszam));
                                kovegso = ko;
                                kevegso = ke;
                                fovegso = fo;
                                maradekvegso = maradek;
                                Console.WriteLine($"Uj legjobb ertek + {kovegso} + {kevegso} + {fovegso} + {maradekvegso}");
                                talalt = true;
                                talaltalltime = true;
                                szamlalo = i;
                            }
                            else
                            {
                                talalt = false;
                            }
                        }
                    }
                }
            }
            Thread.Sleep(1000);
            while (true)
            {
                if (szamlalo<=3)
                {
                    alap += lépés;
                    szamlalo+=lépés;
                }
                else
                {   
                    return (kovegso,kevegso,fovegso,maradekvegso);
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
