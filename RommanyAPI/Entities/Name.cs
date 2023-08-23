namespace RommanyAPI;

public class Name
{
    public Name( string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    public int Id { get; set; }
    public string FirstName { get; private set; }
    public string? SecondName { get; private set; }
    public string? ThirdName { get;private  set; }
    public string LastName { get; private set; }
    public string? FullName { get =>  FirstName + " " + LastName ; private set{} }

}
