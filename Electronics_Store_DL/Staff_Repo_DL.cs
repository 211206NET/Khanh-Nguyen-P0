using Models;
using Microsoft.Data.SqlClient;
namespace RepoDL;

public class Staff_Repo
{
    public bool duplicate = false;
    public bool success = false;
    
    private string _connectionString;

    public Staff_Repo ()
    {
        _connectionString = File.ReadAllText("Connection.txt");
    }

    public int SignIn (Staff staff)
    {
        string _email;
        string _password;
        using(SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            string querystatement = "SELECT StaffId, Email, Pass FROM Staff WHERE Email = @email AND Pass = @pass";
            
                using(SqlCommand comd = new SqlCommand(querystatement, conn))
                {
                    SqlParameter param;
                    param = new SqlParameter("@email", staff.email);
                    comd.Parameters.Add(param);
                    param = new SqlParameter("@pass", staff.password);
                    comd.Parameters.Add(param);
                    using (SqlDataReader reader = comd.ExecuteReader())
                    {
                        if(reader.Read ())
                        {
                            _email = reader.GetString(1);
                            _password = reader.GetString(2);
                            if (staff.email == _email  && staff.password == _password)
                            {
                                Current_User.User_Id = reader.GetInt32(0);
                                Console.WriteLine ("Sign In Successfully");
                            }
                        }
                        else
                            Console.WriteLine ("Invalid Email or Password");
                    }
                }
                conn.Close ();
        }
            
            return Current_User.User_Id;
    }

    public List<Store> GetAllStores ()
    {
        List<Store> storeList = new List<Store> ();
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
                        Store store = new Store ();
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

    public List<Inventory> GetInventoryByStoreId ()
    {
        List<Inventory> storeInventoryList = new List<Inventory> ();
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            String queryString = "SELECT * FROM Inventory WHERE storeID = @storeId";
            using (SqlCommand comd = new SqlCommand(queryString, conn))
            {
                SqlParameter param;
                param = new SqlParameter("@storeId", Current_User.store_Id);
                comd.Parameters.Add(param);
                using (SqlDataReader reader = comd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Inventory item = new Inventory ();
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

     public List<Inventory> GetAllInventory ()
    {
         List <Inventory> allInventoryList = new List<Inventory> ();
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            String queryString = "SELECT * FROM Inventory";
            using (SqlCommand comd = new SqlCommand(queryString, conn))
            {
                using (SqlDataReader reader = comd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Inventory item = new Inventory ();
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
                comd.Parameters.Add(param);
                param = new SqlParameter("@pId", _pId);
                comd.Parameters.Add(param);
                param = new SqlParameter("@sId", _sId);
                comd.Parameters.Add(param);
                comd.ExecuteNonQuery();  
            }
            conn.Close();
        }
    }

    public bool CheckExistStaff(Staff emp)
    {
        Staff staff = new Staff ();
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

    public void NewEmployee (Staff emp)
    {
        Staff staff = new Staff ();
        staff = emp;
        using(SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            string insertstatement = "INSERT INTO Staff (firstName, lastName, Street, Apt, City, State_Province, Zip, staff_role, Email, Pass)  VALUES (@fname, @lname, @street, @apt, @city, @state, @zip, @role, @email, @password)";
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
                param = new SqlParameter("@role", staff.role);
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