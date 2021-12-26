using Models;
namespace ESLogic;


public class Customer_Logic
{
    public List<OrderItem> AddToCart (OrderItem ordItem)
    {
       OrderItem orItem = ordItem;
        List<OrderItem> itemInCart = new List<OrderItem> ();
        itemInCart.Add(orItem);
        return itemInCart;
    }

    public int CreateOrder(Customer cust, Store sto)
    {   
        int custId = cust.Cid;
        int stId = sto.Stid;
        int orderId = 0 ;
        return orderId;
    }

   public void FinalizedOrder (List<OrderItem> itemInCart)
   {
       List<OrderItem> checkOut = new List<OrderItem> ();
       checkOut = itemInCart;
       //Persist to database here!!!
   }
}