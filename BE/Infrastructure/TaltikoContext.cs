using BE.Domain.Diaries;
using Microsoft.EntityFrameworkCore;

namespace BE;

public class TaltikoContext : Microsoft.EntityFrameworkCore.DbContext
{
    public TaltikoContext(DbContextOptions<TaltikoContext> options) : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.LogTo(Console.WriteLine);
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Diary
        modelBuilder.Entity<Diary>(x =>
        {
            x.ToTable("Diary");
            x.HasMany(x => x.Entries).WithOne();
        });
        
        modelBuilder.Entity<Entry>(x =>
        {
            x.ToTable("Entry");
            x.Property(x => x.Mood).HasColumnName("MoodCode");
            x.Property(x => x.Value).HasConversion(x => x.Value, x => EntryValue.From(x));
        });
    }

    public DbSet<Diary> Diaries { get; set; } = null!;
}