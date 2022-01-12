using Models;
using RepoDL;
namespace ESLogic;

public class Customer_BL
{
    Customer_Repo cRepo = new Customer_Repo ();
    public bool isSignedIn = false;
    
    public void CustomerSignIn ()
    {
        Customer cus = new Customer ();
        Console.WriteLine("Enter your Email:");
        cus.email = Console.ReadLine();
        Console.WriteLine("Enter your Password:");
        cus.password = Console.ReadLine();

        cRepo.SignIn(cus);
        if (Current_User.User_Id != 0)
        {
            isSignedIn = true;
        }
    }

    public void GetAllStores ()
    {
        List<Store> sList = new List<Store> (); 
        sList = cRepo.GetAllStores();
        foreach(Store s in sList)
        {
            Console.WriteLine(s.StoreId.ToString() + "    " + s.storeName.ToString() );
        }
    }

    public void SetStore ()
    {
        List<Store> sList = new List<Store> (); 
        sList = cRepo.GetAllStores();
        foreach(Store s in sList)
        {
            Console.WriteLine(s.StoreId.ToString() + "  " + s.storeName.ToString());
        }
            try
            {
                Console.WriteLine ("Enter Store ID: ");
                Current_User.store_Id = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine ("Invalid Entry");
            }
    }

    public void GetStoreInventory ()
    {
        List<Inventory> invList = new List<Inventory> ();
        invList = cRepo.GetInventoryByStoreId(Current_User.store_Id);
        foreach(Inventory iv in invList)
        {
            Console.WriteLine (iv.productId.ToString() + "  " + iv.productName.ToString() + "  " + iv.unitPrice.ToString());
        }
    }

    public void AddToCart ()
    {
        int _proId;
        int _quantity;

            OrderItem item = new OrderItem ();
            Console.WriteLine ("Enter a Product ID to add ");
            _proId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine ("Enter quantity ");
            _quantity = Convert.ToInt32(Console.Read());
            item.customerId = Current_User.User_Id;
            item.proId = _proId;
            item.storeId = Current_User.store_Id;
            item.unitPrice = cRepo.GetProductPriceById(_proId, Current_User.store_Id);
            item.quantity = _quantity;
            Current_User.shoppingList.Add(item);
    }

    public void Checkout()
    {   
        cRepo.CreateOrder(Current_User.User_Id, Current_User.store_Id);
        cRepo.Checkout();
        if (cRepo.success == true)
        {
            Console.WriteLine ("Your Order has been placed");
            Console.WriteLine ("Thank You For Shopping With Us");
        }
        Current_User.shoppingList.Clear();
    }

    public void SignUp ()
    {
        Customer cus = new Customer ();
        Console.WriteLine("Enter your First Name:");
        cus.firstName = Console.ReadLine();
        Console.WriteLine("Enter your Last Name:");
        cus.lastName = Console.ReadLine();
        Console.WriteLine("Enter your Street Number:");
        cus.streetNumber = Console.ReadLine();
        Console.WriteLine("Enter your Apartment Number:");
        cus.apt = Console.ReadLine();
        Console.WriteLine("Enter your City:");
        cus.city = Console.ReadLine();
        Console.WriteLine("Enter your State:");
        cus.state = Console.ReadLine();
        Console.WriteLine("Enter your Zip Code:");
        cus.zip = Console.ReadLine();
        Console.WriteLine("Enter your Email:");
        cus.email = Console.ReadLine().ToLower();
        Console.WriteLine("Enter your Password:");
        cus.password = Console.ReadLine();

        cRepo.CheckExistCustomer(cus);
        if(cRepo.duplicate != true)
        {
            cRepo.CreateCustomer(cus);
            if (cRepo.success == true)
            {
                Console.WriteLine ("New Customer Has Been Created Successfully");
            }
            else
                Console.WriteLine ("Unable To Create New Customer");
        }
        else
                Console.WriteLine ("The Email Is Already Exist In The System");
    }
}