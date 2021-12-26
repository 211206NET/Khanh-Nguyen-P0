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
                    for ( int c = 1; c > 0; c++ )
                    {
                        if (cMenu.returned == 1)
                        {

                        }
                        else if (cMenu.returned == 2)
                        {

                        }
                        else if (cMenu.returned == 3)
                        {

                        }
                        else if (cMenu.returned == 4)
                        {

                        }
                        else if (cMenu.returned == 5)
                        {

                        }
                        else if (cMenu.returned == 0)
                        {
                            Console.WriteLine("Good Bye !!!");
                            break;
                        }
                        else
                        Console.WriteLine("Invalid entry!  Try again");
                        cMenu.DisplayMenu();
                    }
                }
                else if(user.uRole == "Staff")
                {
                    sMenu.DisplayMenu();
                    for ( int s = 1; s > 0; s++ )
                    {
                        else if (sMenu.returned == 1)
                        {

                        }
                        else if (sMenu.returned == 2)
                        {

                        }
                        else if (sMenu.returned == 3)
                        {

                        }
                        else if (sMenu.returned == 4)
                        {

                        }
                        else if (sMenu.returned == 0)
                        {
                            Console.WriteLine("Good Bye !!!");
                            break;
                        }
                        else
                        Console.WriteLine("Invalid entry!  Try again");
                        sMenu.DisplayMenu ();
                    }
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