using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miliomos
{
	internal class Jatek
	{
		int szint;
		string[] lovek;

        public Jatek(int szint, string[] lovek)
        {
            this.szint = 1;
            this.lovek = ["10.000 Ft", "20.000 Ft", "50.000 Ft", "100.000 Ft", "250.000 Ft", "500.000 Ft", "750.000 Ft", "1.000.000 Ft", "1.500.000 Ft", "2.000.000 Ft", "5.000.000 Ft",
            "10.000.000 Ft", "15.000.000 Ft", "25.000.000 Ft", "50.000.000 Ft"];
        }

        public int Szint { get => szint; set => szint = value; }
        public string[] Lovek { get => lovek;}

        public List<MasikKerdes> MasikBeolvasas()
        {
            List<MasikKerdes> sorkerdesek = new();
            StreamReader sr = new("sorkerdes.txt");
            while (!sr.EndOfStream)
            {
                string[] vonal = sr.ReadLine().Split(";");
                string[] valaszok = [vonal[1], vonal[2], vonal[3], vonal[4]];
                MasikKerdes kerdes = new(vonal[0], valaszok, vonal[5], vonal[6]);
                sorkerdesek.Add(kerdes);
            }
            return sorkerdesek;
        }

        public List<Kerdes> KerdesBeolvasas(string fileName)
        {
            List<Kerdes> kerdesek = new();
            StreamReader sr = new(fileName);
            while (!sr.EndOfStream)
            {
                string[] vonal = sr.ReadLine().Split(";");
                string[] valaszok = [vonal[2], vonal[3], vonal[4], vonal[5]];
                Kerdes kerdes = new(vonal[1], valaszok, vonal[6], vonal[7], Convert.ToInt16(vonal[0]));
                kerdesek.Add(kerdes);
            }
            return kerdesek;
        }
    }
}
