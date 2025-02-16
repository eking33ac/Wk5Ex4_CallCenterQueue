using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wk5Ex4_CallCenterQueue
{
    internal class Program
    {
        // Method to validate string input
        static string HandleStringInput(string aPrompt = "Write your sentence/string: ", string anErrorMessage = "Something went wrong on our end. Please enter a valid string input.\n")
        {
            // initialize return value
            string returnValue = "";


            // processing


            // start of a do while loop
            do
            {
                // A try catch to ensure the user input is valid
                try
                {
                    // Ask user to input a string
                    Console.Write(aPrompt);
                    // Collect input from user and store it in the returnValue
                    returnValue = (Console.ReadLine());
                }
                // if that doesn't work, output an error message
                catch (Exception e)
                {
                    // output an error message
                    Console.WriteLine(anErrorMessage);
                }
            }
            // loop until returnValue has a different value
            while (returnValue == "");


            // return returnValue
            return returnValue;
        }

        // Method to handle integer input
        static int HandleIntInput(string aPrompt, string anErrorMessage = "Your input is invalid. Please enter a whole number.\n")
        {
            // initialize return value
            int returnValue = Int32.MaxValue;


            // processing


            // start of a do while loop
            do
            {
                // A try catch to ensure the user input is valid
                try
                {
                    // Ask user to input a number
                    Console.Write(aPrompt);
                    // Convert user input to a double, collect input from user and store it in the returnValue
                    returnValue = Convert.ToInt32(Console.ReadLine());
                }
                // if that doesn't work, output an error message
                catch (Exception e)
                {
                    // output an error message
                    Console.WriteLine("\n" + anErrorMessage);
                }
            }
            // loop until returnValue has a different value


            while (returnValue == Int32.MaxValue);


            // return returnValue
            return returnValue;
        }

        // a method to check if an integer input is between two numbers
        static int CheckIntRange(int input, int min, int max, int evaluationValue = Int32.MinValue, string errorMessage = "Your input was out of range. Input again.\n")
        {
            // initialize return value to the input
            int returnValue = input;

            // processing


            // check if the input is grater than a max value OR less than a min value
            if (input > max || input < min)
            {
                // return an error message
                Console.WriteLine(errorMessage);
                // make evaluation variable reset
                returnValue = evaluationValue;
            }


            // return returnValue
            return returnValue;
        }


        // Method to add a customer to the queue
        static void AddCustomer(Queue<string> customerQueue)
        {
            // variable declarations
            string newCustomer = ""; // string variable containing new page a user inputs, initialized to blank

            // validate string input from user and store it in the newPage variable
            newCustomer = HandleStringInput("Enter customer name: ");
            // linebreak for readability
            Console.Write("\n");


            // add the new customer to the queue
            customerQueue.Enqueue(newCustomer);

            // Tell the user the customer was added to the queue
            Console.WriteLine($"Customer {newCustomer} added to the queue.");

            // Tell user they have visited the page!
            Console.WriteLine($"\n");
        }


        // Method to serve/remove the next customer in the queue
        static void ServeCustomer(Queue<string> customerQueue)
        {
            // variable declarations
            string customerBeingServed = ""; // string variable containing new page a user inputs, initialized to blank

            // check if there are 0 or fewer customers in the queue
            if (customerQueue.Count <= 0)
            {
                // tell the user the queue is empty and nothing happened
                Console.WriteLine("There are no customers in the queue, so nothing happened.");
            }
            // if there ARE customers in the queue
            else
            {
                // tell the user who they are servicing
                Console.WriteLine($"Serving customer: {customerQueue.Peek()}");

                // add the new customer to the queue
                customerQueue.Dequeue();
            }
            

            // linebreak for readability
            Console.WriteLine($"\n");
        }


        // method to see all customers in the queue
        static void ViewQueue(Queue<string> customerQueue)
        {
            // display queue title
            Console.WriteLine("Queue Remaining:");


            // check if there are 0 customers in the queue
            if (customerQueue.Count == 0)
            {
                // output empty
                Console.WriteLine("[Empty]\n");
            }
            // check if the queue is in the negatives
            else if (customerQueue.Count < 0)
            {
                // output a warning message
                Console.WriteLine("WARNING\nThe queue is somehow negative.\nLook at your history to see what went wrong or exit the app and restart.");
            }
            // if there are customers in the queue
            else
            {
                // for every customer in the queue
                foreach (string customer in customerQueue)
                {
                    // output the customer name
                    Console.WriteLine(customer);
                }
            }

            // line break for ease of reading
            Console.Write("\n");
        }


        static void Main(string[] args)
        {
            // Objective: Make a queue for a call center
            /* Options to select from: Add a customer, serve next customer(remove from queue),
             * view queue, exit. */


            // processing 


            // Declarations
            Queue<string> waitingCustomers = new Queue<string>();       // declaration for a queue which will hold the names of waiting customers
            int menuSelection = Int32.MinValue;      // int variable containing the user's option selection from the menu, initialized to min int value


            // output the options to the user with their number


            // Output to tell the user they can type 1 to add a customer
            Console.WriteLine("1. Add Customer\n");

            // Output to tell the user they can type 2 to serve the next customer
            Console.WriteLine("2. Serve Customer\n");

            // Output to tell the user they can type 3 to view the queue
            Console.WriteLine("3. View Queue\n");

            // Output to tell the user they can type 4 to exit the application
            Console.WriteLine("4. Exit\n");



            // A do while loop to run the program and allow continuous choice.
            do
            {
                // do while loop to make sure the user selection is within range
                do
                {
                    // ask for and recieve user choice as an integer number
                    menuSelection = HandleIntInput("Enter your choice: ");
                    // line break for readability
                    Console.Write("\n");

                    // make sure the integer input is between 1 and 4. If interger is not, reset user selection to Int32 min value
                    menuSelection = CheckIntRange(menuSelection, 1, 4, Int32.MinValue, "Your input was out of range. Make sure your number is between 1 and 4.\n");
                }
                while (menuSelection == Int32.MinValue);


                // check if the user selection is 4, leave the while loop
                if (menuSelection == 4)
                {
                    // leave the while loop
                    break;
                }


                // use a switch case to perform an operation based on the selection
                switch (menuSelection)
                {
                    // Run this case if selection = 1
                    case 1:
                        // Visit new web page
                        AddCustomer(waitingCustomers);


                        // Jump out of switch here.
                        break;


                    // Run this case if selection = 2
                    case 2:
                        // return to previous page
                        ServeCustomer(waitingCustomers);


                        // Jump out of switch here.
                        break;


                    // Run this case if selection = 3
                    case 3:
                        // View the customers still in the queue
                        ViewQueue(waitingCustomers);


                        // Jump out of switch here.
                        break;


                    default:
                        // Output a polite message in case of unforseen error.
                        Console.WriteLine("It seems something went wrong on our end. Please try again./n");

                        // Jump out of switch here.
                        break;
                }

                // prompt user to continue the loop
                Console.WriteLine("Select what you would like to do next or press 4 to exit.");


                // reset the evaluation variable
                menuSelection = Int32.MinValue;
            }
            while (menuSelection == Int32.MinValue);


            // Thank user for using the program
            Console.WriteLine("Thank you for using this program! Come again!");


            // Pause at the end of program for user to read
            Console.Read();
        }
    }
}
