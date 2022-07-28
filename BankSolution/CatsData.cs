namespace BankSolution
{
    internal class CatsData : ICatsData
    {
        private const string catsDatabaseFile = "catsdata.txt";

        // Save new cat to the database.
        public void Add(Cat cat)
        {
            File.AppendAllText(catsDatabaseFile, $"{cat.Name}:{cat.Description}:{cat.Age}{Environment.NewLine}");

            Thread.Sleep(1000);
        }

        // Retrieve all cats from the database.
        public List<Cat> All() 
            => File
                .ReadAllText(catsDatabaseFile)
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Select(catText => catText
                    .Trim()
                    .Split(":"))
                .Select(splitCatText => new Cat(
                    splitCatText[0],
                    splitCatText[1],
                    int.Parse(splitCatText[2])))
                .ToList();
    }
}
