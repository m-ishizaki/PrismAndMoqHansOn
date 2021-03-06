using Moq;
using NUnit.Framework;
using TextSpeaker.Model;

// ReSharper disable once CheckNamespace
namespace TextSpeaker.ViewModels.Tests
{
    [TestFixture]
    public class TextSpeechPageViewModelTest
    {
        [Test]
        public void SpeechTest()
        {
            var service = new Mock<ITextToSpeechService>();
            var viewModel = new TextSpeechPageViewModel(service.Object);
            viewModel.Text = "Message";

            var command = viewModel.SpeechCommand;
            Assert.NotNull(command);
            Assert.True(command.CanExecute(null));
            command.Execute(null);

            service.Verify(m => m.Speech("Message"));
        }
    }
}
