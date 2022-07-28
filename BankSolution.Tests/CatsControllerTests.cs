namespace BankSolution.Tests
{
    internal class CatsControllerTests
    {
        [Test]
        public void AddCatShouldThrowExceptionWithInvalidName()
        {
            // Arrange
            var fakeCatsData = this.GetFakeCatsData();
            var fakeRenderer = new FakeRenderer();
            var catsController = new CatsController(fakeCatsData, fakeRenderer);

            Assert.That(() =>
            {
                // Act
                catsController.Add("So", "Cute cat!", 7);
            },
            // Assert
            Throws.Exception.TypeOf<InvalidDataException>(),
            "Cat name should be at least 3 symbols.");
        }

        [Test]
        public void AddCatShouldSaveItToTheDatabase()
        {
            // Arrange
            var fakeCatsData = this.GetFakeCatsData();
            var fakeRenderer = new FakeRenderer();
            var catsController = new CatsController(fakeCatsData, fakeRenderer);

            // Act
            catsController.Add("SomeCat", "Cute cat!", 7);

            // Assert
            A.CallTo(() => fakeCatsData.Add(A<Cat>.Ignored)).MustHaveHappened();

            Assert.That(fakeRenderer.RenderedInformation, Is.EqualTo("Cat saved! Thank you!"));
        }

        [Test]
        public void ShowCatsShouldRenderCorrectData()
        {
            // Arrange
            var fakeCatsData = this.GetFakeCatsData();

            var fakeRendererMock = new Mock<IRenderer>();

            var renderResult = string.Empty;

            fakeRendererMock
                .Setup(r => r.Render(It.IsAny<string>()))
                .Callback((string information) => renderResult += information);

            var catsController = new CatsController(fakeCatsData, fakeRendererMock.Object);

            // Act
            catsController.ShowCats();

            // Assert
            var renderedResult = $"AnotherTestCat - 3Sharo - 7CoolTestCat - 8";

            Assert.That(renderResult, Is.EqualTo(renderedResult));
        }

        private ICatsData GetFakeCatsData()
        {
            var fakeCatsData = A.Fake<ICatsData>();

            A.CallTo(() => fakeCatsData.Add(A<Cat>.Ignored)).DoesNothing();

            var fakeCats = new List<Cat>
            {
                new Cat("CoolTestCat", "AnotherCoolTestCat", 8),
                new Cat("AnotherTestCat", "AnotherTestDescription", 3),
                new Cat("YetAnotherSharo", "Yet Another Sharen kotak", 9),
                new Cat("Sharo", "Sharen kotak", 7)
            };

            A.CallTo(() => fakeCatsData.All()).Returns(fakeCats);

            return fakeCatsData;
        }
    }
}
