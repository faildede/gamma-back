using System.ComponentModel.DataAnnotations;


namespace todogamma.Models;

public class Device : IEntity 
{
 	    public int Id { get; set; } 
		[Required]
		public string Title { get; set; } = string.Empty;
		[Required]
		public string Manufacturer { get; set; } = string.Empty;
		public string Img { get; set; } = string.Empty;
		public int? CategoryId {get; set;}
		[Required]
		public int Price { get; set; }
		public string Description { get; set; } = string.Empty;
        public Category? Category {get; set; }

   
}

	
