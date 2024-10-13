using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Initialize the dictionary to store fruits and their prices
        var fruits = new Dictionary<string, decimal>(); //Key-string = name of fruit, Value-decimal = price of fruit

        // Loop to get fruits and prices
        while (true)
        {
            Console.Write("Enter a fruit (or 'done' to finish): ");
            string? fruit = Console.ReadLine() ?? ""; // Handle possible null

            // Check if the user wants to stop entering fruits
            if (fruit.ToLower() == "done")
            {
                break;
            }

            // Check if the fruit is already in the dictionary
            if (fruits.ContainsKey(fruit))
            {
                Console.WriteLine("That fruit is already in the dictionary. Please enter a different fruit.");
                continue;
            }

            // Get and validate the price input
            decimal price;
            while (true)
            {
                Console.Write($"Enter the price for {fruit}: ");
                string? priceInput = Console.ReadLine() ?? ""; // Handle possible null

                // Validate the price is a decimal and non-negative
                if (decimal.TryParse(priceInput, out price) && price >= 0)
                {
                    break; // Valid price, exit loop
                }
                else
                {
                    Console.WriteLine("Invalid price. Please enter a valid decimal number greater than or equal to 0.");
                }
            }

            // Add the fruit and price to the dictionary
            fruits[fruit] = price;
        }

        // Check if any fruits were entered
        if (fruits.Count == 0)
        {
            Console.WriteLine("No fruits were entered.");
            return;
        }

        // Sort the fruits by price and display them
        Console.WriteLine("\nFruits and their prices, sorted by price (cheapest first):");

        foreach (var fruit in fruits.OrderBy(f => f.Value)) // Sort by value (price)
        {
            Console.WriteLine($"{fruit.Key}: ${fruit.Value:F2}");
        }
    }
}
