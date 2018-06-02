using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Fractional_Knapsack_Problem
{
    class Program
    {
        static SortedDictionary<double, double[]> items = new SortedDictionary<double, double[]>();
        static double currentCapacity = 0;
        static void Main(string[] args)
        {
            var capacity = int.Parse(Console.ReadLine().Split(' ')[1]);
            var itemsToChoose = int.Parse(Console.ReadLine().Split(' ')[1]);

            for (int i = 0; i < itemsToChoose; i++)
            {
                var itemsArgs = Console.ReadLine().Split(' ').ToArray();
                var price =  double.Parse(itemsArgs[0]);
                var weight = double.Parse(itemsArgs[2]);
                var insertion = price / weight*1000;
                if (!items.ContainsKey(insertion))
                {
                    items.Add(insertion, new double[] { price, weight });
                }

            }

            PackTheBag(capacity);
        }

        private static void PackTheBag(int capacity)
        {
            double totalPrice = 0.0;
            foreach (var item in items.Reverse())
            {
                var price = item.Value[0];
                var currentItemWeiht = item.Value[1];
                if (currentCapacity == capacity)
                {
                    Console.WriteLine($"Take 100% of item with price {price:f2} and weight {currentItemWeiht:f2}");
                    Console.WriteLine($"Total price: {totalPrice:f2}");
                    return;
                }
                if (currentCapacity + currentItemWeiht > capacity)
                {
                    double itemToGet = capacity - currentCapacity;
                    double temp = itemToGet / currentItemWeiht;
                    var percentage = temp * 100;
                    currentCapacity += itemToGet;
                    totalPrice += (price * temp);
                    Console.WriteLine($"Take {percentage:f2}% of item with price {price:f2} and weight {currentItemWeiht:f2}");
                    Console.WriteLine($"Total price: {totalPrice:f2}");
                    return;
                }
                if (items.Count == 1)
                {
                    currentCapacity += currentItemWeiht;
                    totalPrice += price;
                    Console.WriteLine($"Take 100% of item with price {price:f2} and weight {currentItemWeiht:f2}");
                    Console.WriteLine($"Total price: {totalPrice:f2}");
                    return;
                }
                currentCapacity += currentItemWeiht;
                Console.WriteLine($"Take 100% of item with price {price:f2} and weight {currentItemWeiht:f2}");
                totalPrice += price;

            }
        }
    }
}
