using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Gyakorlas_Dolgozatra
{
    internal class Konyvek
    {
        private int ar;
        private int raktarKeszlet;
        private static int osszesRegisztraltKonyv = 0;
        public string Azonosito;
        public string Cim;
        public string Szerzo;
        public int Ar 
        { get;
          set => ar = value < 0 ? 0 : value;
                }
        public int RaktarKeszlet
        {
            get;
            set => raktarKeszlet = value < 0 ? 0 : value;
        }
        public static int OsszesRegisztraltKonyv 
        {
            get => osszesRegisztraltKonyv;
            set;
        }
        public Konyvek(string azonosito, string cim, string szerzo, int ar):this(azonosito,cim,szerzo,ar,1) 
        {
            
        }
        public Konyvek(string azonosito, string cim, string szerzo, int ar, int raktarKeszlet)
        {
            Azonosito = azonosito;
            Cim = cim;
            Szerzo = szerzo;
            Ar = ar;
            RaktarKeszlet = raktarKeszlet;
            osszesRegisztraltKonyv++;
        }
        public override string ToString()
        {
            return $"{Azonosito} Szerzo: {Cim} - {Ar} Ft | Készlet: {RaktarKeszlet} db";
        }
        public int TeljesErtek()
        {
            return Ar * RaktarKeszlet;
        }
    }
}
