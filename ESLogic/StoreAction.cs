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
        mMenu.DisplayMenu();
        for ( int i = 1; i > 0; i++ )
        {  
            if ( mMenu.returned == 1 )
            {
                oMenu.DisplayMenu ();
                for ( int c = 1; c > 0; c++ )
                {
                    if (oMenu.returned == 31)
                    {
                        clogic.CustomerSignIn ();
                        for (int j = 1; j > 0; j++)
                        {
                            if (clogic.isSignedIn == true)
                            {
                                cMenu.DisplayMenu ();
                                for(int e = 1; e > 0; e++)
                                {
                                    if (cMenu.returned == 11)
                                    {
                                        clogic.GetAllStores();
                                    }
                                    else if (cMenu.returned == 12)
                                    {
                                        Current_User.store_Id = clogic.SetStore();
                                    }
                                    else if (cMenu.returned == 13)
                                    {
                                        clogic.GetStoreInventory(Current_User.store_Id);
                                    }
                                    else if (cMenu.returned == 14)
                                    {
                                        shoppingList = clogic.AddToCart(Current_User.store_Id);
                                        clogic.Checkout(shoppingList);
                                    }
                                    else if (cMenu.returned == 15)
                                    {
                                        foreach (OrderItem it in shoppingList)
                                        {
                                            if (shoppingList == null)
                                            {
                                                Console.WriteLine ("Cart is empty!");
                                            }
                                            else
                                                Console.WriteLine("Cart");
                                                Console.WriteLine(it);
                                        }
                                    }
                                    else if (cMenu.returned == 0)
                                    {
                                        break;
                                    }
                                    else 
                                        Console.WriteLine("Invalid entry!  Try again");
                                        cMenu.DisplayMenu ();
                                }
                                
                            }
                            else
                                clogic.CustomerSignIn ();
                        }
                    }
                    else if (oMenu.returned == 32)
                    {
                        slogic.StaffSignIn ();
                        if (slogic.isSignedIn == true)
                        {
                            sMenu.DisplayMenu ();
                            for (int g = 1; g > 0; g++)
                            {
                                if (sMenu.returned == 21)
                                {
                                    slogic.GetAllStores ();
                                }
                                else if (sMenu.returned == 22)
                                {
                                    Current_User.store_Id = slogic.SetStore();
                                }
                                else if (sMenu.returned == 23)
                                {
                                    slogic.GetInventoryByStore(Current_User.store_Id);
                                }
                                else if (sMenu.returned == 24)
                                {
                                    slogic.GetAllStoreInventory ();
                                }
                                else if (sMenu.returned == 25)
                                {
                                    slogic.FillInventory();
                                }
                                else if (sMenu.returned == 26)
                                {
                                    slogic.NewEmployee();
                                }
                                else if (sMenu.returned == 0)
                                {
                                    break;
                                }
                                else
                                    Console.WriteLine("Invalid entry!  Try again");
                                    sMenu.DisplayMenu ();
                            }
                        }
                    }
                    else if (oMenu.returned == 33)
                    {
                        break;
                    }
                    else
                        Console.WriteLine("Invalid entry!  Try again");
                        oMenu.DisplayMenu ();
                }
            }
            else if( mMenu.returned == 2 )
            {
                clogic.SignUp ();
                for(int x = 1; x > 0; x++ )
                {
                    if (cr.success != true)
                    {
                        clogic.SignUp ();
                    }
                }
            }
            else if (mMenu.returned == 0 )
            {
                Console.WriteLine("Good Bye !!!");
                break;
            }
            else
                Console.WriteLine("Invalid entry!  Try again");
                mMenu.DisplayMenu();
        }
    }
}