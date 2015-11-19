﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Rental_Group2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, DateTime> filmRental = new Dictionary<string, DateTime>();
            string answer1 = "SQUIRRELS ARE AMAZING";

            while (answer1 != "close")
            {
                Console.WriteLine(" **********PARTY PARTY PARTY ********* \n Enter 1: to add entries \n Enter 2: to return a video \n Enter 3: to check overdue accounts");
                string answerxx = Console.ReadLine();
                answer1 = answerxx.ToLower();
                if (answer1 == "1")
                {
                    addEntries(filmRental); //calling method to add entry
                }

                else if (answer1 == "3")
                {
                    printOverdue(filmRental);
                    // calling method to print all overdue
                }
                else if (answer1 == "2")
                {
                    returns(filmRental);
                }

                else if (answer1 !="1" || answer1 != "2" || answer1 != "3")
                {
                    Console.WriteLine("check syntax");
                }
                else { }


            }


        } //closing for main 
        static void printOverdue(Dictionary<string, DateTime> filmRental)  //method that prints overdue
        {
            foreach (KeyValuePair<string, DateTime> film in filmRental)
            {
                DateTime x = DateTime.Now.AddDays(6); //if after due date negative number using 6 prints negative 
                DateTime kValue = film.Value;
                int diff = DateTime.Compare(kValue, x);     //prints overdue movies
                if (diff == -1)
                {
                    Console.WriteLine(film + " is overdue");
                }
                else
                {
                    Console.WriteLine("There are no entries to retrieve!!");
                }
            }
        }  //closing for overdue method


        static Dictionary<string, DateTime> addEntries(Dictionary<string, DateTime> filmRental)  //add entries method 
        {
            
            Console.WriteLine("Enter the customers name.");
            string key = Console.ReadLine();   //asigning the input to the key
            DateTime dueDate = DateTime.Now.Date.AddDays(7); //CHANGE TO 3 TO MAKE OVERDUE
            filmRental.Add(key, dueDate);  //adding entry to the dictionary 
            Console.WriteLine("entry added");
            return filmRental;

        }




        static Dictionary<string, DateTime> returns(Dictionary<string, DateTime> filmRental)  //add entries method 
        {
            Console.WriteLine("enter the customers name to return the movie");

            string returnedMovie = Console.ReadLine();
                if (filmRental.ContainsKey(returnedMovie))
                {


                 DateTime x = DateTime.Now.AddDays(6); //if after due date negative number using 6 prints negative 
                 DateTime kValue = filmRental[returnedMovie];
                 int diff = DateTime.Compare(kValue, x);     //prints overdue movies
                 if (diff == -1)
                 {
                     Console.WriteLine(returnedMovie + " is overdue you owe $7");

                 }
                 else
                 {
                    Console.WriteLine(returnedMovie + " owes $5");
                 }
                }
                
            
                Console.WriteLine("Entry Not Found");
            
                filmRental.Remove(returnedMovie);
                return filmRental;
         
        }
    }
}

