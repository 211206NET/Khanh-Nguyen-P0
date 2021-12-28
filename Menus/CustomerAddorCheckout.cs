namespace Menus;
public class CustomerAddorCheckout : IMenu
{
    private string _input = " ";
    public int returned;
    public int DisplayMenu() 
    {
        Console.WriteLine ("1 - Add Another Item" );
        Console.WriteLine ("2 - Checkout");


        _input = Console.ReadLine ();

       switch (_input)
       {
           case "1":
           {
                returned = 41;
           }
           break;
           case "2":
           {
                returned = 42;
           }
           break;
           default:
                returned = 404;
           break;
       }
        return returned;
    }
}