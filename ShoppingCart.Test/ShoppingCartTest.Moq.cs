using TestingBasic;
using Xunit;
using Moq;

namespace TestingBasics.Test;

public class ShoppingCartTest
{
    public readonly Mock<IDbService> _dbServiceMock = new();

    [Fact]
    public void AddProductShouldReturnTrueWhenAddingProduct()
    {
        var product = new Product(1, "Shoes", 200);
        _dbServiceMock.Setup(x => x.SaveShoppingCartItem(product)).Returns(true);
        // Arrange
        ShoppingCart shoppingCart = new (_dbServiceMock.Object);

        // Act
        var result = shoppingCart.AddProduct(product);

        // Assert
        Assert.True(result);
        _dbServiceMock.Verify(x => x.SaveShoppingCartItem(It.IsAny<Product>()), Times.Once);
    }

    [Fact]
    public void AddProductShouldReturnFalseWhenAddingProductFails()
    {

        // Arrange
        ShoppingCart shoppingCart = new (_dbServiceMock.Object);

        // Act
        var result = shoppingCart.AddProduct(null);

        // Assert
        Assert.False(result);
        _dbServiceMock.Verify(x => x.SaveShoppingCartItem(It.IsAny<Product>()), Times.Never);
    }

    [Fact]
    public void DeleteProductShouldReturnTrueWhenRemovingProductHasDone()
    {
        var product = new Product(1, "Shoes", 200);
        _dbServiceMock.Setup(x => x.RemoveShoppingCartItem(product.Id)).Returns(true);

        // Arrange
        ShoppingCart shoppingCart = new (_dbServiceMock.Object);

        // Act
        var result = shoppingCart.DeleteProduct(product.Id);

        // Assert
        Assert.True(result);
        _dbServiceMock.Verify(x => x.RemoveShoppingCartItem(It.IsAny<int>()), Times.Once);
    }

    [Fact]
    public void DeleteProductShouldReturnFalseWhenRemovingProductHasNotDone()
    {
        _dbServiceMock.Setup(x => x.RemoveShoppingCartItem(null)).Returns(false);

        // Arrange
        ShoppingCart shoppingCart = new (_dbServiceMock.Object);

        // Act
        var result = shoppingCart.DeleteProduct(null);

        // Assert
        Assert.False(result);
        _dbServiceMock.Verify(x => x.RemoveShoppingCartItem(null), Times.Never);
    }

    [Fact]
    public void DeleteProductShouldReturnFalseWhenProductIdIsInvalid()
    {
        _dbServiceMock.Setup(x => x.RemoveShoppingCartItem(null)).Returns(false);

        // Arrange
        ShoppingCart shoppingCart = new (_dbServiceMock.Object);

        // Act
        var result = shoppingCart.DeleteProduct(0);

        // Assert
        Assert.False(result);
        _dbServiceMock.Verify(x => x.RemoveShoppingCartItem(null), Times.Never);
    }
}
