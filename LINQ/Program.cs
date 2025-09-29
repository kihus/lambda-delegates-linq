using System.Linq;

namespace LINQ;

class Program
{
    static void Main(string[] args)
    {
        // specify the data source
        int[] num = [2, 3, 4, 5];

        // define the query expression
        var result = num
            .Where(x => x % 2 == 0)
            .Select(x => x * 10);

        // execute the query
        foreach(var x in result)
        {
            Console.WriteLine(x);
        }

        // output:
        // 20
        // 40
    }
}


