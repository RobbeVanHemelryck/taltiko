// using System.Text.Json;
// using Grpc.Core;
// using Microsoft.AspNetCore.WebUtilities;
// using Movies;
//
// namespace BE.Services;
//
// public class MovieService : Movies.Movies.MoviesBase
// {
//     private readonly HttpClient _httpClient;
//
//     public MovieService(IHttpClientFactory httpClientFactory)
//     {
//         _httpClient = httpClientFactory.CreateClient("Movies");
//     }
//
//     public override async Task<SearchReply> Search(SearchRequest request, ServerCallContext context)
//     {
//         var searchEndpoint = @"/title/find";
//         var query = QueryHelpers.AddQueryString(searchEndpoint, "q", request.Query);
//
//         using var response = await _httpClient.GetAsync(query);
//         var body = await response.Content.ReadAsStringAsync();
//
//         var root = JsonSerializer.Deserialize<Root>(body);
//
//         var movies = root!.results
//             .Select(x => new Movie
//             {
//                 Name = x.title ?? string.Empty,
//                 Year = x.year,
//                 ImgUrl = x.image?.url ?? string.Empty
//             })
//             .ToList();
//
//         var reply = new SearchReply
//         {
//             Movies = { movies }
//         };
//         return reply;
//     }
// }