using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miliomos
{
	internal class Kerdes
	{
		string talany;
		string[] valasz;
		string helyes;
		string kat;
		int szint;

        public Kerdes(string talany, string[] valasz, string helyes, string kat, int szint)
        {
            this.talany = talany;
            this.valasz = valasz;
            this.helyes = helyes;
            this.kat = kat;
            this.szint = szint;
        }

        public string Talany { get => talany; set => talany = value; }
        public string[] Valasz { get => valasz; set => valasz = value; }
        public string Helyes { get => helyes; set => helyes = value; }
        public string Kat { get => kat; set => kat = value; }
        public int Szint { get => szint; set => szint = value; }
    }
}
