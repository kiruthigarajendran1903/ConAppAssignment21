using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConAppAssignment21
{


    public class LearningProgram
    {
            public static List<string> fruits = new List<string>(){
                "Apple","Banana","Orange","Grapes","Mango","Stawberry","Watermelon", "Pineapple", "Cherry", "Pear"

        };

        public static List<string> Days = new List<string>()
        {
"Sunday","Monday","Tuesday","Wednesday","Thursday","Friday","Saturday"
        };


        public static List<string> months = new List<string>
        {
            "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"
        };

        static Dictionary<string, string> wordMeanings = new Dictionary<string, string>
        {
            { "Happy", "Feeling or showing pleasure or contentment." },
            { "Brave", "Ready to face and endure danger or pain; showing courage." },
            { "Gentle", "Having or showing a mild, kind, or tender temperament or character." },
            { "Bright", "Giving out or reflecting much light; capable of shining." },
            { "Calm", "Not showing or feeling nervousness, anger, or other strong emotions." }
        };

        public static void DisplayDays()
        {
            Thread.Sleep(14000);
            Console.WriteLine("\nDays of the Week:");
            foreach (var day in Days)
            {
                Thread.Sleep(2000);
                Console.Write(day + ", ");
               
            }
            Console.WriteLine();
        }

        public static void DisplayMonths()
        {
            Thread.Sleep(5000);
            Console.WriteLine("\nMonths of the Year:");
            int displayInterval = 24000 / months.Count;
            foreach (var month in months)
            {
                Thread.Sleep(2000);
                Console.Write(month + ", ");
                Thread.Sleep(displayInterval);
              
            }
         

        }
        public static void DisplayFruitsAndWordMeanings()
        {
            Console.WriteLine("\n\nFruits and Meanings");
            Thread fruitsThread = new Thread(() =>
            {
                foreach (var fruit in fruits)
                {
                    //Thread.Sleep(1000);
                    Console.Write(fruit + ", ");
                }
            });

            
            Thread meaningsThread = new Thread(() =>
            {
                foreach (var kvp in wordMeanings)
                {
                    //Thread.Sleep(1000);
                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                }
            });

            fruitsThread.Start();
            meaningsThread.Start();
            fruitsThread.Join();
            meaningsThread.Join();
        }


    
     
        static void Main(string[] args)
        {
            Console.WriteLine("______Welcome to Learning_____\n");
            Thread daysThread = new Thread(DisplayDays);
            Thread monthsThread = new Thread(DisplayMonths);
            Thread fruitsAndMeaningsThread = new Thread(DisplayFruitsAndWordMeanings);

            daysThread.Start();
            daysThread.Join();

            Thread.Sleep(5000); 

            monthsThread.Start();
            monthsThread.Join();

            fruitsAndMeaningsThread.Start();
            fruitsAndMeaningsThread.Join();

            Console.ReadKey();

        }
    }
}
