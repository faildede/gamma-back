using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace todogamma.Models;

[Table("Device")]
public class Device
{
 	    public int Id { get; set; } 
		public string Title { get; set; } = string.Empty;
		public string Manufacturer { get; set; } = string.Empty;
		public string Img { get; set; }
		public int CategoryID {get; set;}
		public int Price { get; set; }
		public string Description { get; set; }
        
}
