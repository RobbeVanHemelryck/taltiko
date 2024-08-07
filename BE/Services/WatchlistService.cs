// using Grpc.Core;
// using Watchlists;
//
// namespace BE.Services;
//
// public class WatchlistService : Watchlists.Watchlists.WatchlistsBase
// {
//     private readonly TaltikoContext _context;
//
//     public WatchlistService(TaltikoContext context)
//     {
//         _context = context;
//     }
//     public override Task<GetReply> Get(GetRequest request, ServerCallContext context)
//     {
//         var lists = _context.Watchlists
//             .ToList()
//             .Select(x => new Watchlist
//             {
//                 Id = x.Id,
//                 Description = x.Description,
//                 Name = x.Name,
//                 Movies = { x.Movies?.Select(y => new Movie
//                 {
//                     Id = y.Id,
//                     Description = y.Description,
//                     ImdbId = y.ImdbId,
//                     ImgUrl = y.ImgUrl,
//                     Name = y.Name,
//                     Year = y.Year
//                 }).ToList() }
//             });
//         return Task.FromResult(new GetReply
//         {
//             Watchlists = { lists }
//         });
//     }
// }