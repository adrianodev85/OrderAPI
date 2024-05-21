using Flunt.Notifications;
using System.Runtime.CompilerServices;

namespace OrderAPI.Endpoints;

public static class ProblemaDetailExtensions
{
    public static Dictionary<string, string[]> ConvertToProblemaDetails(this IReadOnlyCollection<Notification> notifications)
    {
        return notifications.GroupBy(g => g.Key)
            .ToDictionary(g => g.Key, g => g.Select(m => m.Message).ToArray());
    }
}
