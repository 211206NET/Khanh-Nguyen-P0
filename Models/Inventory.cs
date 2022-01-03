namespace Moddels;

public class Inventory
{
    private int _storeId;
    public int storeId
    {
        get => _storeId;
        set => _storeId = value;
    }
    private int _productId;
    public int productId
    {
        get => _productId;
        set => _productId = value;
    }
    private string _productDescription;
    public String productDescription
    {
        get => _productDescription;
        set => _productDescription = value;
    }
    private int _qunatity;
    public int qunatity
    {
        get => _qunatity;
        set => _qunatity = value;
    }
}