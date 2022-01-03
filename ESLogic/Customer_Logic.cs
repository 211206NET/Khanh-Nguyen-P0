using Models;
using System;
namespace ESLogic;


public class Customer_Logic
{
    public int stId;
    public int proId;
    public int custId;
    public int quantity;
    private  int _orderId = 0 ;
    public bool isSignedIn = false;
    private string _email;
    private string _pass;
    public List<OrderItem> itemInCart = new List<OrderItem> ();

    public int SetStore ()
    {
        Console.WriteLine ("Enter Store ID: ");
        stId = Convert.ToInt32(Console.ReadLine());
        return stId;
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
        _email = Console.ReadLine();
        Console.WriteLine("Enter your Password:");
        _pass = Console.ReadLine();
    }

    public List<Product> GetStoreInventory (int storeId)
    {
            List<Product> storeInventory = new List<Product>();
            //Query Inventory by store ID here!
            return storeInventory;
    }
    public List<OrderItem> AddToCart ()
    {
        Console.WriteLine ("Enter a Product ID to add ");
        proId = Convert.ToInt32(Console.ReadLine());
        OrderItem item = new OrderItem ();
        itemInCart.Add(item);
        return itemInCart;
    }

    public int CreateOrder()
    {   
        return _orderId;
    }

   public void FinalizedOrder ()
   {
       //Persist to database here!!!
   }
}