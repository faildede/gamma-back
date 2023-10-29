using System.ComponentModel.DataAnnotations.Schema;

namespace todogamma.Models;

[Table("Admin")]
public class Admin 
{
    public int AdminId {get; set;}
    public string Name {get; set;} = string.Empty;
}