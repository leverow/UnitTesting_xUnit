namespace TestingBasic;

// Product Entity
public record Product(int Id, string Name, double price);

// Db Servis
public interface IDbService
{
    bool SaveShoppingCartItem(Product prod);
    bool RemoveShoppingCartItem(int? id);
}

// Shopping Cart
public class ShoppingCart
{
    private IDbService _dbService;

    public ShoppingCart(IDbService dbService)
    {
        _dbService = dbService;
    }

    public bool AddProduct(Product? product)
    {
        if(product == null)
            return false;

        if(product.Id == 0)
            return false;

        _dbService.SaveShoppingCartItem(product);
        return true;    
    }

    public bool DeleteProduct(int? id)
    {
        if(id == null)
            return false;

        if(id == 0)
            return false;

        _dbService.RemoveShoppingCartItem(id);
        return true;    
    }
}
