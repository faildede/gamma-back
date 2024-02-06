using System.Text.Json.Serialization;

namespace todogamma.Models;
public class Category : IEntity
 {
    public int Id {get; set;}
    
   public string Title {get; set;} = string.Empty;
   [JsonIgnore]
   public IEnumerable<Device> Devices {get; set; } = new List<Device>();
}
