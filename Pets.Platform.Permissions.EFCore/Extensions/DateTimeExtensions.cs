namespace Pets.Platform.Permissions.EFCore.Extensions;

public static class DateTimeExtensions
{
    public static DateTime ConvertToUtc(this DateTime date)
    {
        if (date.Kind == DateTimeKind.Utc)
        {
            return date;
        }
        else
        {
            return new DateTime(date.Ticks, DateTimeKind.Utc);
        }
    }

    public static DateTime? ConvertToUtc(this DateTime? date)
    {
        if (date.HasValue)
        {
            if (date.Value.Kind == DateTimeKind.Utc)
            {
                return date;
            }
            else
            {
                return new DateTime(date.Value.Ticks, DateTimeKind.Utc);
            }
        }
        else
        {
            return default(DateTime?);
        }
    }

    public static bool ElapsedMinutes(this DateTime date, double minutes)
    {
        var timespan = DateTime.UtcNow - date;

        return timespan.TotalMinutes >= minutes;
    }
}