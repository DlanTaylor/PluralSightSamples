using System;
using System.Collections.Generic;
using System.Linq;

namespace TopTenPops
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\dylant\source\repos\TopTenPops\TopTenPops\Pop by Largest Final.csv";
            CsvReader reader = new CsvReader(filePath);

            //displayDict(reader);
            //displayList(reader);
            // displayLinq(reader);
            displayByRegion(reader);

        }

        static void displayByRegion(CsvReader reader)
        {
            Dictionary<string, List<Country>> countries = reader.ReadAllCountriesByRegion();

            foreach (string region in countries.Keys)
            {
                Console.WriteLine(region);
            }

            Console.Write("Which of the above regions do you want? ");
            string chosenRegion = Console.ReadLine();

            if (countries.ContainsKey(chosenRegion))
            {
                foreach (Country country in countries[chosenRegion].Take(10))
                {
                    Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: { country.Name } ");
                }
            }
            else
            {
                Console.WriteLine("That is not a valid region");
            }
        }

        static void displayLinq(CsvReader reader)
        {
            List<Country> countries = reader.ReadAllCountriesList();

            var filteredCountries = countries.Where(x => !x.Name.Contains(',')).Take(20);
            var filteredCountries2 = from country in countries
                                     where !country.Name.Contains(',')
                                     select country;

            int index = 0;
            foreach (Country country in filteredCountries)
            {
                index += 1;
                Console.WriteLine($"{index}: { PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: { country.Name}");
            }
        }

        static void displayList(CsvReader reader)
        {
            List<Country> countries = reader.ReadAllCountriesList();
            reader.RemoveCommaCountries(countries);

            Console.WriteLine("How many countries would you like to display?");
            int userInput = int.Parse(Console.ReadLine());

            int maxToDisplay = userInput;
            for (int i = 0; i < countries.Count; i++)
            {
                if (i > 0 && (i % maxToDisplay == 0))
                {
                    Console.WriteLine("Hit return to continue, anything else to quit>");
                    if (Console.ReadLine() != "")
                        break;
                }

                Country country = countries[i];
                Console.WriteLine($"{ i + 1}: { PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: { country.Name}");

            }
        }

        static void displayDict(CsvReader reader)
        {
            Dictionary<string, Country> countries = reader.ReadAllCountriesDict();

            Console.WriteLine("Which country code do you want to look up? ('q' to quit)");
            string userInput = "";

            while (userInput != "Q")
            {
                Console.Write("Code> ");
                userInput = Console.ReadLine();
                userInput = userInput.ToUpper();

                bool gotCountry = countries.TryGetValue(userInput, out Country country);
                if (!gotCountry)
                {
                    Console.WriteLine($"Sorry, there is no country with code, {userInput}");
                }
                else
                {
                    Console.WriteLine($"{country.Name} has population " +
                        $"{PopulationFormatter.FormatPopulation(country.Population)}");
                }
            }
        }
    }
}
