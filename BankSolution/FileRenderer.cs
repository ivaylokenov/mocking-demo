namespace BankSolution
{
    internal class FileRenderer : IRenderer
    {
        public void Render(string information) 
            => File.AppendAllText("rendered.txt", information);
    }
}
