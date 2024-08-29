
using BE.Domain.Diaries;
using Diaries;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;

namespace BE.Services;

public class DiaryService : Diaries.Diaries.DiariesBase
{
    private readonly TaltikoContext _context;

    public DiaryService(TaltikoContext context)
    {
        _context = context;
    }

    public override async Task<DiaryResponse> CreateDiary(CreateDiaryRequest request, ServerCallContext context)
    {
        var diary = Diary.Create();
        _context.Diaries.Add(diary);

        await _context.SaveChangesAsync();
        return new DiaryResponse
        {
            Id = diary.Id,
            Entries = { diary.Entries.Select(x => new EntryResponse { Id = x.Id, Date = x.Date.ToTimestamp(), Value = x.Value.Value }) }
        };
    }

    public override async Task<DiaryResponse> RetrieveDiary(RetrieveDiaryRequest request, ServerCallContext context)
    {
        var diary = await GetDiaryQuery.SingleAsync(x => x.Id == request.DiaryId);
        return new DiaryResponse
        {
            Id = diary.Id,
            Entries = { diary.Entries.Select(x => new EntryResponse { Id = x.Id, Date = x.Date.ToTimestamp(), Value = x.Value.Value }) }
        };
    }

    public override async Task<EntryResponse> CreateEntry(CreateEntryRequest request, ServerCallContext context)
    {
        var entry = Entry.Create(EntryValue.From(request.Value), request.Date.ToDateTime(), Mood.Cava);

        var diary = await GetDiaryQuery.SingleAsync(x => x.Id == request.DiaryId);
        diary.Entries.Add(entry);

        await _context.SaveChangesAsync();
        return new EntryResponse { Id = entry.Id, Date = entry.Date.ToTimestamp(), Value = entry.Value.Value };
    }

    private IQueryable<Diary> GetDiaryQuery
        => _context.Diaries.Include(x => x.Entries);
}