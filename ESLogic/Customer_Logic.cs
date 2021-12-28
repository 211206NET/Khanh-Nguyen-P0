using Models;
namespace ESLogic;


public class Customer_Logic
{
    private Customer _customer;
    private int _stId;
    public bool isSignedIn = false;
    private string email;
     private string pass;

     public int SetStore ()
    {
        Console.WriteLine ("Enter Store ID: ");
        _stId = Convert.ToInt32(Console.ReadLine());
        return _stId;
    }

    public List<Store> GetAllStores ()
    {
        List<Store> storeList = new List<Store>();
        return storeList;
    }

    public bool CustomerSignIn ()
    {
        Console.WriteLine("Enter your Email:");
        email = Console.ReadLine();
        Console.WriteLine("Enter your Password:");
        pass = Console.ReadLine();

        isSignedIn = true;


        return isSignedIn;
    }

    public void SignUp ()
    {
        Console.WriteLine("Enter your Email:");
        email = Console.ReadLine();
        Console.WriteLine("Enter your Password:");
        pass = Console.ReadLine();
    }

    public List<Product> GetStoreInventory (int storeId)
    {
            List<Product> storeInventory = new List<Product>();
            //Query Inventory by store ID here!
            return storeInventory;
    }
    public List<OrderItem> AddToCart (OrderItem ordItem)
    {
       OrderItem orItem = ordItem;
        List<OrderItem> itemInCart = new List<OrderItem> ();
        itemInCart.Add(orItem);
        return itemInCart;
    }

    public int CreateOrder(Customer cust, Store sto)
    {   
        int custId = cust.Cid;
        int stId = sto.Stid;
        int orderId = 0 ;
        return orderId;
    }

   public void FinalizedOrder (List<OrderItem> itemInCart)
   {
       List<OrderItem> checkOut = new List<OrderItem> ();
       checkOut = itemInCart;
       //Persist to database here!!!
   }
}