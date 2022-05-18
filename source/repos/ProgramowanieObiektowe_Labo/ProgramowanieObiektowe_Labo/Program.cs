using System;
using System.Collections.Generic;

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

        public virtual void WypiszInfo()
        {
            Console.WriteLine("Imię: " + imie + "; Nazwisko: " + nazwisko + "; Data Urodzenia: " + dataUrodzenia + ";");
        }
    }

        class Student: Osoba
    {
        public int rok;
        public int grupa;
        public int nrIndeksu;
        private List<Ocena> oceny = new List<Ocena>();

        public Student(string imie_ , string nazwisko_ , string dataUrodzenia_ , int rok_ , int grupa_ , int nrIndeksu_) : base(imie_, nazwisko_, dataUrodzenia_)
        {
            rok = rok_;
            grupa = grupa_;
            nrIndeksu = nrIndeksu_; 
        }
        public override void WypiszInfo()
        {
            Console.WriteLine("Imię: " + imie + "; Nazwisko: " + nazwisko + "; Data Urodzenia: " + dataUrodzenia + "; Rok: " + rok + "; Grupa: " + grupa + "; Nr. Indeksu: " + nrIndeksu + ";");
            WypiszOceny();
        }

        public void DodajOcene()
        {
            string przedmiot_;
            string data_;
            double ocena_;

            Console.WriteLine("// Z jakiego przedmiotu ocenę chcesz dodać? (podaj nazwę)");
            przedmiot_ = Console.ReadLine();
            Console.WriteLine("// Podaj datę otrzymania oceny:");
            data_ = Console.ReadLine();
            Console.WriteLine("// Podaj otrzymaną ocenę:");
            ocena_ = double.Parse(Console.ReadLine());
            oceny.Add(new Ocena(przedmiot_, data_ , ocena_));
        }

        public void DodajOcene(string przedmiot_ , string data_ , double ocena_)
        {
            oceny.Add(new Ocena(przedmiot_, data_, ocena_));
        }

        public void WypiszOceny()
        {
            Console.WriteLine("LISTA OCEN STUDENTA " + this.imie + " " + this.nazwisko + ": ");
            foreach(Ocena oc in this.oceny)
            {
                oc.WypiszInfo();
            }
            Console.WriteLine("--------------------------------------------------------------");
        }

        public void WypiszOceny(string przedmiot_)
        {
            Console.WriteLine("LISTA OCEN STUDENTA " + this.imie + " " + this.nazwisko + " Z PRZEDMIOTU: " + przedmiot_ + ": ");

            foreach (Ocena ocena in this.oceny)
            {
                if (ocena.nazwaPrzedmiotu.Equals(przedmiot_))
                {
                    ocena.WypiszInfo();
                }
            }
        }

        public void UsunOcene(string nazwaPrzedmiotu_ , string data_ , double wartosc_)
        {
            for (int i = 0;  i < this.oceny.Count; )
            {
                Ocena o = oceny[i];
                if(o.nazwaPrzedmiotu == nazwaPrzedmiotu_ && o.data == data_ && o.wartosc == wartosc_)
                {
                    oceny.RemoveAt(i);
                } else
                {
                    ++i;
                }
            } 
        }

        public void UsunOceny()
        {
            oceny.Clear();
        }

        public void UsunOceny(string nazwaPrzedmiotu_)
        {
            for (int i = 0; i < this.oceny.Count;)
            {
                Ocena o = oceny[i];
                if(o.nazwaPrzedmiotu == nazwaPrzedmiotu_)
                {
                    oceny.RemoveAt(i);
                } else
                {
                    ++i;
                }
            }
        }
    }

        class Pilkarz : Osoba
    {
        public string pozycja;
        public string klub;
        public int liczbaGoli = 0;

        public Pilkarz(string imie_ , string nazwisko_, string dataUrodzenia_ , string pozycja_ , string klub_) : base(imie_ , nazwisko_, dataUrodzenia_)
        {
            pozycja = pozycja_;
            klub = klub_;
        }
        public override void WypiszInfo()
        {
            Console.WriteLine("Imię: " + imie + "; Nazwisko: " + nazwisko + "; Data Urodzenia: " + dataUrodzenia + "; Pozycja: " + pozycja + "; Klub: " + klub + "; Liczba goli: " + liczbaGoli + ";");
        }

        public virtual void StrzelGola()
        {
            this.liczbaGoli++;
        }
    }

    class PilkarzReczny : Pilkarz
    {
        public PilkarzReczny(string imie_, string nazwisko_, string dataUrodzenia_, string pozycja_, string klub_) : base(imie_, nazwisko_, dataUrodzenia_, pozycja_, klub_)
        {

        }

        public override void StrzelGola()
        {
            base.StrzelGola();
            Console.WriteLine(">>Ręczny strzelił!");
        }
    }

    class PilkarzNozny : Pilkarz
    {
        public PilkarzNozny(string imie_, string nazwisko_, string dataUrodzenia_, string pozycja_, string klub_) : base(imie_, nazwisko_, dataUrodzenia_, pozycja_, klub_)
        {

        }

        public override void StrzelGola()
        {
            base.StrzelGola();
            Console.WriteLine(">>Nożny strzelił!");
        }
    }

    class Ocena
    {
        public string nazwaPrzedmiotu;
        public string data;
        public double wartosc;

        public Ocena(string nazwaPrzedmiotu_ , string data_ , double wartosc_)
        {
            this.nazwaPrzedmiotu = nazwaPrzedmiotu_;
            this.data = data_;
            this.wartosc = wartosc_;
        }

        public void WypiszInfo()
        {
            Console.WriteLine("Przedmiot: " + nazwaPrzedmiotu + "; Data: " + data + "; Ocena: " + wartosc + ";");
        }
    }

        class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ZADANIE 1:");

            Osoba o = new Osoba("Adam", "Miś", "20.03.1980");
            Osoba o2 = new Student("Michał", "Kot", "13.04.1990", 2, 1, 123456);
            Osoba o3 = new Pilkarz("Mateusz", "Żbik", "10.08.1986", "Napastnik", "FC Polibuda");

            o.WypiszInfo();
            o2.WypiszInfo();
            o3.WypiszInfo();

            Student s = new Student("Krzysztof", "Jeż", "22.12.1990", 2, 5, 54321);
            Pilkarz p = new Pilkarz("Piotr", "Kos", "14.09.1984", "Napastnik", "FC Jaguar Kokoszki");

            s.WypiszInfo();
            p.WypiszInfo();

            ((Pilkarz)o3).StrzelGola();
            p.StrzelGola();
            p.StrzelGola();

            o3.WypiszInfo();
            p.WypiszInfo();

            Console.ReadKey();

            Console.WriteLine("ZADANIE 2:");

            ((Student)o2).DodajOcene("PO", "20.02.2021" , 5.0);
            ((Student)o2).DodajOcene("Bazy Danych", "13.02.2021", 4.0);

            o2.WypiszInfo();

            s.DodajOcene("Bazy Danych", "01.05.2021", 5.0);
            s.DodajOcene("AWWW", "11.05.2021", 5.0);
            s.DodajOcene("AWWW", "02.04.2021", 4.5);

            s.WypiszInfo();

            s.UsunOcene("AWWW", "02.04.2021", 4.5);

            s.WypiszInfo();

            s.DodajOcene("AWWW", "02.04.2021", 4.5);
            s.UsunOceny("AWWW");

            s.WypiszInfo();

            s.DodajOcene("AWWW", "02.04.2021", 4.5);
            //s.DodajOcene();

            s.WypiszInfo();

            s.UsunOceny();

            s.WypiszInfo();

            Console.ReadKey();

            Console.WriteLine("ZADANIE DOMOWE: ");

            Pilkarz pr = new PilkarzReczny("Karol", "Bielecki", "14.10.1984", "Napastnik", "FC Barcelona");
            Pilkarz pn = new PilkarzNozny("Robert", "Lewandowski", "14.07.1984", "Napastnik", "Bayern FC");

            pr.StrzelGola();
            pn.StrzelGola();
            pr.StrzelGola();

            pr.WypiszInfo();
            pn.WypiszInfo();

        }
    }
}
