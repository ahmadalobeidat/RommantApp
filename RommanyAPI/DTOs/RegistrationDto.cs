namespace RommanyAPI;

public class RegistrationDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate {get; set;}
    public string Email { get; set; }

    public string Password { get; set; }
}
