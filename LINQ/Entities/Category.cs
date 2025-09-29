using LINQ.Entities.Enums;
namespace LINQ.Entities;
class Category
{
	public int Id { get; set; }
	public string? Name { get; set; }
	public Tier Tier { get; set; }

	public Category(int id, string? name, Tier tier)
	{
		Id = id;
		Name = name;
		Tier = tier;
	}
}
