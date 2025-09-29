using LINQ.Entities;
using LINQ.Services;
using System.Linq;

namespace LINQ;

class Program
{
    static void Main(string[] args)
    {
        List<Product> prod = new();

        prod.Add(new Product("TV", 900.00));
        prod.Add(new Product("Carro", 100.00));
        prod.Add(new Product("Arroz", 40.00));
        prod.Add(new Product("Tablet", 350.00));
        prod.Add(new Product("HD Case", 90.00));
        Console.WriteLine("Normal List!");
        ShowList(prod);
        Console.WriteLine();

        Func<Product, string> func = NameUpper;

        List<string> result = prod.Select(func).ToList();

        Console.WriteLine("Update List!");
        ShowList(prod);

    }

    static string NameUpper(Product p)
    {
        return p.Name.ToUpper();
    }

    static void ShowList(List<Product> p)
    {
        foreach (var item in p)
        {
            Console.WriteLine(item);
        }
    }
}


