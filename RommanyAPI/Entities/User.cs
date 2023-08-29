namespace RommanyAPI;

public class User: IEntity
{
    public User(string firstName, string lastName, string email,DateTime birthdate )
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Birthdate = birthdate;
    }
public int Id { get; set; }
public string FirstName { get; private set; }
public string LastName { get; private set; }
public DateTime Birthdate{ get; private set;}
public string Email { get;private set;}

//public Attachment? profilePicture { get; set; }
//public Gender? GenderId{ get; set; }
public int? Age { get; set; }
public int? MobileNumber { get; set; }

}
