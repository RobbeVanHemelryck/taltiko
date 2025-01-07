using System.Text.Json;
using Grpc.Core;
using Microsoft.AspNetCore.WebUtilities;
using Movies;

namespace BE.Services;

public class MovieService : Movies.Movies.MoviesBase
{
    private HttpClient _client;
    public MovieService(IHttpClientFactory factory)
    {
        _client = factory.CreateClient("Movies");
    }

    public override async Task<SearchReply> Search(SearchRequest request, ServerCallContext context)
    {
        var searchEndpoint = @"/title/find";
        var query = QueryHelpers.AddQueryString(searchEndpoint, "q", request.Query);

        using var response = await _client.GetAsync(query);
        var body = await response.Content.ReadAsStringAsync();

        var root = JsonSerializer.Deserialize<Root>(body);

        var movies = root!.Data.MainSearch.Edges
            .Select(x => new Movie
            {
                Name = x.Node.Title.TitleText.Text ?? string.Empty,
                Year = x.Node.Title.ReleaseYear.Year,
                ImgUrl = x.Node.Title.PrimaryImage.Url
            })
            .ToList();

        var reply = new SearchReply
        {
            Movies = { movies }
        };
        return reply;
    }
}