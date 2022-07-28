namespace BankSolution
{
    public class Cat
    {
        public Cat(string name, string description, int age)
        {
            Name = name;
            Description = description;
            Age = age;
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public int Age { get; private set; }
    }
}
