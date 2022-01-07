using System;
using System.Collections.Generic;
using System.IO;

namespace OsztalyKassza
{
    class Program
    {
        static List<Diak> osztaly;
        static int osztalyPenz = 0;
        static void Main(string[] args)
        {
            osztaly = new List<Diak>();

            beolvasas();
            befizetesek(osztalyPenz);
            kirandulas(40000);
            tartozoDiakok();

            kiiras();
            Console.ReadKey();
        }

        static void beolvasas()
        {
            string fajl = @"C:\Users\Tanulo\source\repos\OsztalyKassza\OsztalyKassza\bin\Debug\netcoreapp3.1\nevsor.txt";

            try
            {
                using (StreamReader olvaso = new StreamReader(fajl))
                {
                    osztalyPenz = int.Parse(olvaso.ReadLine());
                    olvaso.ReadLine();
                    while (!olvaso.EndOfStream)
                    {
                        string[] t = olvaso.ReadLine().Split(';');
                        Diak obj = new Diak(t[0], t[1]);
                        osztaly.Add(obj);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"Hiba: {e}");
            }
            Console.WriteLine("A fájl beolvasva.");
            Console.WriteLine($"Osztálypénz: {osztalyPenz} Ft");
        }

        static void kiiras()
        {
            foreach (Diak d in osztaly)
            {
                Console.WriteLine($"{d.getNev()}\t{d.getBefOssz()}\t{d.getBefSzam()}\t{d.getEgyenleg()}\t");
            }
        }

        static void befizetesek(int op)
        {
            for (int i = 0; i < osztaly.Count; i++)
            {
                if ((i % 3) == 0)
                {
                    osztaly[i].osztalyPenzBefizetes(op);
                }
                else if ((i % 3) == 1)
                {
                    osztaly[i].osztalyPenzBefizetes(op*2);
                }
                else
                {
                    osztaly[i].osztalyPenzBefizetes(op*3);
                }
            }
        }

        static void kirandulas(int osszeg)
        {
            foreach(Diak d in osztaly)
            {
                d.kiadas((osszeg/osztaly.Count)+1);
            }
        }

        static void tartozoDiakok()
        {
            try
            {
                using(StreamWriter iro=new StreamWriter("tartozoDiakok.txt"))
                {
                    for (int i = 0; i < osztaly.Count; i++)
                    {
                        if (osztaly[i].getEgyenleg() < 0)
                        {
                            iro.WriteLine(osztaly[i].getNev());
                        }
                    }
                }
            }
            catch(IOException e)
            {
                Console.WriteLine($"Hiba: {e}");
            }
        }
    }
}
