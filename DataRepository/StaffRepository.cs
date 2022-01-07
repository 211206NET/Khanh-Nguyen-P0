using Models;
using Microsoft.Data.SqlClient;
namespace DataRepository;

public class StaffRepository : DataRepositoryInterface
{
    public bool isSignedIn;
    public bool success = false;
    public bool duplicate = false;
    private string _connectionString;
    Staff staff = new Staff();
    Store store = new Store ();
    Inventory item = new Inventory ();
    List <Inventory> allInventoryList = new List<Inventory> ();
    List<Inventory> storeInventoryList = new List<Inventory> ();
    List<Store> storeList = new List<Store> ();

    public StaffRepository ()
    {
        _connectionString = File.ReadAllText("Connection.txt");
    }

    public int SignIn (string email, string pass)
    {
        string _eml = email;
        string _pwd = pass;
        
        using(SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            string querystatement = "SELECT StaffId, Email, Pass FROM Staff";
            using(SqlCommand comd = new SqlCommand(querystatement, conn))
            {
                using (SqlDataReader reader = comd.ExecuteReader())
                {
                    while(reader.Read ())
                    {
                        staff.staffId = reader.GetInt32(0);
                        staff.email = reader.GetString(1);
                        staff.password = reader.GetString(2);
                        if (_eml == staff.email  && _pwd == staff.password)
                        {
                            Console.WriteLine ("Sign In Successfully");
                        }
                        else
                            Console.WriteLine ("Invalid Email or Password");
                    }
                }
            }
            conn.Close();
        }
            return staff.staffId;
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
            conn.Close();
        }
        return storeList;
    }

    public List<Inventory> GetInventoryByStoreId (int stId)
    {
        int _storeId = stId;
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            String queryString = "SELECT * FROM Iventory WHERE storeID = @storeId";
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
                        storeInventoryList.Add(item);
                    }
                }
            }
            
        }
        return storeInventoryList;
    }

    public void Replenishment (int qty, int pId, int sId)
    {
        int _qty = qty;
        int _pId = pId;
        int _sId = sId;
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            String updateString = "UPDATE Iventory SET quantity = @qty WHERE productId = @pId AND storeId = @sId";
            using (SqlCommand comd = new SqlCommand(updateString, conn))
            {
                SqlParameter param;
                param = new SqlParameter("@qty", _qty);
                param = new SqlParameter("@pId", _pId);
                param = new SqlParameter("@sId", _sId);
                comd.Parameters.Add(param);
                comd.ExecuteNonQuery();  
            }
            conn.Close();
        }
    }
    

    public List<Inventory> GetAllInventory ()
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            String queryString = "SELECT * FROM Iventory";
            using (SqlCommand comd = new SqlCommand(queryString, conn))
            {
                using (SqlDataReader reader = comd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        item.storeId = reader.GetInt32(0);
                        item.productId = reader.GetInt32(1);
                        item.productName = reader.GetString(2);
                        item.quantity = reader.GetInt32(3);
                        allInventoryList.Add(item);
                    }
                }
            }
        }
        return allInventoryList;
    }

    public bool CheckExistCustomer(Staff emp)
    {
        staff = emp;
        using(SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            string searchstatement = "SELECT * FROM Staff WHERE Email = @email";
            using(SqlCommand comd = new SqlCommand(searchstatement, conn))
            {
                SqlParameter param;
                param = new SqlParameter("@email", staff.email);
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

    public void CreateCustomer (Staff emp)
    {
        staff = emp;
        using(SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            string insertstatement = "INSERT INTO Staff (firstName, lastName, Street, Apt, City, State_Province, Zip, Email, Pass)  VALUES (@fname, @lname, @street, @apt, @city, @state, @zip, @email, @password)";
            using(SqlCommand comd = new SqlCommand(insertstatement, conn))
            {
                SqlParameter param;
                param = new SqlParameter("@fname", staff.firstName);
                comd.Parameters.Add(param);
                param = new SqlParameter("@lname", staff.lastName);
                comd.Parameters.Add(param);
                param = new SqlParameter("@street", staff.streetNumber);
                comd.Parameters.Add(param);
                param = new SqlParameter("@apt", staff.apt);
                comd.Parameters.Add(param);
                param = new SqlParameter("@city", staff.city);
                comd.Parameters.Add(param);
                param = new SqlParameter("@state", staff.state);
                comd.Parameters.Add(param);
                param = new SqlParameter("@zip", staff.zip);
                comd.Parameters.Add(param);
                param = new SqlParameter("@email", staff.email);
                comd.Parameters.Add(param);
                param = new SqlParameter("@password", staff.password);
                comd.Parameters.Add(param);

                comd.ExecuteNonQuery();
            }
            conn.Close();
            success = true;
        }
    }
}