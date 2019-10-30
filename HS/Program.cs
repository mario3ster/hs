namespace HS
{
    using HS.Data;
    using HS.Filters;
    using HS.Lists;
    using HS.Models;
    using HS.Sorting;
    using HS.Paging;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    class Program
    {
        private static DataContext context = new DataContext();

        private static ItemsList<Boat> InitBoats()
        {
             var boats = context.GetEntities<Boat>(); 
             var pager = new DefaultPager(3, boats.Count());
           
             //var boatsList = new ItemsList<Boat>(boats, filters, boatsSorters);
            var boatsList = new ItemsList<Boat>(boats, pager);
        
            var filters = new List<IFilter<Boat>>()
            {
                new CabinsFilter(5),
                new HullTypeFilter(HullType.Mono)
            };

            var boatsSorters = new List<ISortModifier<Boat>>()
            {
                new SortByCabinsNum()
            };

            return boatsList;
        }

        private static ItemsList<Skipper> InitSkippers()
        {         
            var skippers = context.GetEntities<Skipper>();   
            var pager = new DefaultPager(4, skippers.Count());

            var skippersSorters = new List<ISortModifier<Skipper>>()
            {
                new SortByExperience() { Asc = true },
                new SortByPrice() { Asc = false }
            };

           
            var skipperList = new ItemsList<Skipper>(skippers, pager, null, skippersSorters);

            return skipperList;
        }

        static void Main(string[] args)
        {
            var boatsList = InitBoats();
            var skippersList = InitSkippers();

            Console.WriteLine("Boats: ");

            foreach (var boat in boatsList.Items)
            {
                Console.WriteLine(boat.ToString());
            }

            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Skippers: ");

            foreach (var skipper in skippersList.Items)
            {
                Console.WriteLine(skipper.ToString());
            }

            do
            {
                System.Console.WriteLine("Enter Next / Prev for paging (or Exit)");
                string userCommand = Console.ReadLine();

                if (userCommand == "Exit") break;

                switch (userCommand)
                {
                    case "Next":
                        boatsList.Pager.GoNextPage();
                        skippersList.Pager.GoNextPage();
                        break;

                    case "Prev":
                        boatsList.Pager.GoPrevPage();
                        skippersList.Pager.GoPrevPage();
                        break;

                    default:
                        break;
                }

                foreach (var boat in boatsList.Items)
                {
                    Console.WriteLine(boat.ToString());
                }

                foreach (var skipper in skippersList.Items)
                {
                    Console.WriteLine(skipper.ToString());
                }

                System.Console.WriteLine("Page " + boatsList.Pager.CurrentPage + "/" + boatsList.Pager.TotalPagesCount);

            } while (true);
        }
    }
}