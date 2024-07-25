using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ispit.Model
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Proizvod> ListaProizvoda = new List<Proizvod>();
            ListaProizvoda.Add(new Proizvod(1, "Čokolada - za kuhanje"));
            ListaProizvoda.Add(new Proizvod(2, "Lino Lada – Gold"));
            ListaProizvoda.Add(new Proizvod(3, "Papir za pečenje"));
            ListaProizvoda.Add(new Proizvod(4, "Brašno – pšenično"));
            ListaProizvoda.Add(new Proizvod(5, "Šećer – standard"));

            List<Racun> ListaRacuna = new List<Racun>();
            ListaRacuna.Add(new Racun(100, 3, 800));
            ListaRacuna.Add(new Racun(101, 2, 650));
            ListaRacuna.Add(new Racun(102, 3, 900));
            ListaRacuna.Add(new Racun(103, 4, 700));
            ListaRacuna.Add(new Racun(104, 3, 900));
            ListaRacuna.Add(new Racun(105, 4, 650));
            ListaRacuna.Add(new Racun(106, 1, 458));

            Console.WriteLine("Ovdje je popis proizvoda: ");
            Console.WriteLine("===================================");
            foreach (Proizvod proizvod in ListaProizvoda)
            {
                Console.WriteLine($"ID: {proizvod.ProizvodID}, Naziv: {proizvod.Naziv}");
            }

            Console.WriteLine("Ovdje je popis racuna: ");
            Console.WriteLine("===================================");
            foreach (Racun racun in ListaRacuna)
            {
                Console.WriteLine($"Broj racuna: {racun.BrojRacuna}, ID proizvoda: {racun.ProizvodID}, Kolicina: {racun.Kolicina}");
            }


            var SortiraniProizvodi = (from proizvod in ListaProizvoda
                                      orderby proizvod.Naziv ascending
                                      select proizvod).ToList();
            Console.WriteLine("Ovdje je popis proizvoda sortiran po nazivu: ");
            Console.WriteLine("===================================");
            foreach (Proizvod proizvod in SortiraniProizvodi)
            {
                Console.WriteLine($"ID: {proizvod.ProizvodID}, Naziv: {proizvod.Naziv}");
            }

            var ListaSpojenihPodataka = from proizvod in ListaProizvoda
                                        join racun in ListaRacuna
                                        on proizvod.ProizvodID equals racun.ProizvodID
                                        select new
                                        {
                                            proizvod.ProizvodID,
                                            proizvod.Naziv,
                                            racun.Kolicina
                                        };

            Console.WriteLine("Evo popisa nakon pridruzivanja: \n\n");
            Console.WriteLine("ID proizvoda \t Naziv proizvoda \t Kupljena kolicina");
            Console.WriteLine("========================================================");
            foreach (var spojeni in ListaSpojenihPodataka)
            {
                Console.WriteLine($"{spojeni.ProizvodID}\t\t{spojeni.Naziv}\t\t{spojeni.Kolicina}");
            }
        }
    }
}