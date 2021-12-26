
namespace Menus;

public class Main_Menu : IMenu
{
    
    private string _input = " ";
    public int returned;
    public int DisplayMenu ()
    {
        Console.WriteLine ("Welcome to Electronics Store");
        Console.WriteLine ("Please select a Menu to start");
        Console.WriteLine ("1 - Sign In" );
        Console.WriteLine ("2 - Sign Up" );
        Console.WriteLine ("0 - Exit");

        _input = Console.ReadLine ();
        
            switch(_input)
            {
                case "1":
                {
                    returned = 1; 
                }
                break;
                
                case "2":
                {
                    returned = 2;
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

