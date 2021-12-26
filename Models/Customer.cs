namespace Models;
public class Customer
{
    private int _customerId;
    public int Cid
    {
        get => _customerId;
        set => _customerId = value;
    }
    
    private String _lastName { get; set; }

    private String _firstName { get; set; }

    private String _streetNumber { get; set; }

    private String _city { get; set; }

    private String _state { get; set; }

    private String _zipcode { get; set; }

    private String _email { get; set; }

    private String _password { get; set; }
    
}
