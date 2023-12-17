using btg_testes_auto.NotificationMessage;
using FluentAssertions;
using NSubstitute;

namespace btg_test.NotificationMessageTest;

public class NotificationMessageServiceTest
{
    private readonly IMessageService _mockMessageService;
    private readonly NotificationMessageService _service;

    public NotificationMessageServiceTest()
    {
        _mockMessageService = Substitute.For<IMessageService>();
        _service = new NotificationMessageService(_mockMessageService);
    }

    [Fact]
    public void NotifyUsers_ReceiveAllMessagesSent_ReturnTrue()
    {
        // Arrange
        List<Notification> notifications = new List<Notification>
        {
            new Notification { UserId = "user123", Message = "First Message" },
            new Notification { UserId = "user321", Message = "Second Message" }
        };

        _mockMessageService.SendMessage(Arg.Any<string>(), Arg.Any<string>()).Returns(true);

        // Act
        bool result = _service.NotifyUsers(notifications);

        // Assert
        result.Should().BeTrue();
        _mockMessageService.Received().SendMessage(Arg.Any<string>(), Arg.Any<string>());
    }

    [Fact]
    public void NotifyUsers_ReceiveOneFailedMessage_ReturnFalse()
    {
        // Arrange     
        List<Notification> notifications = new List<Notification>
        {
            new Notification { UserId = "user123", Message = "First Message" },
            new Notification { UserId = "user321", Message = "Second Message" }
        };

        _mockMessageService.SendMessage("user123", "First Message").Returns(true);
        _mockMessageService.SendMessage("user321", "Second Message").Returns(false);

        // Act
        bool result = _service.NotifyUsers(notifications);

        // Assert
        result.Should().BeFalse();
        _mockMessageService.Received().SendMessage(Arg.Any<string>(), Arg.Any<string>());
    }

    [Fact]
    public void NotifyUsers_ReceiveAllMessageFailed_ReturnFalse()
    {
        // Arrange     
        List<Notification> notifications = new List<Notification>
        {
            new Notification { UserId = "user123", Message = "First Message" },
            new Notification { UserId = "user321", Message = "Second Message" }
        };

        _mockMessageService.SendMessage("user123", "First Message").Returns(false);
        _mockMessageService.SendMessage("user321", "Second Message").Returns(false);

        // Act
        bool result = _service.NotifyUsers(notifications);

        // Assert
        result.Should().BeFalse();
        _mockMessageService.Received().SendMessage(Arg.Any<string>(), Arg.Any<string>());
    }
}
