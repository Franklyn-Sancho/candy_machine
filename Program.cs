using System;
using System.Collections.Generic;
using static Model;
using static VendingMachine;

public class Program
{
    public static void Main()
    {


        var vendingMachine = new VendingMachine(coins, products);

        string option;
        do
        {
            Console.Write("Insert coins or buy products: ");
            option = Console.ReadLine();
            option = option.ToLower();
            if (vendingMachine.IsCoin(option))
            {
                vendingMachine.AddCoins(option);
            }
            if (vendingMachine.IsProduct(option))
            {
                vendingMachine.BuyProduct(option);
            }
        } while (!vendingMachine.IsProduct(option));
    }
}