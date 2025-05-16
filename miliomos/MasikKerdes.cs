using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miliomos
{
	internal class MasikKerdes
	{
        string kerdes;
		string[] valasz;
		string helyes;
		string kat;

        public MasikKerdes(string kerdes, string[] valasz, string helyes, string kat)
        {
            this.kerdes = kerdes;
            this.valasz = valasz;
            this.helyes = helyes;
            this.kat = kat;
        }

        public string Kerdes { get => kerdes;}
        public string[] Valasz { get => valasz;}
        public string Helyes { get => helyes;}
        public string Kat { get => kat;}
    }
}
