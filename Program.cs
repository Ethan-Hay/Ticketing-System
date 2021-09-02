using System;
using System.IO;
using System.Collections.Generic;
namespace Ticketing_System
{class Program
    {
        static void Main(string[] args)
        {
           
        // User ask loops.
        string choice;
        string file = "Tickets.csv";

        do 
        {
            Questions();
            choice = Console.ReadLine();
            // Create ticket.
            if(choice == "1")
            {
                NewTicket();
            }
            // Read tickets.
            else if (choice == "2")
            {
                StreamReader streamread = new StreamReader(file);
                Console.WriteLine("TicketID,Summary,Status,Priority,Submitter,Assigned,Watching");
                Console.WriteLine("");
                while (!streamread.EndOfStream)
                {
                    string line = streamread.ReadLine();
                    Console.WriteLine(line);
                }
            }
            // Exit program.
            else
            {
                Console.WriteLine("Closing program...");
            }
        }

        while (choice == "1" || choice == "2");

        }

        //Main questions to ask the user 
        static void Questions()
        {
            Console.WriteLine("Would you like to create a new ticket? (1)");
            Console.WriteLine("Would you like to see all of the tickets? (2)");
            Console.WriteLine("Use any other key to exit.");
        }
        
        //Creating new tickets
        static void NewTicket()
        {
            string file = "Tickets.csv";
            int ticketId = 0;
            StreamWriter sw = new StreamWriter(file);

            for (var i = 0; i < 10; i++)
            {
                ticketId++;

                Console.WriteLine("Enter a ticket summary: ");
                string summary = Console.ReadLine();

                Console.WriteLine("Choose status: 1. Open | 2.Closed");
                string status = Console.ReadLine(); 
                switch (status)
                {
                    case "1":
                        status = "Open";
                        break;
                    case "2":
                        status = "Closed";
                        break;
                }

                Console.WriteLine("Choose priority: 1. Low | 2. Medium | 3. High");
                string priority = Console.ReadLine(); 
                switch (priority)
                {
                    case "1":
                        priority = "Low";
                        break;
                    case "2":
                        priority = "Medium";
                        break;
                    case "3":
                        priority = "High";
                        break;
                }

                Console.WriteLine("Submitter: ");
                string submitter = Console.ReadLine();   

                Console.WriteLine("Assigned: ");
                string assigned = Console.ReadLine();    

                var watchers = new List<string>();
                string watcher;
                string option;

                do
                {
                Console.WriteLine("Watch by: ");
                watcher = Console.ReadLine();
                watchers.Add(watcher);

                Console.WriteLine("Do you want to add a Watcher: (Y/N)");
                option = Console.ReadLine().ToUpper();
                
                } while (option == "Y");
                
                string watchedBy =  string.Join("|", watchers); 

                sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}", ticketId, summary, status, priority , submitter ,assigned, watchedBy);

                Console.WriteLine("Would you like to enter a new ticket (Y/N)?");
                string response = Console.ReadLine().ToUpper();
                if (response != "Y") { break; }
            }
            sw.Close();

        }

    }
}

