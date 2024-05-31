using Flunt.Notifications;
using Microsoft.AspNetCore.Identity;

namespace OrderAPI.Endpoints;

public static class ProblemaDetailExtensions
{
    public static Dictionary<string, string[]> ConvertToProblemaDetails(this IReadOnlyCollection<Notification> notifications)
    {
        return notifications.GroupBy(g => g.Key)
            .ToDictionary(g => g.Key, g => g.Select(m => m.Message).ToArray());
    }
    public static Dictionary<string, string[]> ConvertToProblemaDetails(this IEnumerable<IdentityError> error)
    {
        var dictionary = new Dictionary<string, string[]>();
        dictionary.Add("Error", error.Select(e => e.Description).ToArray());
        return dictionary;
    }
}
