using System;
using System.Collections.Generic;
using DI_Datareader;
using System.Linq;
using System.Diagnostics;

namespace dependency_injection_console
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonLoader ps = new PersonLoader("fr");

            // DBReader reader = new DBReader();
            // FileReader reader = new FileReader();
            // PersonLoaderDI ps = new PersonLoaderDI(reader);

            // reader.loader = new FileLoader("anotherFile.txt"); // Property Injection


            /**************************************
                 Läs in persondata
            **************************************/
            List<Person> people = ps.GetPeopleData().ToList();

            if (people.Count != 0)
            {
                Console.Clear();
                Console.WriteLine("People from database");
                Console.WriteLine("---------------------------");
                foreach (var p in people)
                {
                    Console.WriteLine($"Name: {p.FirstName} {p.LastName} | Age: {p.Age}");
                }

                // Console.WriteLine($"\nData read from: {ps.dataReader.GetType()}");
                Console.WriteLine("---------------------------");
            }  
            else
            {
                Console.WriteLine("No records found...");
            }
        }
    }
}
