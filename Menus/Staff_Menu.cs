namespace Menus;

public class Staff_Menu : Menu
{
    public void DisplayMenu ()
    {
        Console.WriteLine ("1 - Set Your Store" );
        Console.WriteLine ("2 - Show Store List" );
        Console.WriteLine ("3 - View Store Inventory");
        Console.WriteLine ("4 - View All Inventories" );
        Console.WriteLine ("5 - Replenishment" );
        Console.WriteLine ("6 - Sign Out");
    }
}