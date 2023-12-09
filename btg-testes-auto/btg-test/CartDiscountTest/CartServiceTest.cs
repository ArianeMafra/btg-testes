using btg_testes_auto.CartDiscount;
using FluentAssertions;
using NSubstitute;

namespace btg_test.CartDiscountTest
{
    public class CartServiceTest
    {
        private readonly IDiscountService _mockDiscountService;
        private readonly CartService _service;

        public CartServiceTest()
        {
            _mockDiscountService = Substitute.For<IDiscountService>();
            _service = new(_mockDiscountService);
        }

        [Fact]
        public void CalculateTotalWithDiscount_ReceiveEmptyItemList_ReturnsZero()
        {
            //Arrange
            List<CartItem> items = new List<CartItem>();        

            //Act
            var result = _service.CalculateTotalWithDiscount(items);

            //Assert
            result.Should().Be(0);

        }

        [Fact]
        public void CalculateTotalWithDiscount_ReceiveAList_ReturnsBiggerThanZero()
        {
            // Arrange
            var items = new List<CartItem>
                {
                    new CartItem { ProductId = "123", Price = 50 },
                    new CartItem { ProductId = "321", Price = 100 }
                };

            // Act
            var result = _service.CalculateTotalWithDiscount(items);

            // Assert
            result.Should().Be(150);
        }
    }
}
