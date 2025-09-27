using LINQ.Entities;

List<Product> list = new();
list.Add(new Product("TV", 900.00));
list.Add(new Product("Notebook", 1200.00));
list.Add(new Product("Tablet", 450.00));
list.Add(new Product("Computador", 5550.00));

list.Sort((p1, p2) => p1.Name.ToUpper().CompareTo(p2.Name.ToUpper()));

foreach(var item in list)
{
	Console.WriteLine(item);
}
