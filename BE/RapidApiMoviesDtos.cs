// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);

#nullable disable
using System.Text.Json.Serialization;

public class Attribute
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }
    }

    public class Category
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public class Category2
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }
    }

    public class Character
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class Country
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }

    public class Credit
    {
        [JsonPropertyName("__typename")]
        public string Typename { get; set; }

        [JsonPropertyName("category")]
        public Category Category { get; set; }

        [JsonPropertyName("characters")]
        public List<Character> Characters { get; set; }
    }

    public class Data
    {
        [JsonPropertyName("mainSearch")]
        public MainSearch MainSearch { get; set; }
    }

    public class DisplayableProperty
    {
        [JsonPropertyName("qualifiersInMarkdownList")]
        public object QualifiersInMarkdownList { get; set; }

        [JsonPropertyName("value")]
        public Value Value { get; set; }
    }

    public class Edge
    {
        [JsonPropertyName("node")]
        public Node Node { get; set; }
    }

    public class Entity
    {
        [JsonPropertyName("__typename")]
        public string Typename { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("nameText")]
        public NameText NameText { get; set; }

        [JsonPropertyName("primaryImage")]
        public PrimaryImage PrimaryImage { get; set; }

        [JsonPropertyName("knownFor")]
        public KnownFor KnownFor { get; set; }
    }

    public class KnownFor
    {
        [JsonPropertyName("edges")]
        public List<Edge> Edges { get; set; }
    }

    public class MainSearch
    {
        [JsonPropertyName("edges")]
        public List<Edge> Edges { get; set; }
    }

    public class NameText
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }

    public class Node
    {
        [JsonPropertyName("entity")]
        public Entity Entity { get; set; }

        [JsonPropertyName("title")]
        public Title Title { get; set; }

        [JsonPropertyName("credit")]
        public Credit Credit { get; set; }
    }

    public class OriginalTitleText
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("isOriginalTitle")]
        public bool IsOriginalTitle { get; set; }
    }

    public class PrimaryImage
    {
        [JsonPropertyName("__typename")]
        public string Typename { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("width")]
        public int Width { get; set; }
    }

    public class RatingsSummary
    {
        [JsonPropertyName("aggregateRating")]
        public double? AggregateRating { get; set; }
    }

    public class ReleaseDate
    {
        [JsonPropertyName("__typename")]
        public string Typename { get; set; }

        [JsonPropertyName("month")]
        public int Month { get; set; }

        [JsonPropertyName("day")]
        public int Day { get; set; }

        [JsonPropertyName("year")]
        public int Year { get; set; }

        [JsonPropertyName("country")]
        public Country Country { get; set; }

        [JsonPropertyName("restriction")]
        public object Restriction { get; set; }

        [JsonPropertyName("attributes")]
        public List<Attribute> Attributes { get; set; }

        [JsonPropertyName("displayableProperty")]
        public DisplayableProperty DisplayableProperty { get; set; }
    }

    public class ReleaseYear
    {
        [JsonPropertyName("__typename")]
        public string Typename { get; set; }

        [JsonPropertyName("year")]
        public int Year { get; set; }

        [JsonPropertyName("endYear")]
        public int? EndYear { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("data")]
        public Data Data { get; set; }
    }

    public class Title
    {
        [JsonPropertyName("__typename")]
        public string Typename { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("titleText")]
        public TitleText TitleText { get; set; }

        [JsonPropertyName("originalTitleText")]
        public OriginalTitleText OriginalTitleText { get; set; }

        [JsonPropertyName("releaseYear")]
        public ReleaseYear ReleaseYear { get; set; }

        [JsonPropertyName("releaseDate")]
        public ReleaseDate ReleaseDate { get; set; }

        [JsonPropertyName("titleType")]
        public TitleType TitleType { get; set; }

        [JsonPropertyName("primaryImage")]
        public PrimaryImage PrimaryImage { get; set; }

        [JsonPropertyName("ratingsSummary")]
        public RatingsSummary RatingsSummary { get; set; }
    }

    public class TitleText
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("isOriginalTitle")]
        public bool IsOriginalTitle { get; set; }
    }

    public class TitleType
    {
        [JsonPropertyName("__typename")]
        public string Typename { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("categories")]
        public List<Category> Categories { get; set; }

        [JsonPropertyName("canHaveEpisodes")]
        public bool CanHaveEpisodes { get; set; }

        [JsonPropertyName("isEpisode")]
        public bool IsEpisode { get; set; }

        [JsonPropertyName("isSeries")]
        public bool IsSeries { get; set; }

        [JsonPropertyName("displayableProperty")]
        public DisplayableProperty DisplayableProperty { get; set; }
    }

    public class Value
    {
        [JsonPropertyName("plainText")]
        public string PlainText { get; set; }
    }

