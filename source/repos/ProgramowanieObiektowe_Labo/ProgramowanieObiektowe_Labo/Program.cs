using System;
using System.Collections.Generic;

namespace ProgramowanieObiektowe_Labo
{

    interface IZarzadzaniePozycjami
    {
        void ZnajdzPozycjePoTytule(string tytul);
        void ZnajdzPozycjePoId(int id);
        void WypiszWszystkiePozycje();
    }

    class Biblioteka : IZarzadzaniePozycjami
    {
        public string adres;
        private List<Katalog> katalogi = new List<Katalog> ();
        private List<Bibliotekarz> bibliotekarze = new List<Bibliotekarz>();

        public Biblioteka(string adres)
        {
            this.adres = adres;
        }

        public void ZnajdzPozycjePoTytule(string tytul)
        {
            Console.WriteLine("\nZNALEZIONE POZYCJE PO TYTULE:");
            foreach (var katalog in katalogi)
            {
                katalog.ZnajdzPozycjePoTytule(tytul);
            }

        }

        public void ZnajdzPozycjePoId(int id)
        {
            Console.WriteLine("\nZNALEZIONE POZYCJE PO ID:");
            foreach (var katalog in katalogi)
            {
                katalog.ZnajdzPozycjePoId(id);
            }

        }

        public void WypiszWszystkiePozycje()
        {
            Console.WriteLine("\nWYPISANIE WSZYSTKICH POZYCJI ZE WSZYSTKICH KATALOGÓW:");
            foreach (var katalog in katalogi)
            {
                katalog.WypiszWszystkiePozycje();
            }

        }

        public void DodajBibliotekarza(Bibliotekarz bibliotekarz)
        {
            bibliotekarze.Add(bibliotekarz);
            Console.WriteLine("Bibliotekarz " + bibliotekarz.imie + " " + bibliotekarz.nazwisko + " został pomyślnie dodany do tej biblioteki.");

        }

        public void WypiszBibliotekarzy()
        {
            foreach(Bibliotekarz bibliotekarz in bibliotekarze)
            {
                Console.WriteLine("Bibliotekarz " + bibliotekarz.imie + " " + bibliotekarz.nazwisko + " ; Wynagrodzenie: " + bibliotekarz.wynagrodzenie + "; Data Zatrudnienia: " + bibliotekarz.dataZatrudnienia + ";");
            }

        }

        public void DodajKatalog(Katalog katalog)
        {
            katalogi.Add(katalog);
            Console.WriteLine("Katalog o nazwie " + katalog.dzialTematyczny + " został pomyślnie dodany do biblioteki.");
        }

        public void DodajPozycje(Pozycja p , string dzialTematyczny_)
        {
            foreach(Katalog katalog in katalogi)
            {
                if(katalog.dzialTematyczny == dzialTematyczny_)
                {
                    katalog.DodajPozycje(p);
                }
            }
        }

    }

    class Osoba
    {
        public string imie;
        public string nazwisko;

        public Osoba (string imie, string nazwisko)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
        }
    }

    class Bibliotekarz : Osoba
    {
        public string dataZatrudnienia;
        public double wynagrodzenie;

        public Bibliotekarz (string imie, string nazwisko, string dataZatrudnienia, double wynagrodzenie) : base(imie, nazwisko)
        {
            this.dataZatrudnienia = dataZatrudnienia;
            this.wynagrodzenie = wynagrodzenie;
        }

    }


    class Katalog : IZarzadzaniePozycjami
    {
        public string dzialTematyczny;
        private List<Pozycja> katalog = new List<Pozycja>();

        public Katalog(string dzialTematyczny_)
        {
            dzialTematyczny = dzialTematyczny_;
        }

        public void DodajPozycje(Pozycja pozycja)
        {
            katalog.Add(pozycja);
            Console.WriteLine("Pozycja o nazwie " + pozycja.tytul + " została pomyślnie dodana do katalogu o nazwie " + dzialTematyczny + ".");
        }

        public void WypiszWszystkiePozycje()
        {
            int i = 1;
            Console.WriteLine("WSZYSTKIE POZYCJE W KATALOGU \"" + dzialTematyczny + "\":");
            foreach (Pozycja pozycja in katalog)
            {
                Console.Write(i + ") ");
                pozycja.WypiszInfo();
                i++;
            }
        }

        public void ZnajdzPozycjePoTytule(string tytul)
        {
            foreach (Pozycja pozycja in katalog)
            {
                if (pozycja.tytul == tytul)
                {
                    pozycja.WypiszInfo();
                }
            }

        }

        public void ZnajdzPozycjePoId(int id)
        {
            foreach (Pozycja pozycja in katalog)
            {
                if (pozycja.id == id)
                {
                    pozycja.WypiszInfo();
                }
            }

        }

        public void ZnajdzPozycje(string tekst)
        {
            Console.WriteLine("ZNALEZIONE POZYCJE:");
            foreach (Pozycja pozycja in katalog)
            {
                if (pozycja.tytul == tekst || pozycja.tytul == tekst)
                {
                    pozycja.WypiszInfo();
                }
            }

        }

        public void ZnajdzPozycje(int liczba)
        {
            Console.WriteLine("ZNALEZIONE POZYCJE:");
            foreach (Pozycja pozycja in katalog)
            {
                if (pozycja.id == liczba || pozycja.rokWydania == liczba)
                {
                    pozycja.WypiszInfo();
                }
            }

        }

        public void ZnajdzPozycje(string tytul ,  string wydawnictwo)
        {
            Console.WriteLine("ZNALEZIONE POZYCJE:");
            foreach (Pozycja pozycja in katalog)
            {
                if (pozycja.tytul == tytul && pozycja.wydawnictwo == wydawnictwo)
                {
                    pozycja.WypiszInfo();
                }
            }

        }
        public void ZnajdzPozycje(string tekst, int liczba)
        {
            Console.WriteLine("ZNALEZIONE POZYCJE:");
            foreach (Pozycja pozycja in katalog)
            {
                if ((pozycja.tytul == tekst || pozycja.wydawnictwo == tekst) && (pozycja.id == liczba || pozycja.rokWydania == liczba))
                {
                    pozycja.WypiszInfo();
                }
            }

        }

        public void ZnajdzPozycje(string tytul , int id , string wydawnictwo , int rokWydania)
        {
            Console.WriteLine("ZNALEZIONE POZYCJE:");
            foreach(Pozycja pozycja in katalog)
            {
                if(pozycja.tytul == tytul && pozycja.id == id && pozycja.wydawnictwo == wydawnictwo && pozycja.rokWydania == rokWydania)
                {
                    pozycja.WypiszInfo();
                }
            }
        }
    }

    abstract class Pozycja
    {
        public string tytul;
        public int id;
        public string wydawnictwo;
        public int rokWydania;

        public Pozycja (string tytul, int id, string wydawnictwo, int rokWydania)
        {
            this.tytul = tytul;
            this.id = id;
            this.wydawnictwo = wydawnictwo;
            this.rokWydania = rokWydania;
        }

        public abstract void WypiszInfo();
    }

    class Ksiazka : Pozycja
    {
        public int liczbaStron;
        private List<Autor> autorzy = new List<Autor>();

        public Ksiazka(string tytul, int id, string wydawnictwo, int rokWydania, int liczbaStron) : base(tytul , id , wydawnictwo , rokWydania)
        {
            this.liczbaStron = liczbaStron;
        }

        public void DodajAutora(Autor autor)
        {
            autorzy.Add(autor);
            Console.WriteLine("Autor " + autor.imie + " " + autor.nazwisko + " dodany pomyślnie do książki o tytule " + this.tytul + "!");
        }

        public override void WypiszInfo()
        {
            string tempAutorzyList = "";

            foreach(Autor autor in autorzy)
            {
                tempAutorzyList = tempAutorzyList + autor.nazwisko + " " + autor.imie + ", ";
            }

            Console.WriteLine("Tytuł: " + tytul + "; ID: " + id + "; Wydawnictwo: " + wydawnictwo + "; Rok Wydania: " + rokWydania + "; Liczba Stron: " + liczbaStron + "; Autorzy: " + tempAutorzyList + ";");
        }

    }

    class Czasopismo : Pozycja
    {
        public int numer;

        public Czasopismo(string tytul , int id , string wydawnictwo , int rokWydania , int numer) : base(tytul , id, wydawnictwo , rokWydania)
        {
            this.numer = numer;
        }

        public override void WypiszInfo()
        {
            Console.WriteLine("Tytuł: " + tytul + "; ID: " + id + "; Wydawnictwo: " + wydawnictwo + "; Rok Wydania: " + rokWydania + "; Numer: " + numer + ";");
        }
    }

    class Autor : Osoba
    {
        public string narodowosc;
        public Autor(string imie, string nazwisko, string narodowosc) : base(imie, nazwisko)
        {
            this.narodowosc = narodowosc;
        }
    }
        class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ZADANIE 1:");

            Katalog katalog = new Katalog("Poradniki");
            Katalog katalog2 = new Katalog("Czasopisma");
            Ksiazka k1 = new Ksiazka("Grzybobranie", 1, "PWN", 2001, 350);
            Ksiazka k2 = new Ksiazka("Jak skutecznie jabłko?", 2, "XYZ", 2015, 229);
            Ksiazka k3 = new Ksiazka("Poradnik C# dla początkujących", 3, "PWN", 2015, 311);
            Czasopismo c1 = new Czasopismo("Pani Domu", 1, "Axel Ringier Springier", 2021, 756);
            Czasopismo c2 = new Czasopismo("CD Action", 2, "Obajtek Press", 2020, 112);
            Czasopismo c3 = new Czasopismo("Click", 3, "Obajtek Press", 2021, 76);
            Autor a1 = new Autor("Kornel", "Makuszyński", "Polska");
            Autor a2 = new Autor("Jan", "Brzechwa", "Polska");

            katalog.DodajPozycje(k1);
            katalog.DodajPozycje(k2);
            katalog.DodajPozycje(k3);
            katalog2.DodajPozycje(c1);
            katalog2.DodajPozycje(c2);
            katalog2.DodajPozycje(c3);



            k1.DodajAutora(a1);
            k1.DodajAutora(a2);

            k2.DodajAutora(a1);

            katalog.WypiszWszystkiePozycje();

            katalog.ZnajdzPozycje("PWN");

            katalog.ZnajdzPozycje(1);

            katalog.ZnajdzPozycje(4);

            katalog2.ZnajdzPozycje("Obajtek Press", 2020);

            Console.WriteLine("\nZADANIE 2:");

            Biblioteka biblioteka = new Biblioteka("ul. Jabłoniowa w Gdańsku");
            Bibliotekarz bibliotekarz1 = new Bibliotekarz("Karol", "Wojtyła", "20.05.2022", 21.37);
            Katalog katalog3 = new Katalog("Bajki");

            biblioteka.DodajBibliotekarza(bibliotekarz1);

            biblioteka.WypiszBibliotekarzy();

            biblioteka.DodajKatalog(katalog);
            biblioteka.DodajKatalog(katalog2);
            biblioteka.DodajKatalog(katalog3);

            Ksiazka k4 = new Ksiazka("Dzieci z Bullerbyn", 1, "Obajtek Press", 2021, 1337);

            biblioteka.DodajPozycje(k4, "Bajki");

            biblioteka.WypiszWszystkiePozycje();

            biblioteka.ZnajdzPozycjePoId(1);

            biblioteka.ZnajdzPozycjePoTytule("Grzybobranie");

            biblioteka.ZnajdzPozycjePoTytule("Pani Domu");

        }
    }
}
