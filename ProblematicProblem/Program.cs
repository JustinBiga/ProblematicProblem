using System;
using System.Collections.Generic;
using System.Threading;

public class Program
{
    static bool cont = true;
    static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
    static void Main(string[] args)
    {
        Random rng = new Random();

        Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
        bool cont;
        if (Console.ReadLine().ToLower() == "yes")
        {
            cont = true;
        }
        else
        {
            cont = false;
        }
        Console.WriteLine();
        Console.Write("We are going to need your information first! What is your name? ");
        string userName = Console.ReadLine();
        Console.WriteLine();
        Console.Write("What is your age? ");
        int userAge = int.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
        string seeList = Console.ReadLine();
        if (seeList == "sure")
        {

        foreach (string activity in activities)
        {
            Console.Write($"{activity} ");
            Thread.Sleep(250);
        }
        Console.WriteLine();
       
            string userInput;
            bool addToList = false;
            try
            {
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                userInput = Console.ReadLine();
               

                if (userInput.ToLower() == "yes")
                {
                    addToList = true;
                }
                else if(userInput== "no")
                {
                    addToList = false;
                    Console.WriteLine("That was it. Thank you!"); 
                }
                else if (userInput == null)
                {
                    Thread.Sleep(1000);
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                // Optionally, you can handle the null input here or re-throw the exception
            }

            Console.WriteLine();
        while (Console.ReadLine().ToLower() == "yes")
        {
            Console.Write("What would you like to add? ");
            string userAddition = Console.ReadLine();
            activities.Add(userAddition);
            foreach (string activity in activities)
            {
                Console.Write($"{activity} ");
                Thread.Sleep(250);
            }
            Console.WriteLine();
            Console.WriteLine("Would you like to add more? yes/no: ");

            if (Console.ReadLine().ToLower() == "yes")
                {
                    addToList = true;
                }
                else 
                {
                    addToList = false;
                }
        }
    }

        while (cont == true)
        {

            try
            {
                Console.Write("Connecting to the database");
              
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to the database: " + ex.Message);
                // Optionally add a delay before retrying
                Thread.Sleep(1000); 
                // Adjust the sleep time based on your needs
            }
          

            Console.WriteLine("Choosing your random activity");
          
            Console.WriteLine();
            int randomNumber = rng.Next(activities.Count);
            string randomActivity = activities[randomNumber];

            if (userAge < 21 && randomActivity == "Wine Tasting")
            {
                Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                Console.WriteLine("Pick something else!");
                activities.Remove(randomActivity);
                randomNumber = rng.Next(activities.Count);
                randomActivity = activities[randomNumber];
            }
            else
            {
                Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
            }
           
            if (Console.ReadLine().ToLower() == "redo")
            {
                cont = true;
            }
            else
            {
                cont = false;
            }

            Console.WriteLine();
        }
}
    
}



