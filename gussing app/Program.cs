using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gussing_app
{
    class Program
    {

        class GuessingApp
        {
            static void Main()
            {
                Console.WriteLine("Welcome to the Guessing Game!");

                while (true)
                {
                    Console.WriteLine("Choose a difficulty level:");
                    Console.WriteLine("1. Easy");
                    Console.WriteLine("2. Medium");
                    Console.WriteLine("3. Hard");
                    Console.WriteLine("4. Quit");

                    int choice = GetChoice(1, 4);

                    if (choice == 4)
                    {
                        Console.WriteLine("Goodbye!");
                        break;
                    }

                    int maxNumber;
                    int maxAttempts;

                    if (choice == 1)
                    {
                        maxNumber = 10;
                        maxAttempts = 3;
                    }
                    else if (choice == 2)
                    {
                        maxNumber = 50;
                        maxAttempts = 5;
                    }
                    else
                    {
                        maxNumber = 100;
                        maxAttempts = 7;
                    }

                    PlayGame(maxNumber, maxAttempts);
                }
            }

            static int GetChoice(int minValue, int maxValue)
            {
                int choice;
                while (true)
                {
                    Console.Write("Enter your choice: ");
                    if (int.TryParse(Console.ReadLine(), out choice) && choice >= minValue && choice <= maxValue)
                        return choice;
                    else
                        Console.WriteLine("Invalid choice. Please try again.");
                }
            }

            static void PlayGame(int maxNumber, int maxAttempts)
            {
                Random random = new Random();
                int targetNumber = random.Next(1, maxNumber + 1);
                int attempts = 0;

                Console.WriteLine($"I'm thinking of a number between 1 and {maxNumber}.");

                while (attempts < maxAttempts)
                {
                    Console.Write("Enter your guess: ");
                    int guess = GetGuess(1, maxNumber);

                    attempts++;

                    if (guess == targetNumber)
                    {
                        Console.WriteLine("Congratulations! You guessed the correct number.");
                        Console.WriteLine($"It took you {attempts} attempt(s) to guess the number.");
                        return;
                    }
                    else if (guess < targetNumber)
                    {
                        Console.WriteLine("Too low!");
                    }
                    else
                    {
                        Console.WriteLine("Too high!");
                    }
                }

                Console.WriteLine("Game over! You ran out of attempts.");
                Console.WriteLine($"The correct number was {targetNumber}.");
            }

            static int GetGuess(int minValue, int maxValue)
            {
                int guess;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out guess) && guess >= minValue && guess <= maxValue)
                        return guess;
                    else
                        Console.WriteLine($"Invalid guess. Enter a number between {minValue} and {maxValue}.");
                }
            }
        }
    }
}
