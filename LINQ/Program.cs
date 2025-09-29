using LINQ.Entities;
using LINQ.Services;
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

        ShowList(prod);

        prod.RemoveAll(p => p.Price >= 100);

        ShowList(prod);

    }

    public static void ShowList(List<Product> p)
    {
        foreach (var item in p)
        {
            Console.WriteLine($"{item.Name}: {item.Price}");
        }
    }
}


