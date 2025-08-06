namespace BE.Domain.Life;

public class CategoryEntries
{
    public int Id { get; set; }
    public int Order { get; set; }
    public required int CategoryId { get; set; }
    public required List<Entry> Entries { get; set; }
}