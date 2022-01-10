using Models;
using Menus;
using DataRepository;
namespace ESLogic;


public class Customer_Logic
{
    private int _proId;
    //private int _custId;
    private int _quantity;
    private  int _orderId;
    public bool isSignedIn = false;
    // private string _fname;
    // private string _lname;
    // private string _stnum;
    // private string _apt;
    // private string _city;
    // private string _state;
    // private string _zip;
    // private string _email;
    // private string _pass;
    CustomerRepository cRepo = new CustomerRepository ();
    Customer_Menu cMenu = new Customer_Menu();
    Customer cus = new Customer ();
    List<OrderItem> itemInCart = new List<OrderItem> ();
    List<Store> sList = new List<Store> ();
    List<Inventory> invList = new List<Inventory> ();

    public int SetStore ()
    {
        int _stId;
        sList = cRepo.GetAllStores();
        foreach(Store s in sList)
        {
            Console.WriteLine(s.ToString());
        }
        Console.WriteLine ("Enter Store ID: ");
        _stId = Convert.ToInt32(Console.ReadLine());
        return _stId;
    }

    public void GetAllStores ()
    {
        sList = cRepo.GetAllStores();
        foreach(Store s in sList)
        {
            Console.WriteLine(s.StoreId.ToString() + "    " + s.storeName.ToString() );
        }
    }

    public void CustomerSignIn ()
    {
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

    public void SignUp ()
    {
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

    public void GetStoreInventory (int stId)
    {
        invList = cRepo.GetInventoryByStoreId(stId);
        foreach(Inventory iv in invList)
        {
            Console.WriteLine (iv.productId.ToString() + "  " + iv.productName.ToString() + "  " + iv.unitPrice.ToString());
        }
    }
    public List<OrderItem> AddToCart (int stId)
    {
        string _input;
        invList = cRepo.GetInventoryByStoreId(stId);
        foreach(Inventory iv in invList)
        {
            Console.WriteLine (iv.productId.ToString() + "  " + iv.productName.ToString() + "  " + iv.unitPrice.ToString());
        }
        OrderItem item = new OrderItem ();
        Console.WriteLine("1 - Add an Item to Cart");
        Console.WriteLine("2 - Checkout and Back to Customer Menu");
        _input = Console.ReadLine();
       
        if (_input == "1")
        {
            Console.WriteLine ("Enter a Product ID to add ");
            _proId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine ("Enter quantity ");
            _quantity = Convert.ToInt32(Console.Read());
            item.customerId = Current_User.User_Id;
            item.proId = _proId;
            item.storeId = Current_User.store_Id;
            item.unitPrice = cRepo.GetProductPriceById(_proId, Current_User.store_Id);
            item.quantity = _quantity;
            itemInCart.Add(item);
        }
        else if (_input == "2")
        {
            cMenu.DisplayMenu();
        }
        else
            cMenu.DisplayMenu();

        for(int i = 0; i >= 0; i++)
        {
            Console.WriteLine("1 - Add another Item");
            Console.WriteLine("2 - Checkout and Back to Customer Menu");
            _input = Console.ReadLine();
            
            if (_input == "1")
            {
                Console.WriteLine ("Enter a Product ID to add ");
                _proId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine ("Enter quantity ");
                _quantity = Convert.ToInt32(Console.Read());
                item.customerId = Current_User.User_Id;
                item.proId = _proId;
                item.storeId = Current_User.store_Id;
                item.unitPrice = cRepo.GetProductPriceById(_proId, Current_User.store_Id);
                item.quantity = _quantity;
                itemInCart.Add(item);
            }
            else if (_input == "2")
            {
                Checkout(itemInCart);
                cMenu.DisplayMenu();
            }
            else
                cMenu.DisplayMenu();
            
        }
        return itemInCart;
    }

    public void Checkout(List<OrderItem> cart)
    {   
        Current_User.order_Id = cRepo.CreateOrder(Current_User.User_Id, Current_User.store_Id);
        cRepo.Checkout(Current_User.order_Id, cart);
    }
}