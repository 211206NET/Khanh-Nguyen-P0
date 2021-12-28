namespace Menus;
public class SignInOptions : IMenu
{
    private string _input = " ";
    public int returned;
    public int DisplayMenu() 
    {
        Console.WriteLine ("1 - Customer Sign In" );
        Console.WriteLine ("2 - Staff Sign In");
        Console.WriteLine ("3 - Back");


        _input = Console.ReadLine ();

       switch (_input)
       {
           case "1":
           {
                returned = 31;
           }
           break;
           case "2":
           {
                returned = 32;
           }
           break;
           case "3":
           {
                returned = 33;
           }
           break;
           default:
                returned = 404;
           break;
       }
        return returned;
    }
}