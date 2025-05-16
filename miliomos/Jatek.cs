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

            Console.WriteLine("Üdv a Játékban!");
            Console.WriteLine("Kérem válaszoljon az alábbi kérdésre, hogy tovább jusson a következő játékba!");
            MasikKerdes jelenlegiMasikKerdes = masik[random.Next(masik.Count)];
            Console.WriteLine($"Katégória: {jelenlegiMasikKerdes.Kat}\n");
            Console.WriteLine(jelenlegiMasikKerdes.Kerdes);
            Console.WriteLine($"({jelenlegiMasikKerdes.Helyes})");
            Console.WriteLine($"\n A: {jelenlegiMasikKerdes.Valasz[0]}  B: {jelenlegiMasikKerdes.Valasz[1]} \n C: {jelenlegiMasikKerdes.Valasz[2]}  D: {jelenlegiMasikKerdes.Valasz[3]}");

            if (Console.ReadLine() == jelenlegiMasikKerdes.Helyes)
            {
                Console.WriteLine("Helyes válasz");
            }
            else
            {
                Console.WriteLine("Helytelen válasz");
            }

        }
    }
}
