using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace TodoList.Web.ExtensionMethods
{
    public static class StatusDisplay
    {
        public static string ToDisplayName(this Enum enumValue)
        {
            var type = enumValue.GetType();

            var members = type.GetMember(enumValue.ToString()).FirstOrDefault();
            if (members != null)
            {
                var attribute = members.GetCustomAttribute<DisplayAttribute>();
                if (attribute != null)
                {
                    return attribute.Name;
                }
            }

            return enumValue.ToString();
        }
    }
}
