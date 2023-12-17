using btg_testes_auto.ShippingCost;
using FluentAssertions;
using NSubstitute;

namespace btg_test.ShippingCostTest;

public class ShippingServiceTest
{
    private readonly IDeliveryCostCalculator _mockDeliveryCostCalculator;
    private ShippingService _service;

    public ShippingServiceTest()
    {
        _mockDeliveryCostCalculator = Substitute.For<IDeliveryCostCalculator>();
        _service = new ShippingService(_mockDeliveryCostCalculator);
    }

    [Theory]
    [InlineData(200, DeliveryType.Express)]
    [InlineData(150, DeliveryType.Express)]
    [InlineData(100, DeliveryType.Ordinary)]
    [InlineData(201, DeliveryType.Ordinary)]
    [InlineData(250, DeliveryType.Ordinary)]
    public void CalculateShippingCost_ReceiveConditionWithoutDiscount_ReturnWithoutDiscountApplied(double distance, DeliveryType deliveryType)
    {
        //Arrange
        _mockDeliveryCostCalculator.CalculateCost(Arg.Any<double>(), Arg.Any<DeliveryType>()).Returns(10);

        //Act
        double result = _service.CalculateShippingCost(distance, deliveryType);

        //Assert
        result.Should().Be(10);
    }

    [Theory]
    [InlineData(201, DeliveryType.Express)]
    [InlineData(250, DeliveryType.Express)]
    public void CalculateShippingCost_ReceiveConditionWithDiscount_ReturnDiscountApplied(double distance, DeliveryType deliveryType)
    {
        //Arrange
        _mockDeliveryCostCalculator.CalculateCost(Arg.Any<double>(), Arg.Any<DeliveryType>()).Returns(10);
        double expectedDiscount = 5;

        //Act
        double result = _service.CalculateShippingCost(distance, deliveryType);

        //Assert
        result.Should().Be(expectedDiscount);
    }
}

