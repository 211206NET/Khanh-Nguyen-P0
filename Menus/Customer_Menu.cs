namespace Menus;

public class Customer_Menu : IMenu
{
     private string _input = " ";
    public int returned = 0;

    public int DisplayMenu ()
    {
        Console.WriteLine ("Please select a Menu to continue");
        Console.WriteLine ("1 - Set Your Store" );
        Console.WriteLine ("2 - Show Store List" );
        Console.WriteLine ("3 - View Store Inventory");
        Console.WriteLine ("4 - Add Item Cart" );
        Console.WriteLine ("5 - View Cart" );
        Console.WriteLine ("0 - Sign Out");

        _input = Console.ReadLine ();


        switch(_input)
        {
            case "1":
            {
                returned = 11; 
            }
            break;
            case "2":
            {
                returned = 12; 
            }
            break;
            case "3":
            {
                returned = 13; 
            }
            break;
            case "4":
            {
                returned = 14; 
            }
            break;
            case "5":
            {
                returned = 15; 
            }
            break;
            case "0":
            {
                returned = 0; 
            }
            break;
            default:
                returned = 404;
            break;
        }
            return returned;
    }           
}