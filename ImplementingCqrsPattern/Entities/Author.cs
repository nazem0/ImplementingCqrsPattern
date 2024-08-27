using System.ComponentModel.DataAnnotations;
using ImplementingCqrsPattern.Entities.General;
namespace ImplementingCqrsPattern.Entities;
public class Author : AggregateRoot<int>
{
    public Author() { }
    public Author(string name)
    {
        Name = name;
    }
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
    public virtual ICollection<Book> Books { get; set; } = [];

}
