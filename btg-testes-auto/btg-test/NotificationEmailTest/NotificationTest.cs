using btg_testes_auto.Notification;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace btg_test.NotificationEmailTest
{
    public class NotificationTest
    {
        private readonly IEmailService _mockEmailService;
        private NotificationService _service;

        public NotificationTest()
        {
            _mockEmailService = Substitute.For<IEmailService>();
            _service = new(_mockEmailService);
        }

        [Fact]
        public void SendNotification_ReceiveAValidMessage_ReturnTrue()
        {
            // Arrange
            string recipient = "test@test.com";
            string message = "Valid message";

            _mockEmailService.SendEmail(recipient, "Notification", message).Returns(true);

            // Act
            bool result = _service.SendNotification(recipient, message);

            // Assert
            result.Should().BeTrue();            
        }

        [Theory]
        [InlineData(null)]        
        [InlineData(" ")]
        public void SendNotification_ReceiveNullOrWhiteSpaceMessage_ReturnFalse(string invalidMessage)
        {
            // Arrange
            string recipient = "test@test.com";

            // Act
            bool result = _service.SendNotification(recipient, invalidMessage);

            // Assert
            result.Should().BeFalse();            
        }

        [Fact]
        public void SendNotification_ReceiveException_ReturnFalse()
        {
            // Arrange
            string recipient = "test@test.com";
            string message = "Valid message";

            _mockEmailService.SendEmail(recipient, "Notification", message).Throws(new Exception());

            // Act
            bool result = _service.SendNotification(recipient, message);

            // Assert
            result.Should().BeFalse();
        }
    }
}
