/**
 * ITC366-899 HW 3
 * 
 * author
 * Matthew Taylor
 *
 * SOURCE LINK
 * 
 * VIDEO LINK
 *  
 */

//package declarations
using System;
using System.IO;
using System.Text;


namespace Homework_Template
{
    class HomeworkAssignment
    {
        //// DECLARE ANY ENUM's HERE 
        ///BETWEEN CLASS DECLARATION & MAIN METHOD ////

        public enum Vowels { a = 1, e, i, o, u }

        //Main method
        public static void Main(string[] args)
        {
            //Headers and Instructions strings
            String headerBar = new string('*', 40);
            String header = "\n  -  ITC366-899 Homework  -\nMatthew Taylor\nmatt271@live.missouristate.edu\n";
            String instructions = "Enter the number from one the following to run the corresponding exercise code: \n";
            String exerciseList = ": Exercise ";

            //Main method control variable declaration and initialization
            Boolean continueStatus = true; //initialize and set loop control boolean
            int length = 5; //sets number of exercises
            char exerciseSelection, continueChoice; //character variables to hold exercise selection


            Console.WriteLine(headerBar + header + headerBar);


            //Console.Write("Enter your name: ");
            //String enteredName = Console.ReadLine(); 

            /*
            * While loop runs as long as users choose to continue program
            * 
            * Improvement notes: implement break and continue statements
            */

            while (continueStatus == true)
            {

                ///// Write Program Instructions /////
                Console.WriteLine(instructions);


                //loop through exercises and display menu
                for (int loopIndex = 1; loopIndex <= length; loopIndex++)
                {
                    Console.WriteLine(loopIndex + exerciseList + loopIndex);

                }//end menu text for loop

                //prompt for and retrieve exercise selection
                Console.WriteLine("Enter exercise selection: ");
                exerciseSelection = (char)Console.Read();
                ClearKeys();


                switch (exerciseSelection)
                {
                    case '1':
                        Exercise1();
                        break; // end case 1

                    case '2':
                        Exercise2();
                        break;
                    case '3':
                        Exercise3();
                        break;
                    case '4':
                        Exercise4();
                        break; //end case 4

                    case '5':
                        Exercise5();
                        break; //end case 5
                    default:
                        Console.WriteLine("Invalid input.");
                        break;

                }  // switch on exerciseSelection to launch exercise methods

                ///// Continue program section /////
                Console.WriteLine("Continue (y/n)?");
                continueChoice = (char)Console.Read();
                ClearKeys();

                // conditionals to determine whether to exit while loop
                // improve with continue statement?
                if (continueChoice == 'y')
                {
                    continueStatus = true;
                    Console.WriteLine("Choose another exercise.\n");

                }//end if

                else
                {
                    continueStatus = false;
                    Console.WriteLine("Thank you for using this application.\n");
                }//end else

            }//end program continuation while loop
            Console.WriteLine("\nEnd Program");
        }//end main method

        
        public static void ClearKeys()
        {
            while (Console.In.Peek() != -1)
                Console.In.Read();
        } // ClearKeys method code located through research to ensure that characters are read correctly

        /**
         * Exercise 1
         * 
         * User enters a character. Test whether character is upper case.
         */

        public static void Exercise1()
        {
            // String initialization
            String msg1 = "Enter an uppercase letter ";
            String msg2 = "Sorry, that was not an uppercase letter.";
            String msg3 = "or ! to quit ";

            // OUTPUT SECTION //

            //Exercise Header
            Console.WriteLine("*", 40);
            Console.WriteLine("     - Character Case Checker -     ");
            Console.WriteLine("*", 40);

            //Instructions
            Console.WriteLine(msg1 + ">> ");

            char entry = (char)Console.Read();
            ClearKeys();

            // determine whether entry is upper case and determine outcome
            bool entryStatus = Char.IsUpper(entry);
            //debug entry status
            Console.WriteLine("entryStatus (TRUE == uppercase / FALSE == lowercase " + entryStatus);


            if (entryStatus == true)
            {
                Console.WriteLine("OK.");
            } //valid entry case
            else {
                do
                {
                    Console.WriteLine(msg2);
                    Console.WriteLine(msg1 + msg3);
                    entry = (char)Console.Read();
                    ClearKeys();

                    entryStatus = Char.IsUpper(entry);

                    //debug
                    Console.WriteLine("entryStatus " + entryStatus);
                    Console.WriteLine("entry char: " + entry);

                    if (entry == '!')
                    {
                        Console.WriteLine("entry = !, exit do while loop");
                        break;
                    }

                } while (entryStatus == false);
            } //invalid 1st entry case

            Console.WriteLine("\n - goodbye -");
            //debug
            /**
            Console.WriteLine("entry: " + entry);
            Console.WriteLine("entryStatus: " + entryStatus);
            */

        } //end Exercise1 method

        /**
         * Exercise 2
         * Obtain an input string from the user and count the number of vowels.
         * 
         */

        public static void Exercise2()
        {
            //Exercise Header
            Console.WriteLine("*", 40);
            Console.WriteLine("     - Vowel Counter -     ");
            Console.WriteLine("*", 40);

            String instruction = "Enter a message: ";
            Console.WriteLine(instruction);
            String inputMessage = Console.ReadLine();
            Console.WriteLine("\ninputMessage = ");
            inputMessage = inputMessage.Trim();

            //create character array to interate through and test whether its a vowel
            char[] messageChars = inputMessage.ToCharArray();

            //initialize control variables
            Vowels vowelCheck;
            String testStr;
            bool isVowel;
            int vowelCount = 0, counter = 0;

            foreach (char messageChar in messageChars)
            {
                testStr = messageChars[counter].ToString();
                counter++;
                //testVowel = (Vowels)testStr;

                // had to do some checking on the TryParse method, got a leg up from
                // https://docs.microsoft.com/en-us/dotnet/api/system.enum.tryparse?view=net-5.0
                //This also appears to work for upper and lower case, but I'm not entirely sure why

                isVowel = Enum.TryParse(testStr, true, out vowelCheck);

                if (isVowel == true)
                {
                    vowelCount++;
                } //increment vowelCount if true

                /**
                //foreach debug
                Console.WriteLine("foreach debug");
                Console.WriteLine("test string: " + testStr);
                Console.WriteLine("isVowel: " + isVowel);
                Console.WriteLine("*", 30);
                Console.WriteLine("vowelCount: " + vowelCount);
                */ //foreach debug section
            } //iterate through all characters in the string, test if it is a vowel, and increment the vowel counter

            Console.WriteLine($"There are {vowelCount} vowels in " + $"\"{inputMessage}\"");

        } // end Exercise2 method

        /**
         * Exercise 3 
         * Sums integers 1 through 200
         * 
         **/

        public static void Exercise3()
        {
            // Exercise Header
            Console.WriteLine("*", 40);
            Console.WriteLine("     - Integer Summer -     ");
            Console.WriteLine("*", 40);

            int partialSum = 0;
            int length = 200;

            // formula method
            /**
            int halfSum = (100 * 101) / 2;
            int sum = (200 * 201) / 2;
            Console.WriteLine($"halfSum = {halfSum}\n sum = {sum}");
            */

            //loop method
            for (int index = 1; index <= length; index++)
            {
                partialSum = partialSum + index;

                if (index == 100)
                {
                    Console.WriteLine("Halfway there...");
                } //Display halfway message
            }
            Console.WriteLine($"The sum of the first {length} integers is {partialSum}");

        } //end Exercise3 method

        /**
         * Exercise 4
         * Debug given code
         */
        public static void Exercise4()
        {
            const string ITEM209 = "209";
            const string ITEM312 = "312";
            const string ITEM414 = "414";
            const double PRICE209 = 12.99, PRICE312 = 16.77, PRICE414 = 109.07;
            double price = 0; //must be preset because it is being set within the switch function
            string stockNum;

            /**
             * debug
             *
            //Console.WriteLine($"PRICE209 = {PRICE209}\nPRICE312 = {PRICE312}\nPRICE414 = {PRICE414}" );
            //Console.WriteLine($"ITEM209 = {ITEM209}\nITEM312 = {ITEM312}\nITEM414 = {ITEM414}");
            */

            bool continueStatus = false;
            do
            {
                Console.Write("Please enter the stock number of the item you want ");
                stockNum = Console.ReadLine(); //missing Console.

                /**
                 * Change while loop with multiple or conditions that will yield false negatives
                 * to a switch statement that catches the three valid input conditions and repeats on 
                 * all other inputs
                 * 
                */

                switch (stockNum)
                {
                    case ITEM209:
                        price = PRICE209;
                        break;
                    case ITEM312:
                        price = PRICE312;
                        break;
                    case ITEM414:
                        price = PRICE414;
                        break;
                    default:
                        Console.WriteLine("Invalid stock number. Please enter again. ");
                        continueStatus = true;
                        break;
                }  //switch on stockNum through valid inputs
            } while (continueStatus == true); 

            /**
            while (stockNum != ITEM209 || stockNum != ITEM312 || stockNum != ITEM414)
            {
                Console.WriteLine("Invalid stock number. Please enter again. ");
                stockNum = Console.ReadLine(); // missing period
                Console.WriteLine($"stockNum: {stockNum}");

            }
            
            if (stockNum == ITEM209)
                price = PRICE209;
            else
               if (stockNum == ITEM312)
                price = PRICE414; //wrong constant
            else
                price = PRICE312;
            */

            Console.WriteLine("The price for item # {0} is {1}", stockNum, (double)price); //not sure where the C comes from here


        } // end Exercise 4 method

        /**
         * Exercise 5
         * Debug Code
         */
        public static void Exercise5()
        {
            const double LIMIT = 1000000.00;
            const double START = 0.01;
            string inputString;
            double total;
            int howMany;
            int count;
            Console.Write("How many days do you think ");
            Console.WriteLine("it will take you to reach");
            Console.Write("{0} starting with {1} ", LIMIT.ToString("C"), START.ToString("C")); //line break causing problem, problems with braces
            Console.WriteLine("and doubling it every day?");
            inputString = Console.ReadLine(); //missing Console.
            howMany = Convert.ToInt32(inputString);
            count = 0;
            total = START;
            while (total <= LIMIT) // should use less than or equal to
            {
                total = total * 2;
                count = count + 1;
            }
            
            if (howMany >= count)
                Console.WriteLine("Your guess was too high.");
            else if (howMany <= count) // less than or equal to in wrong order, line break in weird place
                Console.WriteLine("Your guess was too low.");
            else
                Console.WriteLine("Your guess was correct.");

            Console.WriteLine("It takes {0} days to reach {1}", count, LIMIT.ToString("C")); //missing braces around first placeholder string marker
            Console.WriteLine("when you double {0} every day ", START.ToString("C")); 

        } // end Exercise5 method

    } //end HomeworkAssignment class

} //end namespace
