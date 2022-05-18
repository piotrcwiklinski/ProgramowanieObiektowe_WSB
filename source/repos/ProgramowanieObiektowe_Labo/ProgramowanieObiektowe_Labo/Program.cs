using System;

namespace ProgramowanieObiektowe_Labo
{

        class Osoba
    {
        public string imie;
        public string nazwisko;
        public string dataUrodzenia;

        public Osoba(string imie_ , string nazwisko_ , string dataUrodzenia_)
        {
            imie = imie_;
            nazwisko = nazwisko_;
            dataUrodzenia = dataUrodzenia_;
        }

        public void WypiszInfo()
        {

        }
    }

        class Student: Osoba
    {
        public int rok;
        public int grupa;
        public int nrIndeksu;
    }

        class Pilkarz : Osoba
    {
        public string pozycja;
        public string klub;
        public int liczbaGoli = 0;
    }

        class Program
    {
        static void Main(string[] args)
        {

            
        }
    }
}
