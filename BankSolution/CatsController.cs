namespace BankSolution
{
    public class CatsController
    {
        private readonly ICatsData catsData;
        private readonly IRenderer renderer;

        public CatsController(ICatsData catsData, IRenderer renderer)
        {
            this.catsData = catsData;
            this.renderer = renderer;
        }

        public void Add(string name, string description, int age)
        {
            if (name.Length < 3)
            {
                throw new InvalidDataException("Cat name should be at least 3 symbols.");
            }

            if (age < 0 || age > 30)
            {
                throw new InvalidDataException("Cat age should be between 0 and 30.");
            }

            var cat = new Cat(name, description, age);

            this.catsData.Add(cat);

            this.renderer.Render("Cat saved! Thank you!");
        }

        public void ShowCats()
        {
            var cats = this.catsData
                .All()
                .OrderBy(c => c.Age)
                .Select(c => $"{c.Name} - {c.Age}")
                .Take(3)
                .ToList();

            foreach (var cat in cats)
            {
                this.renderer.Render(cat);
            }
        }
    }
}
