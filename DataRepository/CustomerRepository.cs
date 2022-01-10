using Microsoft.Data.SqlClient;
using Models;
namespace DataRepository;

public class CustomerRepository : DataRepositoryInterface
{
    private string _connectionString;
    public bool success = false;
    public bool duplicate = false;
    Customer customer = new Customer();
    Store store = new Store ();
    Inventory item = new Inventory ();
    Order order = new Order ();
    List<OrderItem>  cartItems = new List<OrderItem> ();
    List<Store> storeList = new List<Store> ();
    List<Inventory> storeInventoryList = new List<Inventory> ();
        public CustomerRepository ()
    {
        _connectionString = File.ReadAllText("Connection.txt");
    }

    public int SignIn (Customer cust)
    {
        string _email;
        string _password;
        using(SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            string querystatement = "SELECT CustomerID, Email, Pass FROM Customer WHERE Email = @email AND Pass = @pass";
            using(SqlCommand comd = new SqlCommand(querystatement, conn))
            {
                SqlParameter param;
                param = new SqlParameter("@email", cust.email);
                comd.Parameters.Add(param);
                param = new SqlParameter("@pass", cust.password);
                comd.Parameters.Add(param);
                using (SqlDataReader reader = comd.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        _email = reader.GetString(1);
                        _password = reader.GetString(2);
                        if (cust.email == _email && cust.password == _password)
                        {
                            Current_User.User_Id = reader.GetInt32(0);
                            Console.WriteLine ("Sign In Successfully");
                        }  
                    }
                    else
                        Console.WriteLine ("Invalid Email or Password");
                }
            }
            conn.Close();
        }
        return Current_User.User_Id;
    }

    public List<Store> GetAllStores ()
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            String queryString = "SELECT * FROM Store";
            using (SqlCommand comd = new SqlCommand(queryString, conn))
            {
                using (SqlDataReader reader = comd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        store.StoreId = reader.GetInt32(0);
                        store.storeName = reader.GetString(1);
                        storeList.Add(store);
                    }
                }
            }
            
        }
        return storeList;
    }

    public List<Inventory> GetInventoryByStoreId (int stId)
    {
        int _storeId = stId;
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            String queryString = "SELECT * FROM Inventory WHERE storeID = @storeId";
            using (SqlCommand comd = new SqlCommand(queryString, conn))
            {
                SqlParameter param;
                param = new SqlParameter("@storeId", _storeId);
                comd.Parameters.Add(param);
                using (SqlDataReader reader = comd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        item.storeId = reader.GetInt32(0);
                        item.productId = reader.GetInt32(1);
                        item.productName = reader.GetString(2);
                        item.quantity = reader.GetInt32(3);
                        item.unitPrice = reader.GetDecimal(4);
                        storeInventoryList.Add(item);
                    }
                }
            }
            
        }
        return storeInventoryList;
    }

    public decimal GetProductPriceById (int pId, int sId)
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            String queryString = "SELECT price FROM Inventory WHERE productId = @pId AND storeID = @sId";
            using (SqlCommand comd = new SqlCommand(queryString, conn))
            {
                SqlParameter param;
                param = new SqlParameter("@pId", pId);
                comd.Parameters.Add(param);
                param = new SqlParameter("@sId", sId);
                comd.Parameters.Add(param);
                using (SqlDataReader reader = comd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        item.unitPrice = reader.GetDecimal(0);
                    }
                }
            }
            
        }
        return item.unitPrice;
    }

    public int CreateOrder (int customerId, int storeId)
    {
        int custId = customerId;
        int stId = storeId;
        using(SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            string insertstatement = "INSERT INTO Order (storeId, customerId) VALUES (@sId, @cId)";
            string querystatement = "SELECT TOP 1 orderId FROM Order ORDER BY orderId DESC";
            using(SqlCommand comd = new SqlCommand(insertstatement, conn))
            {
                SqlParameter param;
                param = new SqlParameter ("@sId", stId);
                comd.Parameters.Add(param);
                param = new SqlParameter ("@cId", custId);
                comd.Parameters.Add (param);
                comd.ExecuteNonQuery();
            }
            using (SqlCommand comd = new SqlCommand(querystatement, conn))
            {
                using (SqlDataReader reader  = comd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        order.orderId = reader.GetInt32(0);
                    }
                }
            }
            conn.Close();
        }
        return order.orderId;
    }

    public void Checkout (int oId, List<OrderItem> cart)
    {
        cartItems = cart;
        int _oId = oId;
        
        using(SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            string insertstatement = "INSERT INTO OrderItem (orderId, productId, customerId, storeId, unit_price, quantity) VALUES (@oId, @pId, @cId, @sId, @price, @qty)";
            using(SqlCommand comd = new SqlCommand (insertstatement, conn))
            {
                SqlParameter param;
                foreach(OrderItem item in cartItems)
                {
                    param = new SqlParameter("@oId", _oId);
                    comd.Parameters.Add(param);
                    param = new SqlParameter("@pId", item.proId);
                    comd.Parameters.Add(param);
                    param = new SqlParameter("@cId", item.customerId);
                    comd.Parameters.Add(param);
                    param = new SqlParameter("@sId", item.storeId);
                    comd.Parameters.Add(param);
                    param = new SqlParameter("@price", item.unitPrice);
                    comd.Parameters.Add(param);
                    param = new SqlParameter("@qty", item.quantity);
                    comd.Parameters.Add(param);
                    comd.ExecuteNonQuery();
                }
                
            }
            conn.Close();
        }
    }
    public bool CheckExistCustomer(Customer cust)
    {
        customer = cust;
        using(SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            string searchstatement = "SELECT * FROM Customer WHERE Email = @email";
            using(SqlCommand comd = new SqlCommand(searchstatement, conn))
            {
                SqlParameter param;
                param = new SqlParameter("@email", customer.email);
                comd.Parameters.Add(param);
                using(SqlDataReader reader = comd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        duplicate = true;
                    }
                }
            }
            conn.Close();
          
        }
        return duplicate;
    }

    public void CreateCustomer (Customer cust)
    {
        customer = cust;
        using(SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            string insertstatement = $"INSERT INTO CUSTOMER (firstName, lastName, Street, Apt, City, State_Province, Zip, Email, Pass)  VALUES (@fname, @lname, @street, @apt, @city, @state, @zip, @email, @password)";
            using(SqlCommand comd = new SqlCommand(insertstatement, conn))
            {
                SqlParameter param;
                param = new SqlParameter("@fname", customer.firstName);
                comd.Parameters.Add(param);
                param = new SqlParameter("@lname", customer.lastName);
                comd.Parameters.Add(param);
                param = new SqlParameter("@street", customer.streetNumber);
                comd.Parameters.Add(param);
                param = new SqlParameter("@apt", customer.apt);
                comd.Parameters.Add(param);
                param = new SqlParameter("@city", customer.city);
                comd.Parameters.Add(param);
                param = new SqlParameter("@state", customer.state);
                comd.Parameters.Add(param);
                param = new SqlParameter("@zip", customer.zip);
                comd.Parameters.Add(param);
                param = new SqlParameter("@email", customer.email);
                comd.Parameters.Add(param);
                param = new SqlParameter("@password", customer.password);
                comd.Parameters.Add(param);

                comd.ExecuteNonQuery();
            }
            conn.Close();
            success = true;
        }
    }
}