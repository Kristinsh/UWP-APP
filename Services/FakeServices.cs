using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using UAR.Models;

namespace UAR.Services
{

    public class FakeService
    {
        //Liste om fylkene
        public static List<Fylker> GetFylker()
        {
           
            return new List<Fylker>()
                {
                    new Fylker() { Name="Møre og Romsdal", Id=0},
                    new Fylker() { Name = "Trønderlag", Id=1},
                    new Fylker() { Name = "Nordland" , Id=2 },
                    new Fylker() { Name = "Hedmark", Id=3 },
                    new Fylker() { Name = "Troms", Id=4 },
                    new Fylker() { Name = "Oslo", Id=5 },
                    new Fylker() { Name = "Akershus", Id=6},
                    
                };
        }
        
        
        //Liste med Kommuner, postnummer og Fylker
        public static List<Kommuner> GetKommuner()
        {
            return new List<Kommuner>()
            {
                new Kommuner() { Name = "Hareid", Id=0, Fylke="Møre og Romsdal", PostNr = new List<int>{ 1232,3242,2342,1231,6943,1704,2123 } },
                new Kommuner() { Name = "Ulsteinvik", Id=1, Fylke="Møre og Romsdal",PostNr = new List<int>{ 1232, 1234, 1412, 1241,3242,2342,1231,6943,1704,2123 }},
                new Kommuner() { Name = "ÅLesund", Id=2, Fylke="Møre og Romsdal", PostNr = new List<int>{ 1232,3242,2342,1231,6943,1704,2123 }},
                new Kommuner() { Name = "Ørsta", Id=3, Fylke="Møre og Romsdal", PostNr = new List<int>{ 1232,3242,2342,1231,6943,1704,2123 }},
                new Kommuner() { Name = "Hitra" ,Id=1, Fylke="Trønderlag", PostNr = new List<int>{ 1232,3242,2342,1231,6943,1704,2123 }},
                new Kommuner() { Name = "Røros", Id=1, Fylke="Trønderlag", PostNr = new List<int>{ 1232,3242,2342,1231,6943,1704,2342,1231,6943,1704,2123 }},  
                new Kommuner() { Name = "Bø" ,Id=2, Fylke="Nordland", PostNr = new List<int>{ 1232,3242,2342,1231,6943,1704,2123 }},
                new Kommuner() { Name = "Bodø" ,Id=2, Fylke="Nordland", PostNr = new List<int>{ 1232,3242,2342,1231,6943,1704,2123 }},
                new Kommuner() { Name = "Elverum" ,Id=3, Fylke="Hedmark", PostNr = new List<int>{ 1232,3242,2342,1221,1231,6943,1704,2123 }},
                new Kommuner() { Name = "Åsnes" ,Id=3, Fylke="Hedmark", PostNr = new List<int>{ 1232,3242,2342,4141,1231,6943,1704,2123 }},
                new Kommuner() { Name = "Bardu" ,Id=4, Fylke="Troms", PostNr = new List<int>{ 1232,3242,2342,1231,6943,1704,2123 }},
                new Kommuner() { Name = "Tromsø" ,Id=4, Fylke="Troms", PostNr = new List<int>{ 1232,3242,2342,100,1442,1421,1421,6943,1704,2123 }},
                new Kommuner() { Name = "Nordstrand" ,Id=5, Fylke="Oslo", PostNr = new List<int>{ 1232,3242,2342,1231,6943,1704,2123 }},
                new Kommuner() { Name = "Ullern" ,Id=5, Fylke="Oslo", PostNr = new List<int>{ 1232,3242,2342,1231,5436,3432,2234,6943,1704,2123 }},
                new Kommuner() { Name = "Asker" ,Id=6, Fylke="Akershus", PostNr = new List<int>{ 1232,3242,2342,1231,6943,1704,2123,4242,2414 }},
                new Kommuner() { Name = "Ski" ,Id=6, Fylke="Akershus", PostNr = new List<int>{ 1232,3242,2342,1231,6943,1704,2123,1400,1404 }},
                new Kommuner() { Name = "Oppegård" ,Id=6, Fylke="Akershus", PostNr = new List<int>{ 1232,3242,2342,1231,6943,1704,2123 }},
            };

        }

        //Henter første fylke vha "navn", returnerer null dersom fylket ikke er der.
        public static Fylker GetFylkeByName(string name)
        {
            var fylker = GetFylker();
            if (fylker != null)
            {
                var fylke = fylker.FirstOrDefault(c => c.Name == name);
                if (fylke != null)
                    return fylke;
                else
                    return null;
            }
            else
                return null;
        }

        //Henter alle kommuner som har definert fylke id i objektet
        public static List<Kommuner> GetAllKommunerByFylkeId(int fylkeId)
        {
            var fylker = GetFylker(); //Henter alle fylker
            if (fylker != null && fylker.Any()) //Hvis det er en eller flere og ikke null...
            {
                var fylke = fylker.FirstOrDefault(c => c.Id == fylkeId); //Henter det første fylket som matcher spørring (id)
                if (fylke != null)
                {
                    return GetKommuner().Where(c => c.Fylke == fylke.Name).ToList(); //returnerer alle fylker hvis det ikke er null
                }
                else
                    return null;

            }
            else
                return null;
        }

        //Returnerer kommunen som har matchende ID 
        public static Kommuner GetKommuneById(int id)
        {
            var kommuner = GetKommuner();
            if(kommuner != null && kommuner.Any())
            {
                var kommune = kommuner.FirstOrDefault(c => c.Id == id); //Finner kommune med matchende Id
                if (kommune != null)
                    return kommune;
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

    }
}

