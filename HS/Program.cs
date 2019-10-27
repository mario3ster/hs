using HS.Data;
using HS.Filters;
using HS.Lists;
using HS.Models;
using HS.Sorting;
using System;
using System.Collections.Generic;

namespace HS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("HS ver. 1.0");

            var context = new DataContext();

            var boats = context.GetEntities<Boat>();
  
            var filters = new List<IFilter<Boat>>()
            {
                new CabinsFilter(5),
                new HullTypeFilter(HullType.Mono)
            };

            var boatsSorters = new List<ISortModifier<Boat>>()
            {
                new SortByCabinsNum()
            };

            var boatsList = new ItemsList<Boat>(boats, filters, boatsSorters);
            //var boatsList = new ItemsList<Boat>(boats);


            Console.WriteLine("Boats: ");


            foreach (var boat in boatsList.Items)
            {
                Console.WriteLine( boat.ToString() ); 
            }

            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Skippers: ");

            var skippersSorters = new List<ISortModifier<Skipper>>()
            {
                new SortByExperience() { Asc = true },
                new SortByPrice() { Asc = false }
            };

            var skippers = context.GetEntities<Skipper>();
            var skipperList = new ItemsList<Skipper>(skippers, null, skippersSorters);

            foreach (var skipper in skipperList.Items)
            {
                Console.WriteLine(skipper.ToString());
            }

            Console.ReadLine();
        }
    }
}
