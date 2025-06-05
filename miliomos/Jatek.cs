using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace miliomos
{
	internal class Jatek
	{
		int szint;
		string[] lovek;

        public Jatek()
        {
            szint = 1;
            lovek = ["10.000 Ft", "20.000 Ft", "50.000 Ft", "100.000 Ft", "250.000 Ft", "500.000 Ft", "750.000 Ft", "1.000.000 Ft", "1.500.000 Ft", "2.000.000 Ft", "5.000.000 Ft",
            "10.000.000 Ft", "15.000.000 Ft", "25.000.000 Ft", "50.000.000 Ft"];
        }

        public int Szint { get => szint; set => szint = value; }
        public string[] Lovek { get => lovek;}

        Random random = new Random();

        public List<MasikKerdes> MasikBeolvasas()
        {
            List<MasikKerdes> masikkerdesek = new();
            StreamReader sr = new("sorkerdes.txt");
            while (!sr.EndOfStream)
            {
                string[] vonal = sr.ReadLine().Split(";");
                string[] valaszok = [vonal[1], vonal[2], vonal[3], vonal[4]];
                MasikKerdes kerdes = new(vonal[0], valaszok, vonal[5], vonal[6]);
                masikkerdesek.Add(kerdes);
            }
            return masikkerdesek;
        }

        public List<Kerdes> KerdesBeolvasas()
        {
            List<Kerdes> kerdesek = new();
            StreamReader sr = new("kerdes.txt");
            while (!sr.EndOfStream)
            {
                string[] vonal = sr.ReadLine().Split(";");
                string[] valaszok = [vonal[2], vonal[3], vonal[4], vonal[5]];
                Kerdes kerdes = new(vonal[1], valaszok, vonal[6], vonal[7], Convert.ToInt16(vonal[0]));
                kerdesek.Add(kerdes);
            }
            return kerdesek;

        }

        public void Start()
        {
            List<MasikKerdes> masik = MasikBeolvasas();
            List<Kerdes> kerdesek = KerdesBeolvasas();

            int peeez = 0;
            string fix = "0 Ft";
            bool call = true;
            bool fel = true;
            bool kozonseg = true;

            Console.WriteLine("Üdv a Játékban!\n");
            Console.WriteLine("Kérem válaszoljon az alábbi kérdésre, hogy tovább jusson a következő játékba!\n");
            MasikKerdes jelenlegiMasikKerdes = masik[random.Next(masik.Count)];
            Console.WriteLine($"Katégória: {jelenlegiMasikKerdes.Kat}\n");
            Console.WriteLine(jelenlegiMasikKerdes.Kerdes);
            Console.WriteLine($"({jelenlegiMasikKerdes.Helyes})");
            Console.WriteLine($"\n A: {jelenlegiMasikKerdes.Valasz[0]} \n B: {jelenlegiMasikKerdes.Valasz[1]} \n C: {jelenlegiMasikKerdes.Valasz[2]} \n D: {jelenlegiMasikKerdes.Valasz[3]}\n");

            if ( Console.ReadLine().ToUpper() == jelenlegiMasikKerdes.Helyes)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nHelyes válasz");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(1000);
                Console.Clear();
                bool game = true;
                do
                {
                    Kerdes ez = kerdesek[random.Next(kerdesek.Count)];
                    while (ez.Szint != Szint)
                    {
                        ez = kerdesek[random.Next(kerdesek.Count)];
                    }
                    Console.WriteLine($"{Szint}. forduló  Kategória: {ez.Kat}\n");
                    Console.WriteLine($"Aktuális nyeremény: {Lovek[peeez]}\nFix nyeremény: {fix}\n");
                    if (call)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Telefonos segítség (T)");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Telefonos segítség (T)");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" | ");

                    if (fel)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Felezés (F)");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Felezés (F)");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" | ");

                    if (kozonseg)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Közönség segítsége (K)");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Közönség segítsége (K)");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\n\n");

                    Console.WriteLine(ez.Talany);
                    Console.WriteLine();
                    Console.WriteLine($"({ez.Helyes})");
                    Console.WriteLine($"\n A: {ez.Valasz[0]} \n B: {ez.Valasz[1]} \n C: {ez.Valasz[2]} \n D: {ez.Valasz[3]}\n");

                    string bemenet = Console.ReadLine().ToUpper();

                    while (bemenet != "A" && bemenet != "B" && bemenet != "C" && bemenet != "D" && bemenet != "T" && bemenet != "K" && bemenet != "F")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Hibás bemenet");
                        Console.ForegroundColor = ConsoleColor.White;
                        bemenet = Console.ReadLine().ToUpper();
                    }

                    if (bemenet == ez.Helyes)
                    {
                        Szint++;
                        peeez++;
                        if (Lovek[peeez] == "100.000 Ft" || Lovek[peeez] == "1.000.000 Ft" || Lovek[peeez] == "10.000.000 Ft")
                        {
                            fix = Lovek[peeez];
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nHelyes válasz");
                        Console.ForegroundColor = ConsoleColor.White;
                        Thread.Sleep(1000);
                        Console.Clear();
                        if (Szint == 16)
                        {
                            Console.WriteLine($"Gratulálunk megnyerte az {Lovek[peeez]}-ot!");
                            game = false;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nHelytelen válasz");
                        Console.ForegroundColor = ConsoleColor.White;
                        Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine($"Az ön nyereménye: {fix}");
                        game = false;
                    }

                    


                } while (game == true);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nHelytelen válasz");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(1000);
				Console.Clear();
                Console.WriteLine("A játék ön számára véget ért.");
            }

        }
    }
}
