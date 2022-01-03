namespace Models;
public class Staff
{
    private int _staffId;
    public int staffId
    {
        get => _staffId;
        set => _staffId = value;
    }
    
    private String _firstName;
    public String firstName
    { 
        get => _firstName; 
        set => _firstName = value; 
    }

    private String _lastName;
    public String lastName
    {
        get => _lastName;
        set => _lastName = value;
    }
    
    private String _streetNumber;
    public String streetNumber
    { 
        get => _streetNumber; 
        set => _streetNumber = value; 
    }

    private String _city;
    public String city
    { 
        get => _city; 
        set => _city = value; 
    }

    private String _state;
    public String state
    { 
        get => _state; 
        set => _state = value; 
    }

    private String _zip;
    public String zip
    { 
        get => _zip; 
        set => _zip = value; 
    }

    private String _role;
    public String role
    {
        get => _role;
        set => _role = value;
    }
    private String _email;
    public String email
    {
        get => _email;
        set => _email = value;
    }

    private String _password
    public String password
    {
        get => _password;
        set => _password = value;
    }
}