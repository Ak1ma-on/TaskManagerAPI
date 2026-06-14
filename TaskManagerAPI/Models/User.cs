public class User
{
    public int Id {get; set;}
    public string Username {get; set;}
    public string PasswordHash {get; set;}

    public User() { }

    public User(string username, string passwordhash)
    {
        Username = username;
        PasswordHash = passwordhash;
    }
}