﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHS_Verleih
{
    abstract internal class VHS
    {
        public static List<VHS> collection = new List<VHS>();
        private string title;
        private double price;
        private string genre;
        private bool borrowed = false;

        public VHS(string title, double price)
        {
            Title = title;
            Price = price;
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
        }

        public static void ListAll()
        {
            Console.WriteLine($"Index: \t Title:{null,-40}  Price:{null,-5} \t Genre:{null,-15} Borrowed?{null,-10}");
            for(int i = 0; i < 53; i++) { Console.Write("__"); }
            Console.WriteLine("\n");           

            foreach (VHS vhs in VHS.collection)
            {
                Console.WriteLine($" [{VHS.collection.IndexOf(vhs)+1}] \t {vhs.title,-40} \t {vhs.price,-5} \t\t {vhs.genre,-10} \t\t{vhs.borrowed,-10}");
            }
        }
        public static void BorrowByIndex(int index)
        {
            if (VHS.collection[index].borrowed == false)
            {
                try
                {
                    VHS.collection[index].Borrowed = true;
                    Console.WriteLine($"{VHS.collection[index].title} succesfully borrowed");
                }
                catch (FormatException e)
                {
                    Console.WriteLine("only numbers please!");
                }
            }
            else
            {
                Console.WriteLine("not in house sry!");
            }
        }
        public static void ReturnByIndex(int index)
        {
            if (VHS.collection[index].borrowed == true)
            {
                try
                {
                    VHS.collection[index].Borrowed = false;
                    Console.WriteLine($"{VHS.collection[index].title} succesfully borrowed");
                }
                catch (FormatException e)
                {
                    Console.WriteLine("only numbers please!");
                }
            }
            else
            {
                Console.WriteLine("nothing to return");
            }
        }
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

}
