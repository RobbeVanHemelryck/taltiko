using Google.Protobuf.WellKnownTypes;

namespace BE;

public static class Extensions
{
    public static Timestamp ToTimestamp(this DateTime dateTime)
        => Timestamp.FromDateTime(DateTime.SpecifyKind(dateTime, DateTimeKind.Utc));
}