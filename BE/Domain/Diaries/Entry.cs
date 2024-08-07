namespace BE.Domain.Diaries;

public class Entry
{
    public int Id { get; set; }
    public EntryValue Value { get; private set; }
    public DateTime Date { get; private set; }
    public Mood Mood { get; private set; }

    public static Entry Create(EntryValue value, DateTime date, Mood mood)
    {
        return new Entry(value, date, mood);
    } 
    
    private Entry(EntryValue value, DateTime date, Mood mood)
    {
        Value = value;
        Date = date;
        Mood = mood;
    }
}