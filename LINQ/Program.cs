using LINQ.Entities;

List<Product> list = new();
list.Add(new Product("TV", 900.00));
list.Add(new Product("Notebook", 1200.00));
list.Add(new Product("Tablet", 450.00));

list.Sort();

foreach(var item in list)
{
	Console.WriteLine(item);
}
