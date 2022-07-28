using BankSolution;

var catsData = new CatsData();
var renderer = new ConsoleRenderer();
var catsController = new CatsController(catsData, renderer);

while (true)
{
    Console.Write("Enter cat name: ");
    var catName = Console.ReadLine();

    if (catName.ToLower() == "end!")
    {
        break;
    }

    Console.Write("Enter cat description: ");
    var catDescription = Console.ReadLine();

    Console.Write("Enter cat age: ");
    var catAge = int.Parse(Console.ReadLine());

    catsController.Add(catName, catDescription, catAge);
}

catsController.ShowCats();

