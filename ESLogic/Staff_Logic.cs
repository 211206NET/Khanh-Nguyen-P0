using Models;
namespace ESLogic;
public class Staff_Logic
{
    public int stId;
    public int staffId;
    private string _email;
    private string _pass;
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

    public int StaffSignIn ()
    {
        Console.WriteLine("Enter your Email:");
        _email = Console.ReadLine();
        Console.WriteLine("Enter your Password:");
        _pass = Console.ReadLine();

        isSignedIn = true;


        return staffId;
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