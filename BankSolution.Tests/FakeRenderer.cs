namespace BankSolution.Tests
{
    internal class FakeRenderer : IRenderer
    {
        private string renderedInformation = string.Empty;

        public string RenderedInformation
        {
            get => this.renderedInformation.Trim();
        }

        public void Render(string information)
        {
            this.renderedInformation += information + Environment.NewLine;
        }
    }
}
