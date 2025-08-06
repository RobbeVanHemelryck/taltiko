namespace BE.Domain.Life;

public class Entry
{
    public int Id { get; set; }
    public int Order { get; set; }
    public EntryDate? Date { get; set; }
    public required string Value { get; set; }
}