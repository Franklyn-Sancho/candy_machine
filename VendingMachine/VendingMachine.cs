using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

    private const string ACCEPTED_COINS = "Aceitamos moedas de: 0.01, 0.05, 0.10, 0.50 and 1.00";
    private const string CHECK_VALUE = "\nVerifique o valor inserido";
    private const string THANKS = "Obrigado pela preferência, seu troco é: ";
    private const string ERROR = "Produto inexistente/dinheiro insuficiente";

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
        bool sucesso = decimal.TryParse(value, out decimal coin);

        if (sucesso)
        {
            return this.coins.Any(val => val.Value == coin);
        }

        return false;
    }

    public void AddCoins(string value)
    {
        StringBuilder message = new StringBuilder();
        message.Append(ACCEPTED_COINS);

        decimal coin = decimal.Parse(value);

        if (!this.IsCoin(value))
        {
            message.Append(CHECK_VALUE);
            Console.WriteLine(message);
            return;
        }

        this.totalCoins += coin;
        message.Append($"\nVocê inseriu {value} e seu saldo é de {this.totalCoins}");
        Console.WriteLine(message);
    }

    public bool IsProduct(string product)
    {
        return this.products.Any(val => val.Name == product);
    }

    public void BuyProduct(string product)
    {
        IProduct item = this.products.FirstOrDefault(
            val => val.Name == product);

        item ??= new Product("Sem produto", 0);


        if (item != null && totalCoins >= item.Price)
        {
            decimal charge = this.totalCoins - item.Price;
            Console.WriteLine($"{THANKS} {charge}");
            totalCoins -= item.Price;
            return;

        }

        Console.WriteLine("Produto inexistente/dinheiro insuficiente");
        return;


    }
}
