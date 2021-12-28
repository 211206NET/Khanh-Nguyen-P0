using Models;
namespace ESLogic;
public class Staff_Logic
{
    private int _stId;
    private string email;
    private string pass;
    public bool isSignedIn;

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

    public bool StaffSignIn ()
    {
        Console.WriteLine("Enter your Email:");
        email = Console.ReadLine();
        Console.WriteLine("Enter your Password:");
        pass = Console.ReadLine();

        isSignedIn = true;


        return isSignedIn;
    }

    public List<Product> GetAllStoreInventory ()
    {
            List<Product> storeInventory = new List<Product>();
            //Query Inventory by store ID here!
            return storeInventory;
    }

    public List<Product> GetInventoryByStore (int storeId)
    {
            List<Product> storeInventory = new List<Product>();
            //Query Inventory by store ID here!
            return storeInventory;
    }
}