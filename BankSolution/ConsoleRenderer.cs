namespace BankSolution
{
    internal class ConsoleRenderer : IRenderer
    {
        public void Render(string information) 
            => Console.WriteLine(information);
    }
}
