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
    }
}
