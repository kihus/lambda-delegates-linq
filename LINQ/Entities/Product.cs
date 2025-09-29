namespace LINQ.Entities;

internal class Product(int id, string name, double price, Category category)
{
	public int Id { get; set; } = id;
	public string? Name { get; set; } = name;
	public double Price { get; set; } = price;
	public Category Category { get; set; } = category;

	public override string ToString()
	{
		return $"ID: {Id}\n" +
			$"Name: {Name}\n" +
			$"Price: {Price:F2}\n" +
			$"Category: {Category.Name}, {Category.Tier}\n";
	}
}
