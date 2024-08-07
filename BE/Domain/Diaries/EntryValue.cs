namespace BE.Domain.Diaries;

public class EntryValue
{
    public string Value { get; private set; }

    public static EntryValue From(string value)
    {
        return new EntryValue(value);
    }
    
    private EntryValue(string value)
    {
        Value = value;
    }
}