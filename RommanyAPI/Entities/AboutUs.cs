namespace RommanyAPI;

public class AboutUs : IEntity
{
    public AboutUs(string description)
    {
        Description = description;
    }
    public int Id { get; set; }
    public string Description { get; private set; }
}
