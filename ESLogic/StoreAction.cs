using Models;
using Menus;
namespace ESLogic;

public class StoreAction 
{
     Main_Menu mMenu = new Main_Menu ();
     Customer_Menu cMenu = new Customer_Menu ();
    Staff_Menu sMenu = new Staff_Menu ();
    Users user = new Users ();
    public void Load ()
    {
         mMenu.DisplayMenu();
        
           for ( int i = 1; i > 0; i++ )
           {  
            if ( mMenu.returned == 1 )
            {
                user.SignIn ();
                if(user.uRole == "cust")
                {
                    cMenu.DisplayMenu();
                }
                else if(user.uRole == "Staff")
                {
                    sMenu.DisplayMenu();
                }
            }
            else if( mMenu.returned == 2 )
            {
                user.SignUp ();
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