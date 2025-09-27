using LINQ.Entities;

List<Product> list = new();
list.Add(new Product("TV", 900.00));
list.Add(new Product("Notebook", 1200.00));
list.Add(new Product("Tablet", 450.00));
list.Add(new Product("Computador", 5550.00));

Comparison<Product> comp = CompareProducts;

list.Sort(CompareProducts);

foreach(var item in list)
{
	Console.WriteLine(item);
}

static int CompareProducts(Product p1, Product p2)
{
	return p1.Name.ToUpper().CompareTo(p2.Name.ToUpper());
}