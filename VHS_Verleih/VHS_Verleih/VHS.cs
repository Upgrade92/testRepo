using System;
using System.Collections.Generic;
using System.Linq;

namespace VHS_Verleih
{
    abstract internal class VHS : IProduct
    {
        public static List<VHS> collection = new List<VHS>();
        private string title;
        private double price;
        private string genre;
        private bool borrowed = false;
        public static bool sorted = false;

        public VHS(string title, double price)
        {
            Title = title;
            Price = AddTaxes(price);                    //Interface implementation !!!
            collection.Add(this);
        }

        public string Title { get { return title; } set { title = value; } }
        public double Price { get { return price; } set { price = value; } }
        public string Genre { get { return genre; } set { genre = value; } }
        public bool Borrowed { get { return borrowed; } set { borrowed = value; } }

        public static void AddItems()
        {
            Fantasy fantasy1 = new Fantasy("Lord of the Rings: The Fellowship", 12.99);
            Fantasy fantasy2 = new Fantasy("Lord of the Rings: The two Towers", 13.99);
            Fantasy fantasy3 = new Fantasy("Lord of the Rings: The return of the King", 14.99);

            Action action1 = new Action("John Wick 1", 12.99);
            Action action2 = new Action("John Wick 2", 13.99);
            Action action3 = new Action("John Wick 3", 14.99);

            Education edu1 = new Education("C# for beginners", 17.99);
            Education edu2 = new Education("C# for advanced", 18.99);
            Education edu3 = new Education("C# for experts", 19.99);

            Romance romance1 = new Romance("Love Stories 1", 12.49);
            Romance romance2 = new Romance("Love Stories 2", 13.49);
            Romance romance3 = new Romance("Love Stories 3", 14.49);
        }

        public static void ListSpecific(List<VHS> collection)
        {
            Console.WriteLine($"Index: \t Title:{null,-40}  Price:{null,-5} \t Genre:{null,-15} Borrowed?{null,-10}");
            for (int i = 0; i < 55; i++) { Console.Write("__"); }
            Console.WriteLine("\n");

            foreach (VHS vhs in collection)
            {
                Console.WriteLine($" [{VHS.collection.IndexOf(vhs) + 1}] \t {vhs.Title,-40} \t {vhs.Price.ToString(".##"),-5} \t\t {vhs.Genre,-10}" +
                                  $" \t\t{Helper.TranslateBorrowed(vhs.Borrowed),-10}");
            }
        }

        public static void BorrowByIndex(int index)
        {
            try
            {
                if (VHS.collection[index].borrowed == false)
                {
                    try
                    {
                        VHS.collection[index].Borrowed = true;
                        Console.WriteLine($"\n{VHS.collection[index].title} succesfully borrowed");
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("\nonly numbers please!");
                    }
                }
                else
                {
                    Console.WriteLine("\nnot in house sry!");
                }
            }catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine("\nnot found!");
            }
        }
        public static void ReturnByIndex(int index)
        {
            try
            {
                if (VHS.collection[index].borrowed == true)
                {
                    try
                    {
                        VHS.collection[index].Borrowed = false;
                        Console.WriteLine($"\n{VHS.collection[index].title} succesfully returned");
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("\nonly numbers please!");
                    }
                }
                else
                {
                    Console.WriteLine("\nnothing to return");
                }
            }catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine("\nnot found!");
            }
        }
        public static List<VHS> SortByPrice() 
        {
            List<VHS> sortedList = collection.OrderBy(o => o.Price).ToList();       // Lambda Expression !!
            return sortedList;
        }

        public double AddTaxes(double price)
        {
            return price *= 1.2;
        }
    }

    interface IProduct                                  //Interface !!!!
    {
        double AddTaxes(double price);
    }

    class Fantasy : VHS
    {
        public Fantasy(string title, double price) : base(title, price)
        {
            this.Genre = "Fantasy";
        }
    }

    class Action : VHS
    {
        public Action(string title, double price) : base(title, price)
        {
            this.Genre = "Action";
        }
    }

    class Education : VHS
    {
        public Education(string title, double price) : base(title, price)
        {
            this.Genre = "Education";
        }
    }

    class Romance : VHS
    {
        public Romance(string title, double price) : base(title, price)
        {
            this.Genre = "Romance";
        }
    }
}