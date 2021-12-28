using Menus;
namespace ESLogic;

public class StoreAction 
{
    Main_Menu mMenu = new Main_Menu ();
    Customer_Menu cMenu = new Customer_Menu ();
    Staff_Menu sMenu = new Staff_Menu ();
    SignInOptions oMenu = new SignInOptions ();
    Customer_Logic clogic = new Customer_Logic ();
    Staff_Logic slogic = new Staff_Logic ();
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
                        if (clogic.isSignedIn == true)
                        {
                            cMenu.DisplayMenu ();
                            for(int e = 1; e > 0; e++)
                            {
                                if (cMenu.returned == 11)
                                {

                                }
                                else if (cMenu.returned == 12)
                                {

                                }
                                else if (cMenu.returned == 13)
                                {

                                }
                                else if (cMenu.returned == 14)
                                {

                                }
                                else if (cMenu.returned == 15)
                                {

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

                                }
                                else if (sMenu.returned == 22)
                                {
                                    
                                }
                                else if (sMenu.returned == 23)
                                {
                                    
                                }
                                else if (sMenu.returned == 24)
                                {
                                    
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
                clogic.CustomerSignIn ();
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