
using System.Linq;
using LINQ.Entities;
using LINQ.Entities.Enums;

namespace LINQ;

class Program
{
    static void Main(string[] args)
    {
        Category c1 = new(1, "Tools", Tier.MediumQuality);
        Category c2 = new(2, "Eletronics", Tier.HighQuality);
        Category c3 = new(3, "Toys", Tier.LowQuality);
        Category c4 = new(4, "Pets", Tier.MediumQuality);
        Category c5 = new(5, "Sport", Tier.HighQuality);

        List<Product> products = new();
        products.Add(new Product(1, "Smart TV 55\"", 4899.90, c2));
        products.Add(new Product(2, "Drill 1000W", 349.50, c1));
        products.Add(new Product(3, "Puzzle Blocks 50pcs", 45.00, c3));
        products.Add(new Product(4, "Premium Dog Food 15kg", 185.99, c4));
        products.Add(new Product(5, "Professional Running Shoes", 879.00, c5));
        products.Add(new Product(6, "Noise-Cancelling Headphones", 1299.00, c2));
        products.Add(new Product(7, "Water Gun Small", 25.50, c3));
        products.Add(new Product(8, "Digital Measuring Tape", 155.90, c1));
        products.Add(new Product(9, "Cat Scratching Post XXL", 299.90, c4));
        products.Add(new Product(10, "Carbon Fiber Bicycle Helmet", 450.00, c5));
        products.Add(new Product(11, "Hand Saw Kit", 89.90, c1));
        products.Add(new Product(12, "Laptop Gamer 16GB RAM", 7499.00, c2));
        products.Add(new Product(13, "Fish Tank 50L", 320.00, c4));
        products.Add(new Product(14, "Smartwatch Fitness Tracker", 1899.99, c5));
        products.Add(new Product(15, "Deck of Cards Standard", 19.90, c3));
        products.Add(new Product(16, "Screwdriver Set 20pcs", 125.00, c1));
        products.Add(new Product(17, "Wireless Keyboard and Mouse", 580.00, c2));
        products.Add(new Product(18, "Yoga Mat Premium", 150.50, c5));
        products.Add(new Product(19, "Small Plush Toy (Random)", 35.00, c3));
        products.Add(new Product(20, "Leash and Collar Set (Large)", 95.00, c4));

        var r1 = products
            .Where(p => p.Category.Tier == Tier.HighQuality && p.Price < 900.00);
        ShowList("High Quality and Price < 900", r1);


        var r2 = products.Where(p => p.Category.Name == "Tools").Select(p => p.Name);
        ShowList("Tools Category: ", r2);
        Console.WriteLine();


        var r3 = products
            .Where(p => p.Name[0] == 'C')
            .Select(p => new { p.Name, p.Price, CategoryName = p.Category.Name });
        ShowList("Names started with 'C'", r3);
        Console.WriteLine();

        var r4 = products
            .Where(p => p.Category.Tier == Tier.MediumQuality)
            .OrderByDescending(p => p.Price);
        ShowList("Category Medium Quality: ", r4);

        var r5 = r4.Skip(2).Take(4);
        ShowList("Skip first 2 elements and take 4 elements: ", r5);

        var r6 = products.FirstOrDefault();
        SinglePrint("First or default test1: ", r6);

        var r7 = products.Where(p => p.Price > 10000).FirstOrDefault();
        SinglePrint("First or default test2:", r7);

        var r8 = products.Where(p => p.Id == 3).SingleOrDefault();
        SinglePrint("Single or default test3:", r8);

        var r9 = products.Where(p => p.Id == 30).SingleOrDefault();
        SinglePrint("Single or default test4:", r9);

        var r10 = products.Max(p => p.Price);
        Console.WriteLine($"Max: {r10:F2}");

        var r11 = products.Min(p => p.Price);
        Console.WriteLine($"Min: {r11:F2}");

        var r12 = products.Where(p => p.Category.Id == 1).Sum(p => p.Price);
        Console.WriteLine($"Category 1 Sum prices: {r12:F2}");

        var r13 = products.Where(p => p.Category.Id == 4).Average(p => p.Price);
        Console.WriteLine($"Category 1 Avarage prices: {r13:F2}");

        var r14 = products
            .Where(p => p.Category.Id == 9)
            .Select(p => p.Price)
            .DefaultIfEmpty(0.0) // coloca um valor padrao `0.0` caso a lista esteja vazia
            .Average(); // n precisa colocar nd no Avarage pq ja especificou no Select
        Console.WriteLine($"Category (not-existent) Security Avarage prices: {r14:F2}");

        var r15 = products
            .Where(p => p.Category.Id == 1)
            .Select(p => p.Price) // escolhe o campo que quer trabalhar
            .Aggregate((x, y) => x + y); // faz uma funcao com o campo do Where + Select
        Console.WriteLine($"Category 1 normal aggregate sum: {r15:F2}");

        var r16 = products
            .Where(p => p.Category.Id == 9)
            .Select(p => p.Price)
            .Aggregate(0.0, (x, y) => x + y); // valor inicial: 0.0, caso vazio o resultado vai ser 0.0
        Console.WriteLine($"Category (not-existent) security aggregate sum: {r16:F2}");
        Console.WriteLine();

        var r17 = products.GroupBy(p => p.Category);
        foreach (var group in r17)
        {
            Console.WriteLine($"Category {group.Key.Name}:");
            Console.WriteLine("----------------------------------------------------");
            foreach (var p in group)
            {
                Console.WriteLine(p);
            }
        }
    }

    static void SinglePrint(string message, Product p)
    {
        Console.WriteLine(message);
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine(p);
    }

    static void ShowList<T>(string message, IEnumerable<T> collection)
    {
        Console.WriteLine(message);
        Console.WriteLine("----------------------------------------------------");
        foreach (var item in collection)
        {
            Console.WriteLine(item);
        }
    }
}


