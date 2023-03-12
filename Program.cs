using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Inserting 6 numbers from user
            int[] userNumbers = new int[6];
            int inputNumber = 0;
            Console.WriteLine($"Welcome in winning lotery. Write 6 different numbers between 1 to 49.");

            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"Input number {i + 1}:");
                while ((!int.TryParse(Console.ReadLine(), out inputNumber)) || (inputNumber < 0) || (inputNumber > 49) || (userNumbers.Contains(inputNumber)))
                {
                    Console.WriteLine($"Wrong input. Try it again.");
                }
                userNumbers[i] = inputNumber;

            }

            // Output user numbers
            Console.WriteLine("User numbers are: ");
            for (int i = 0; i < userNumbers.Length; i++)
            {
                Console.Write(userNumbers[i]);
                Console.Write(" ");
            }

            // Generate 7 random numbers
            Random random = new Random();
            int[] wonNumbers = new int[7];
            int generateNumber = 0;
            for (int i = 0; i < wonNumbers.Length; i++)
            {
                generateNumber = random.Next(1, 50);

                // Check of doubles
                while (wonNumbers.Contains(generateNumber))
                {
                    generateNumber = random.Next(1, 50);
                }

                wonNumbers[i] = generateNumber;
            }
            //// Test win check
            //userNumbers[0] = wonNumbers[0];
            //userNumbers[1] = wonNumbers[1];
            //userNumbers[2] = wonNumbers[2];

            // Output lotery numbers
            Console.WriteLine("\nLotery numbers are: ");
            for (int i = 0; i < wonNumbers.Length; i++)
            {
                Console.Write(wonNumbers[i]);
                Console.Write(" ");
            }


            // Winning check
            int countOfWin = 0;
            for (int i = 0; i < 6; i++)
            {
                if (wonNumbers.Contains(userNumbers[i]))
                {
                    countOfWin++;
                }
            }

            // Output win
            if (countOfWin >= 3)
            {
                Console.WriteLine($"\nYou won!! You guessed {countOfWin} numbers.");
            }
            else 
            {
                Console.WriteLine($"\nYou loose. You guessed only {countOfWin} numbers.");
            }

            Console.ReadLine();

        }
    }
}
