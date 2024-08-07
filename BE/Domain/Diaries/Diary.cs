namespace BE.Domain.Diaries;

public class Diary
{
    public int Id { get; private set; }
    public List<Entry> Entries { get; private set; } = new ();

    public static Diary Create()
    {
        return new Diary();
    }
}