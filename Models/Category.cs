


namespace todogamma.Models;
public class Category {
    public int Id {get; set;}
   public string Title {get; set;} = string.Empty;
    public List<Device> Devices {get; set;}

    public Category()
    {
        Devices =new List<Device>();
    }
}
