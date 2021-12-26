namespace Menus;

public class Staff_Menu : IMenu
{
     private string _input = " ";
    public int returned = 0;

    public int DisplayMenu ()
    {
        Console.WriteLine ("Please select a Menu to continue");
        Console.WriteLine ("1 - Set Your Store" );
        Console.WriteLine ("2 - Show Store List" );
        Console.WriteLine ("3 - View Store Inventory");
        Console.WriteLine ("4 - View All Inventories" );
        Console.WriteLine ("5 - Replenishment" );
        Console.WriteLine ("6 - Sign Out");

        _input = Console.ReadLine ();


        switch(_input)
        {
            case "1":
            {
                returned = 21; 
            }
            break;
            case "2":
            {
                returned = 22; 
            }
            break;
            case "3":
            {
                returned = 23; 
            }
            break;
            case "4":
            {
                returned = 24; 
            }
            break;
            case "5":
            {
                returned = 25; 
            }
            break;
            case "6":
            {
                returned = 26; 
            }
            break;
            default:
                returned = 404;
            break;
        }

        return returned;
    }
}