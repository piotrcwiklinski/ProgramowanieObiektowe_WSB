using System;

namespace ProgramowanieObiektowe_Labo
{

    public class Samochod
    {
        private string marka;
        private string model;
        private int ileDrzwi;
        private double pojemnoscSilnika;
        private double srednieSpalanie;
        public string Marka
        {
            get { return marka; }
            set { marka = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int IleDrzwi
        {
            get { return ileDrzwi; }
            set { ileDrzwi = value; }
        }
        public double PojemnoscSilnika
        {
            get { return pojemnoscSilnika; }
            set { pojemnoscSilnika = value; }
        }
        public double SrednieSpalanie
        {
            get { return srednieSpalanie; }
            set { srednieSpalanie = value; }
        }

        private static int ileAut = 0;

        private double ObliczSpalanie(double dlugoscTrasy)
        {
            double spalanie = (srednieSpalanie * dlugoscTrasy) / 100.0;
            return spalanie;
        }

        public double ObliczKosztPrzejazdu(double dlugoscTrasy, double cenaPaliwa)
        {
            double spalanie = ObliczSpalanie(dlugoscTrasy);
            double kosztPrzejazdu = spalanie * cenaPaliwa;
            return kosztPrzejazdu;
        }

        public void WypiszInfo()
        {
            Console.WriteLine("Marka: " + marka + " Model: " + model + " Ilość Drzwi: " + ileDrzwi + " Pojemność Silnika: " + pojemnoscSilnika + " Średnie Spalanie: " + srednieSpalanie);
        }

        public static void WypiszIloscSamochodow()
        {
            Console.WriteLine("Ilość aut zarejestrowanych w bazie: " + ileAut);
        }

        public Samochod()
        {
            marka = "Nieznana marka";
            model = "Nieznany model";
            ileDrzwi = 0;
            pojemnoscSilnika = 0.0;
            srednieSpalanie = 0.0;
            ileAut++;
            Console.WriteLine("Dodano do bazy następujący samochód: " + marka + " " + model + ";");
            WypiszIloscSamochodow();
        }

        public Samochod(string marka_, string model_, int ileDrzwi_, double pojemnoscSilnika_, double srednieSpalanie_ )
        {
            marka = marka_;
            model = model_;
            ileDrzwi = ileDrzwi_;
            pojemnoscSilnika = pojemnoscSilnika_;
            srednieSpalanie = srednieSpalanie_;
            ileAut++;
            Console.WriteLine("Dodano do bazy następujący samochód: " + marka + " " + model + ";");
            WypiszIloscSamochodow();
        }

        public override string ToString()
        {
            string newString = marka + " " + model + ";";
            return newString;
        }

    }


    public class Garaz
    {
        private string adres;
        private int pojemnosc;
        private int liczbaSamochodow = 0;
        private Samochod[] samochody;

        public string Adres
        {
            get { return adres; }
            set { adres = value; }
        }
        public int Pojemnosc
        {
            get { return pojemnosc; }
            set
            {
                pojemnosc = value;
                samochody = new Samochod[pojemnosc];
            }
        }

        public Garaz()
        {
            adres = "Nieznany adres";
            pojemnosc = 0;
            samochody = null;
        }

        public Garaz(string adres_, int pojemnosc_)
        {
            adres = adres_;
            pojemnosc = pojemnosc_;
            samochody = new Samochod[pojemnosc_];
        }

        public void WprowadzSamochod(Samochod samochod)
        {
            if(liczbaSamochodow >= samochody.Length)
            {
                Console.WriteLine("W Twoim garażu znajduje się już zbyt wiele pojazdów! Nie masz miejsca na kolejny!");
            } else
            {
                samochody[liczbaSamochodow] = samochod;
                Console.WriteLine("Samochód " + samochod.Marka + " " + samochod.Model + " został pomyślnie dodany do Twojego garażu na miejscu nr: " + liczbaSamochodow + ";");
                liczbaSamochodow++;
            }
        }

        public Samochod WyprowadzSamochod()
        {
            if(liczbaSamochodow == 0)
            {
                Console.WriteLine("Twója garaż jest pusty i nie można wyprowadzić z niego żadnego samochodu.");
                return null;
            } else
            {
                Samochod temp = samochody[liczbaSamochodow - 1];
                samochody[liczbaSamochodow - 1] = null;
                liczbaSamochodow--;
                Console.WriteLine("Samochód, który opuścił Twój garaż to: " + temp);
                return
                temp;
            }
        }

        public void WypiszInfo()
        {
            Console.WriteLine("/// ZAWARTOŚĆ TWOJEGO GARAŻU ///");
            if (liczbaSamochodow > 0) { 
            for (int i = 0; i < samochody.Length; i++)
            {
                if (samochody[i] != null)
                {
                    Console.Write("[MIEJSCE " + i + "]");
                    samochody[i].WypiszInfo();
                }
            }
        } else
            {
                Console.WriteLine("Niestety, Twój garaż jest obecnie pusty...");
            }

        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Samochod opel = new Samochod();

            Samochod vw = new Samochod("Volkswagen", "Passat", 5, 2.4, 10.0);

            Samochod ford = new Samochod("Ford", "Fiesta", 3, 1.0, 5.5);

            Console.WriteLine("Koszt przejazdu samochodem Volkswagen na trasie 500 KM przy cenie benzyny 6.25 PLN/litr: " + vw.ObliczKosztPrzejazdu(500.0, 6.25) + " złotych.");

            vw.WypiszInfo();

            Garaz mojGaraz = new Garaz("ul. Lawendowe Wzgórze 15, Gdańsk", 3);

            Console.WriteLine("");

            mojGaraz.WypiszInfo();

            mojGaraz.WyprowadzSamochod();

            mojGaraz.WprowadzSamochod(opel);

            mojGaraz.WprowadzSamochod(vw);

            mojGaraz.WyprowadzSamochod();

            //mojGaraz.WyprowadzSamochod();

            mojGaraz.WprowadzSamochod(ford);

            mojGaraz.WypiszInfo();

        }
    }
}
