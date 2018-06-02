
using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfCoins
{
    public static void Main(string[] args)
    {
        var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
        var targetSum = 923;

        var selectedCoins = ChooseCoins(availableCoins, targetSum);

        Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
        foreach (var selectedCoin in selectedCoins)
        {
            Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
        }
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        var result = new Dictionary<int, int>();

        coins = coins.OrderByDescending(x => x).ToList();

        var coinIndex = 0;
        var currentSum = 0;

        while (coinIndex < coins.Count && currentSum != targetSum)
        {
            var currentCointValue = coins[coinIndex];

            if (currentSum + currentCointValue > targetSum)
            {
                coinIndex++;
                continue;
            }
            var remainingSum = targetSum - currentSum;
            var coinsToTake = remainingSum / currentCointValue;

            if (coinsToTake > 0)
            {
                result[currentCointValue] = coinsToTake;
                currentSum += coinsToTake * currentCointValue;
            }

        }
        if (targetSum != currentSum)
        {
            throw new InvalidOperationException();
        }
        return result;
    }
}