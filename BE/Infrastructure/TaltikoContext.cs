using BE.Domain.Diaries;
using BE.Domain.Life;
using Microsoft.EntityFrameworkCore;
using Entry = BE.Domain.Diaries.Entry;

namespace BE;

public class TaltikoContext : Microsoft.EntityFrameworkCore.DbContext
{
    public TaltikoContext(DbContextOptions<TaltikoContext> options) : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.LogTo(Console.WriteLine);
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        //Diary
        builder.Entity<Diary>(x =>
        {
            x.ToTable("Diary");
            x.HasMany(x => x.Entries).WithOne();
        });
        
        builder.Entity<Entry>(x =>
        {
            x.ToTable("Entry");
            x.Property(x => x.Mood).HasColumnName("MoodCode");
            x.Property(x => x.Value).HasConversion(x => x.Value, x => EntryValue.From(x));
        });

        //Characters
        builder.Entity<CategoryEntries>(x =>
        {
            x.HasKey(x => x.Id);
            x.ToTable("CategoryEntries", "chars");
            x.HasOne<Domain.Life.Category>().WithOne().has
        });

        builder.Entity<Domain.Life.Entry>(x =>
        {
            x.HasKey(x => x.Id);
            x.ToTable("Entry", "chars");
            x.Property(x => x.Value).IsRequired();

            x.OwnsOne(x => x.Date);
        });

        builder.Entity<Domain.Life.Category>(x =>
        {
            x.HasKey(x => x.Id);
            x.ToTable("Category", "chars");
            x.Property(x => x.Name).IsRequired();
        });
    }

    public DbSet<Diary> Diaries { get; set; } = null!;
}