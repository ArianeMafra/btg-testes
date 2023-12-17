using btg_testes_auto.Discount;
using FluentAssertions;
using NSubstitute;

namespace btg_test.ClientDicountTest
{
    public class DiscountServiceTest
    {
        private readonly ICustomerService _mockCustomerService;
        private DiscountService _service;

        public DiscountServiceTest()
        {
            _mockCustomerService = Substitute.For<ICustomerService>();
            _service = new DiscountService(_mockCustomerService);
        }

        [Fact]
        public void GetDiscount_ReceiveRegularCustomer_ReturnsFivePercentDiscount()
        {
            // Arrange
            int customerId = 1;
            double purchaseAmount = 500;

            _mockCustomerService.GetCustomerType(customerId).Returns(CustomerType.Regular);

            // Act
            var result = _service.GetDiscount(customerId, purchaseAmount);

            // Assert
            result.Should().Be(25);
            _mockCustomerService.Received().GetCustomerType(1);
        }

        [Fact]
        public void GetDiscount_ReceivePremiumCustomer_ReturnsTenPercentDiscount()
        {
            // Arrange
            int customerId = 2;
            double purchaseAmount = 1000;

            _mockCustomerService.GetCustomerType(customerId).Returns(CustomerType.Premium);

            // Act
            var result = _service.GetDiscount(customerId, purchaseAmount);

            // Assert
            result.Should().Be(100);
            _mockCustomerService.Received().GetCustomerType(2);
        }

        [Fact]
        public void GetDiscount_ReceiveCustomerWithInvalidType_ReturnsDiscountZero()
        {
            //Arrange
            int customerId = 3;
            double purchaseAmount = 100;

            _mockCustomerService.GetCustomerType(customerId).Returns((CustomerType)3);

            //Act
            var result = _service.GetDiscount(customerId, purchaseAmount);

            //Assert
            result.Should().Be(0);
            _mockCustomerService.Received().GetCustomerType(3);
        }
    }
}
