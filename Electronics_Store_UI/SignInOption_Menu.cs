using ESLogic;
namespace Menus;

public class SignInOption : IMenu
{
    private string _input = "";
    public void DisplayMenu() 
    {
        Console.WriteLine ("1 - Customer Sign In" );
        Console.WriteLine ("2 - Staff Sign In");
        Console.WriteLine ("3 - Back");


        _input = Console.ReadLine ();

        switch (_input)
        {
            case "1":
            {
                Customer_BL clogic = new Customer_BL ();
                clogic.CustomerSignIn ();
                if (clogic.isSignedIn == true)
                {
                    Customer_Menu cMenu = new Customer_Menu ();
                    cMenu.DisplayMenu ();
                }
                else
                    clogic.CustomerSignIn ();
            }
            break;
            case "2":
            {
                Staff_BL slogic = new Staff_BL ();
                slogic.StaffSignIn ();
                if(slogic.isSignedIn == true)
                {
                    Staff_Menu sMenu = new Staff_Menu ();
                    sMenu.DisplayMenu ();
                }
                else
                    slogic.StaffSignIn ();
            }
            break;
            case "3":
            {
                Main_Menu mMenu = new Main_Menu ();
                mMenu.DisplayMenu ();
            }
            break;
            default:
            break;
        }
    }
}