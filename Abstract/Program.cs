using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{

    //nie możemy wykorzystać wiecej tej klasy, jak mamy sealed
    //nie traktujemy to jako klase bazową
    sealed class Spagetti:Danie_bezmiesne
    {
        public Spagetti(string skladniki, string[] lista_alergenow) : base(skladniki, lista_alergenow) { }

        public override double czasOczekiwania()
        {
            return 20;
        }
        public override double iloscKalorii()
        {
            return 500;
        }
        public override string[] listaAlergenow()
        {
            return lista_alergenow;
        }
        public override string ToString()
        {
            return $"Spagetti {skladniki}";
        }
    }
    sealed class Rolada : Danie_miesne
    {
        public Rolada(string rodzaj_miesa, string[] lista_alergenow) : base(rodzaj_miesa, lista_alergenow) { }

        public override double czasOczekiwania()
        {
            return 30;
        }
        public override double iloscKalorii()
        {
            return 1000;
        }
        public override string[] listaAlergenow()
        {
            return lista_alergenow;
        }
        public override string ToString()
        {
            return $"Rolada {rodzaj_miesa}";
        }
    }
    abstract class Danie_bezmiesne : Danie
    {
        protected string skladniki;

        public Danie_bezmiesne(string skladniki, string[] lista_alergenow) : base(lista_alergenow)
        {
            this.skladniki = skladniki;

        }
        public abstract override double czasOczekiwania();
        public abstract override double iloscKalorii();
        public abstract override string[] listaAlergenow();
    }

    abstract class Danie_miesne : Danie
    {
       protected string rodzaj_miesa;

        public Danie_miesne(string rodzaj_miesa, string[] lista_alergenow): base(lista_alergenow)
        {
            this.rodzaj_miesa = rodzaj_miesa;

        }
        public abstract override double czasOczekiwania();
        public abstract override double iloscKalorii();
        public abstract override string[] listaAlergenow();
    }
    abstract class Danie : IDanie
    {
        protected string[] lista_alergenow;
        public Danie(string[] lista_alergenow)
        {
            this.lista_alergenow = lista_alergenow;
        }
        public abstract double czasOczekiwania();
        public abstract double iloscKalorii();
        public abstract string[] listaAlergenow();
    }
    interface IDanie
    {
          double czasOczekiwania();
          double iloscKalorii();
          string[] listaAlergenow();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Rolada rolada = new Rolada("wołowa", new string[] {"ryby "," orzechy ", " gluten"});
            Console.WriteLine(rolada);
            Console.WriteLine($"Czas oczekiwania = {rolada.czasOczekiwania()}");

            foreach (var alergen in rolada.listaAlergenow())
            {
                Console.Write(alergen);
            }
            Console.WriteLine("");
            Console.WriteLine("__________________________________________");
            Spagetti spagetti = new Spagetti(" z warzywami i śmietaną", new string[] { "laktoza ", " gluten" });
            Console.WriteLine(spagetti);
            Console.WriteLine($"Czas oczekiwania = {spagetti.czasOczekiwania()}");

            foreach (var alergen in spagetti.listaAlergenow())
            {
                Console.Write(alergen);
            }
            Console.WriteLine("");
            Console.WriteLine("__________________________________________");
            Spagetti spagetti2 = new Spagetti(" z sosem bolognese", new string[] { " gluten" });
            Console.WriteLine(spagetti2);
            Console.WriteLine($"Czas oczekiwania = {spagetti2.czasOczekiwania()}");

            foreach (var alergen in spagetti.listaAlergenow())
            {
                Console.Write(alergen);
            }
            Console.ReadKey();
        }
    }
}
