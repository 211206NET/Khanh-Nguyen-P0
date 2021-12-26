using Models;
using Menus;
namespace ESLogic;

public class Users 
{
    private Customer _customer;
    private int _stId;
    public bool isSignedIn = false;
    public string uRole;
    private string email;
     private string pass;
     IMenu CMenu = new Customer_Menu ();

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

    public bool SignIn ()
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
}