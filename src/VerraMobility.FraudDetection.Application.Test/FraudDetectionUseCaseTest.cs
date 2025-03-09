using FluentAssertions;
using VerraMobility.FraudDetection.Application.Contracts;
using VerraMobility.FraudDetection.Application.UseCases;
using VerraMobility.FraudDetection.Domain.Contracts;
using VerraMobility.FraudDetection.Domain.Service;

namespace Prueba2.Application.Test;

public class FraudDetectionUseCaseTest
{
    private readonly IOrderService _orderService;
    private readonly IFraudDetectionUseCase _sut;
    public FraudDetectionUseCaseTest()
    {
        _orderService = new OrderService();

        _sut = new FraudDetectionUseCase(
            _orderService,
            new OrderComparerService()
        );
    }

    [Fact]
    public void ShouldDetectedFraudulentOperationsRequiredIncompleteInlineOrder()
    {

        //Arrange
        IEnumerable<string> inlinesOrders =
        [
            "1,5, example@gamil.com",
            "2,1,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010",
            "3,3",
            "4,6,bugs@bunny.com,123 Sesame St.",
        ];

        //Act
        _sut.ExecuteFraudDetection(inlinesOrders);
        IEnumerable<int> incompletedOrderIds = _orderService.GetIncompletedOrdersIdAscendant();
        IEnumerable<int> fraudulentsOrderIds = _orderService.GetInvalidOrdersIdAscendant();

        //Assert
        incompletedOrderIds.Should().HaveCount(3).And.BeEquivalentTo(new[] { 1, 3, 4 });
        fraudulentsOrderIds.Should().HaveCount(0);
    }


    [Fact]
    public void ShouldDetectedFraudulentOperationsRequiredDiferentsEmailsAndDifferentCreditCard()
    {

        //Arrange
        IEnumerable<string> inlinesOrders =
        [
            "1,1,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010",
            "2,1,elmer@fudd.com,123 Sesame St.,New York,NY,10011,10987654321",
            "3,2,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010",
        ];

        //Act
        _sut.ExecuteFraudDetection(inlinesOrders);
        IEnumerable<int> incompletedOrderIds = _orderService.GetIncompletedOrdersIdAscendant();
        IEnumerable<int> fraudulentsOrderIds = _orderService.GetInvalidOrdersIdAscendant();

        //Assert
        incompletedOrderIds.Should().HaveCount(0);
        fraudulentsOrderIds.Should().HaveCount(2).And.BeEquivalentTo(new[] { 1, 2 });
    }

    [Fact]
    public void ShouldDetectedFraudulentOperationsRequiredDiferentsAddresAndDifferentCreditCard()
    {

        //Arrange
        IEnumerable<string> inlinesOrders =
        [
            "1,2,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010",
            "2,1,bugs@bunny.com,123 Sesame St.,New York,NY,10011,10987654321",
            "3,1,bugs@bunny.com,12345 Sesame St.,New York,NY,10011,12345689010",
        ];

        //Act
        _sut.ExecuteFraudDetection(inlinesOrders);
        IEnumerable<int> incompletedOrderIds = _orderService.GetIncompletedOrdersIdAscendant();
        IEnumerable<int> fraudulentsOrderIds = _orderService.GetInvalidOrdersIdAscendant();

        //Assert
        incompletedOrderIds.Should().HaveCount(0);
        fraudulentsOrderIds.Should().HaveCount(2).And.BeEquivalentTo(new[] { 2, 3 });
    }

    [Fact]
    public void ShouldDetectedFraudulentOperationsRequiredDiferentsAddresAndEmailAndDifferentCreditCard()
    {

        //Arrange
        IEnumerable<string> inlinesOrders =
        [
            "1,2,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010",
            "2,1,bugs@bunny.com,123 Sesame St.,New York,NY,10011,10987654321",
            "3,1,bugs@bunny.com,12345 Sesame St.,New York,NY,10011,12345689010",
            "4,3,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010",
            "5,3,elmer@fudd.com,123 Sesame St.,New York,NY,10011,10987654321",
        ];

        //Act
        _sut.ExecuteFraudDetection(inlinesOrders);
        IEnumerable<int> incompletedOrderIds = _orderService.GetIncompletedOrdersIdAscendant();
        IEnumerable<int> fraudulentsOrderIds = _orderService.GetInvalidOrdersIdAscendant();

        //Assert
        incompletedOrderIds.Should().HaveCount(0);
        fraudulentsOrderIds.Should().HaveCount(4).And.BeEquivalentTo(new[] { 2, 3, 4, 5 });
    }

    [Fact]
    public void ShouldDetectedFraudulentOperationsRequiredDiferentsAddresAndEmailAndDifferentCreditCardAndInvalidLine()
    {

        //Arrange
        IEnumerable<string> inlinesOrders =
        [
            "1,2,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010",
            "2,1,bugs@bunny.com,123 Sesame St.,New York,NY,10011,10987654321",
            "3,1,bugs@bunny.com,12345 Sesame St.,New York,NY,10011,12345689010",
            "4,3,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010",
            "5,3,elmer@fudd.com,123 Sesame St.,New York,NY,10011,10987654321",
            "6",
            "7,5,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010",
        ];

        //Act
        _sut.ExecuteFraudDetection(inlinesOrders);
        IEnumerable<int> incompletedOrderIds = _orderService.GetIncompletedOrdersIdAscendant();
        IEnumerable<int> fraudulentsOrderIds = _orderService.GetInvalidOrdersIdAscendant();

        //Assert
        incompletedOrderIds.Should().HaveCount(1).And.BeEquivalentTo(new[] { 6 });
        fraudulentsOrderIds.Should().HaveCount(4).And.BeEquivalentTo(new[] { 2, 3, 4, 5 });
    }

    [Fact]
    public void ShouldDetectedFraudulentOperationsRequiredBadEmail()
    {

        //Arrange
        IEnumerable<string> inlinesOrders =
        [
            "1,2,bugsbunny.com,123 Sesame St.,New York,NY,10011,12345689010",
        ];

        //Act
        _sut.ExecuteFraudDetection(inlinesOrders);
        IEnumerable<int> incompletedOrderIds = _orderService.GetIncompletedOrdersIdAscendant();
        IEnumerable<int> fraudulentsOrderIds = _orderService.GetInvalidOrdersIdAscendant();

        //Assert
        incompletedOrderIds.Should().HaveCount(0);
        fraudulentsOrderIds.Should().HaveCount(1).And.BeEquivalentTo(new[] { 1 });
    }

    [Fact]
    public void ShouldDetectedFraudulentOperationsRequiredDifferentCreditCardDifferentEmailAddressTheSame()
    {

        //Arrange
        IEnumerable<string> inlinesOrders =
        [
            "1,1,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010",
            "2,1,elmer@fudd.com,123 Sesame Street,New York,NY,10011,10987654321",
            "3,2,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010",
            "4,2,bugs@bunny.com,123 Sesame St.,New York,New York,10011,10987654321",
        ];

        //Act
        _sut.ExecuteFraudDetection(inlinesOrders);
        IEnumerable<int> incompletedOrderIds = _orderService.GetIncompletedOrdersIdAscendant();
        IEnumerable<int> fraudulentsOrderIds = _orderService.GetInvalidOrdersIdAscendant();

        //Assert
        incompletedOrderIds.Should().HaveCount(0);
        fraudulentsOrderIds.Should().HaveCount(4).And.BeEquivalentTo(new[] { 1,2,3,4 });
    }

    [Fact]
    public void ShouldDetectedFraudulentOperationsRequiredDifferentCreditCardDifferentAddresEmailTheSame()
    {

        //Arrange
        IEnumerable<string> inlinesOrders =
        [
            "1,2,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010",
            "2,2,bugs+check@bunny.com,123 Sesame St.,New York,New York,10011,10987654321",
            "3,2,bug.s@bunny.com,123 Sesame St.,New York,New York,10011,10987654321",
        ];

        //Act
        _sut.ExecuteFraudDetection(inlinesOrders);
        IEnumerable<int> incompletedOrderIds = _orderService.GetIncompletedOrdersIdAscendant();
        IEnumerable<int> fraudulentsOrderIds = _orderService.GetInvalidOrdersIdAscendant();

        //Assert
        incompletedOrderIds.Should().HaveCount(0);
        fraudulentsOrderIds.Should().HaveCount(3).And.BeEquivalentTo(new[] { 1, 2, 3 });
    }
}