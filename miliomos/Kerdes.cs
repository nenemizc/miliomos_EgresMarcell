using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miliomos
{
	internal class Kerdes
	{
		string kerdes;
		string[] valasz;
		string helyes;
		string kat;
		int szint;

		public Kerdes(string kerdes, string[] valasz, string helyes, string kat, int szint)
		{
			this.kerdes = kerdes;
			this.valasz = valasz;
			this.helyes = helyes;
			this.kat = kat;
			this.szint = szint;
		}
	}
}
