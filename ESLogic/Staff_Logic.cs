using Models;
using DataRepository;
namespace ESLogic;
public class Staff_Logic
{
    private int _stId;
    private int _staffId;
    private string _email;
    private string _pass;
      public bool isSignedIn = false;
    
    Staff staff = new Staff ();
    StaffRepository sRepo = new StaffRepository ();
    List<Store> sList = new List<Store> ();
    List<Inventory> invList = new List<Inventory> ();

    public int SetStore ()
    {
        sList = sRepo.GetAllStores();
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
       sList = sRepo.GetAllStores();
        foreach(Store s in sList)
        {
            Console.WriteLine(s.StoreId.ToString() + "    " + s.storeName.ToString() );
        }
    }

    public void StaffSignIn ()
    {
        Console.WriteLine("Enter your Email:");
        staff.email = Console.ReadLine();
        Console.WriteLine("Enter your Password:");
        staff.password = Console.ReadLine();

        sRepo.SignIn(staff);
        if (Current_User.User_Id != 0)
        {
            isSignedIn = true;
        }
    }

    public void GetAllStoreInventory ()
    {
        invList = sRepo.GetAllInventory();
        foreach(Inventory iv in invList)
        {
            Console.WriteLine (iv.productId.ToString() + "  " + iv.productName.ToString() + "  " + iv.unitPrice.ToString());
        }
    }

    public void GetInventoryByStore (int storeId)
    {
        invList =  sRepo.GetInventoryByStoreId(storeId);
        foreach(Inventory iv in invList)
        {
            Console.WriteLine (iv.productId.ToString() + "  " + iv.productName.ToString() + "  " + iv.unitPrice.ToString());
        }
    }

    public void FillInventory()
    {
        GetAllStoreInventory();
        Console.WriteLine("Enter Store ID to Fill");
        int _sId = Convert.ToInt32(Console.Read());
        Console.WriteLine("Enter Product ID to Fill");
        int _pId = Convert.ToInt32(Console.Read());
        Console.WriteLine("Enter the Quantity to Fill");
        int _qty = Convert.ToInt32(Console.Read());
        sRepo.Replenishment(_qty, _pId, _sId);
    }

    public void NewEmployee()
    {
        Console.WriteLine("Enter Employee First Name:");
        staff.firstName = Console.ReadLine();
        Console.WriteLine("Enter Employee Last Name:");
        staff.lastName = Console.ReadLine();
        Console.WriteLine("Enter Street Number:");
        staff.streetNumber = Console.ReadLine();
        Console.WriteLine("Enter Apartment Number:");
        staff.apt = Console.ReadLine();
        Console.WriteLine("Enter City:");
        staff.city = Console.ReadLine();
        Console.WriteLine("Enter State:");
        staff.state = Console.ReadLine();
        Console.WriteLine("Enter Zip Code:");
        staff.zip = Console.ReadLine();
        Console.WriteLine ("Enter Employee role: Mananger - Supervisor - Associate");
        staff.role = Console.ReadLine();
        Console.WriteLine("Enter Email:");
        staff.email = Console.ReadLine().ToLower();
        Console.WriteLine("Enter Password:");
        staff.password = Console.ReadLine();

        sRepo.CheckExistStaff(staff);
        if(sRepo.duplicate != true)
        {
            sRepo.CreateCustomer(staff);
            if (sRepo.success == true)
            {
                Console.WriteLine ("New Employee Has Been Created Successfully");
            }
            else
                Console.WriteLine ("Unable To Create New Employee");
        }
        else
                Console.WriteLine ("The Email Is Already Exist In The System");
    }
}