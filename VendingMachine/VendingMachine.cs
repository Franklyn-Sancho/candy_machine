using System;
using System.Collections.Generic;
using System.Linq;

public interface ICoin
{
    string Name { get; }
    decimal Value { get; }
};

public interface IProduct
{
    string Name { get; }
    decimal Price { get; }
};

public class VendingMachine
{


    private decimal totalCoins = 0;
    private List<ICoin> coins;
    private List<IProduct> products;

    public VendingMachine(List<ICoin> coins, List<IProduct> products)
    {
        this.coins = coins;
        this.products = products;
    }

    public bool IsCoin(string value)
    {
        decimal coin = decimal.Parse(value);

        return this.coins.Any(val => val.Value == coin);
    }

    public void AddCoins(string value)
    {
        Console.WriteLine("Aceitamos moedas de: 0.01, 0.05, 0.10, 0.50 and 1.00");

        decimal coin = decimal.Parse(value);

        if (this.IsCoin(value))
        {
            this.totalCoins += coin;
            Console.WriteLine($"Você inseriu {value} e seu saldo é {this.totalCoins}");
        }
        else
        {
            Console.WriteLine("Verifique o valor inserido");
            return;
        }
    }

    public bool IsProduct(string product)
    {
        return this.products.Any(val => val.Name == product);
    }

    public void BuyProduct(string product)
    {
        IProduct item = this.products.FirstOrDefault(
            val => val.Name == product && val.Price <= this.totalCoins
        );

        if (item != null)
        {
            decimal charge = this.totalCoins - item.Price;
            this.totalCoins = charge;
            Console.WriteLine($"Obrigado pela preferência, seu troco é: {charge}");
        }
        else
        {
            Console.WriteLine("Produto inexistente/dinheiro insuficiente");
        }
    }
}
