namespace CtrlLove.Models.DTOs;

public class LoginCredentialsDTO
{
    public string Email { get; set; }
    public string Password { get; set; }

    public LoginCredentialsDTO(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public override string ToString()
    {
        return $"LoginCredentialsDTO:{{ Email: {Email}, Password: {Password} }}";
    }
}