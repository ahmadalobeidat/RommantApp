namespace RommanyAPI;

public class Achievement :IEntity
{
    public Achievement(string title, string description)
    {
        Title = title;
        Description = description;
    }
    public int Id { get; set; }
    public string Title { get;private set; }
    public string Description { get;private set; }
}
