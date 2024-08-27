using System.ComponentModel.DataAnnotations;
using ImplementingCqrsPattern.Entities.General;
namespace ImplementingCqrsPattern.Entities;
public class Book : BaseEntity<int>
{
    public Book() { }
    public Book(string name, string iSBN, DateTime publishDate, int copies, float price, int authorId)
    {
        Name = name;
        ISBN = iSBN;
        PublishDate = publishDate;
        Copies = copies;
        Price = price;
        AuthorId = authorId;
    }
    [StringLength(300)]
    public string Name { get; internal set; }
    public string ISBN { get; internal set; }
    public DateTime PublishDate { get; set; }
    [Range(0, int.MaxValue)]
    public int Copies { get; private set; }
    [Range(float.NegativeZero, float.MaxValue)]
    public float Price { get; set; }
    public int AuthorId { get; set; }
    public virtual Author? Author { get; set; }
}
