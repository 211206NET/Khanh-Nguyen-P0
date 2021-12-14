namespace Menus;

public class Customer_Menu : Menu
{
    public void DisplayMenu ()
    {
        Console.WriteLine ("1 - Set Your Store" );
        Console.WriteLine ("2 - Show Store List" );
        Console.WriteLine ("3 - View Store Inventory");
        Console.WriteLine ("4 - Add Item Cart" );
        Console.WriteLine ("5 - View Cart" );
        Console.WriteLine ("6 - Sign Out");
    } 
}