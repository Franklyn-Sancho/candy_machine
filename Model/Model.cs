using System.Collections.Generic;

public class Coin : ICoin
{
    public string Name { get; }
    public decimal Value { get; }

    public Coin(string name, decimal value)
    {
        this.Name = name;
        this.Value = value;
    }
}

public class Product : IProduct
{
    public string Name { get; }
    public decimal Price { get; }

    public Product(string name, decimal price)
    {
        this.Name = name;
        this.Price = price;
    }

}

public static class Model
{
    public static List<ICoin> coins = new List<ICoin>
    {
        new Coin("5¢", 0.05m),
        new Coin("10¢", 0.1m),
        new Coin("25¢", 0.25m),
        new Coin("50¢", 0.5m),
        new Coin("$1", 1.0m),
    };

    public static List<IProduct> products = new List<IProduct> {
        new Product("chocolate", 2.0m),
        new Product("biscoito", 1.5m),
        new Product("pipoca", 5.0m),
    };
}
