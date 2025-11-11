namespace Core;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    
    public string Role { get; set; } = "none";
    
    public string Password { get; set; } = String.Empty;
    
    public string Email { get; set; } = String.Empty;
    
    public string Adress { get; set; } = String.Empty;
    
    public string Phone { get; set; } = String.Empty;
    
}