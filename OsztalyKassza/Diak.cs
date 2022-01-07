using System;
using System.Collections.Generic;
using System.Text;

namespace OsztalyKassza
{
    class Diak
    {
        private string nev;
        private string omAz;
        private int befOssz;
        private int befSzam;
        private int egyenleg;

        public Diak() { }

        public Diak(string nev,string omAz)
        {
            this.nev = nev;
            this.omAz = omAz;
            befOssz = 0;
            befSzam = 0;
            egyenleg = 0;
        }

        public string getNev() { return nev; }
        public int getBefOssz() { return befOssz; }
        public int getBefSzam() { return befSzam; }
        public int getEgyenleg() { return egyenleg; }

        public void osztalyPenzBefizetes()
        {
            befOssz += 3000;
            befSzam++;
            egyenleg += 3000;
        }
        public void osztalyPenzBefizetes(int osszeg)
        {
            befOssz += osszeg;
            befSzam++;
            egyenleg += osszeg;
        }
        public int visszateritendo()
        {
            if (egyenleg > 0)
            {
                return egyenleg;
            }
            else 
            {
                return 0;
            }
        }

        public void kiadas(int osszeg)
        {
            egyenleg -= osszeg;
        }
    }
}
