namespace BE.Domain.Life;

public class Character
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public List<CategoryEntries>? CategoryEntries { get; set; }
}