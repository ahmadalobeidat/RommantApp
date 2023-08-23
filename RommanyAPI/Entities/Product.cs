namespace RommanyAPI;

public class Product
{
    public Product(string name , string description , decimal price )
    {
        Name = name;
        Description = description;   
        Price = price;
    }
public int Id { get; set; }
public string Name { get;private set; }
public string Description { get;private set; }
public decimal Price { get;  private set; }
public List<Attachment>? Images {get;private set;} 
}
