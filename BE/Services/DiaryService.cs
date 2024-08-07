
using BE.Domain.Diaries;
using Diaries;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

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
            Entries = { diary.Entries.Select(x => new EntryResponse { Id = x.Id, Date = Timestamp.FromDateTime(x.Date), Value = x.Value.Value }) }
        };
    }
}