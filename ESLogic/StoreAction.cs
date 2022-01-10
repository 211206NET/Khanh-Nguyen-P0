using Menus;
using Models;
using DataRepository;
namespace ESLogic;

public class StoreAction 
{
    Main_Menu mMenu = new Main_Menu ();
    Customer_Menu cMenu = new Customer_Menu ();
    Staff_Menu sMenu = new Staff_Menu ();
    SignInOptions oMenu = new SignInOptions ();
    Customer_Logic clogic = new Customer_Logic ();
    Staff_Logic slogic = new Staff_Logic ();
    List<OrderItem> shoppingList = new List<OrderItem> ();
    StaffRepository sr = new StaffRepository ();
    CustomerRepository cr = new CustomerRepository ();
    public void Load ()
    {
        int i;
        mMenu.DisplayMenu();
        for(i = 0; i >= 0; i++)
        {
            switch (mMenu.returned)
            {
                case 1:
                {
                    oMenu.DisplayMenu();
                    switch (oMenu.returned)
                    {
                        case 31:
                        {
                            clogic.CustomerSignIn ();
                            if(clogic.isSignedIn == true)
                            {
                                cMenu.DisplayMenu ();
                                switch (cMenu.returned)
                                {
                                    case 11:
                                    {
                                        clogic.GetAllStores();
                                    }
                                    break;
                                    case 12:
                                    {
                                        Current_User.store_Id = clogic.SetStore ();
                                    }
                                    break;
                                    case 13:
                                    {
                                        if (Current_User.store_Id == 0)
                                        {
                                            Current_User.store_Id = clogic.SetStore ();
                                        }
                                        clogic.GetStoreInventory (Current_User.store_Id);
                                    }
                                    break;
                                    case 14:
                                    {
                                        if (Current_User.store_Id == 0)
                                        {
                                            Current_User.store_Id = clogic.SetStore ();
                                        }
                                        clogic.AddToCart (Current_User.store_Id);
                                        clogic.Checkout (shoppingList);
                                    }
                                    break;
                                    case 15:
                                    {
                                        foreach(OrderItem item in shoppingList)
                                        {
                                            Console.WriteLine (item.ToString());
                                        }
                                    }
                                    break;
                                    case 0:
                                    {
                                        Current_User.User_Id = 0;
                                        Current_User.store_Id = 0;
                                        Current_User.order_Id = 0;
                                        //mMenu.DisplayMenu ();
                                    }
                                    break;
                                    default:
                                        cMenu.DisplayMenu ();
                                    break;
                                }
                            }
                            else
                                Console.WriteLine ("Sign In Fail! Try again");
                                //clogic.CustomerSignIn ();
                        }
                        break;
                        case 32:
                        {
                            slogic.StaffSignIn();
                            if(slogic.isSignedIn == true)
                            {
                                sMenu.DisplayMenu ();
                                switch (sMenu.returned)
                                {
                                    case 21:
                                    {
                                        slogic.GetAllStores ();
                                    }
                                    break;
                                    case 22:
                                    {
                                        Current_User.store_Id = slogic.SetStore ();
                                    }
                                    break;
                                    case 23:
                                    {
                                        if (Current_User.store_Id == 0)
                                        {
                                            Current_User.store_Id = slogic.SetStore ();
                                        }
                                        slogic.GetInventoryByStore (Current_User.store_Id);
                                    }
                                    break;
                                    case 24:
                                    {
                                        slogic.GetAllStoreInventory ();
                                    }
                                    break;
                                    case 25:
                                    {
                                        if (Current_User.store_Id == 0)
                                        {
                                            Current_User.store_Id = slogic.SetStore ();
                                        }
                                        slogic.FillInventory ();
                                    }
                                    break;
                                    case 26:
                                    {
                                        slogic.NewEmployee ();
                                    }
                                    break;
                                    case 0:
                                    {
                                        Current_User.User_Id = 0;
                                        Current_User.store_Id = 0;
                                        Current_User.order_Id = 0;
                                        //mMenu.DisplayMenu ();
                                    }
                                    break;
                                    default:
                                        sMenu.DisplayMenu ();
                                    break;
                                }
                                
                            }
                            else
                                Console.WriteLine ("Sign In Fail! Try again");
                                slogic.StaffSignIn ();
                        }
                        break;
                        case 33:
                        {
                            mMenu.DisplayMenu();
                        }
                        break;
                        default:
                            oMenu.DisplayMenu();
                        break;
                    }
                }
                break;
                case 2:
                {
                    clogic.SignUp ();
                    if (cr.success != true)
                        {
                            clogic.SignUp ();
                        }
                }
                break;
                case 0:
                {
                    //Console.WriteLine("Good Bye !!!");
                    
                }
                break;
                default:
                    Console.WriteLine("Invalid entry!  Try again");
                break;
            }
            //mMenu.DisplayMenu ();
            if(mMenu.returned == 0)
            {
                Console.WriteLine("Good Bye !!!");
                break;
            }           
        }
    }
}
