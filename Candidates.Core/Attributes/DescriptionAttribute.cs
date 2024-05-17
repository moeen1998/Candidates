using System.Reflection;

namespace Candidates.Core.Attributes;

[AttributeUsage(AttributeTargets.All)]
public class DescriptionAttribute : Attribute
{
    public string Description { get; set; }
    public DescriptionAttribute(string description)
    {
        Description = description;
    }

    public static string GetDescription(object obj)
    {
        Type? type = obj?.GetType();

        MemberInfo? member = type?.GetMember(obj.ToString()).FirstOrDefault();

        DescriptionAttribute? attribute = 
            (DescriptionAttribute?)
            member?.GetCustomAttributes(typeof(DescriptionAttribute), false)
            .FirstOrDefault();

        string description = attribute?.Description ?? "NO DESCRIPTION AVAILABLE";

        return description;
    }
}
