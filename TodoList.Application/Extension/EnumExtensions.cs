using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace TodoList.Application.Extension
{
    public static class EnumExtensions
    {
        public static string ToDisplayName(this Enum enumValue)
        {
            var type = enumValue.GetType();
            var stringValue = enumValue.ToString();

            var members = type.GetMember(stringValue).FirstOrDefault();
            if (members != null)
            {
                var attribute = members.GetCustomAttribute<DisplayAttribute>();
                if (attribute != null)
                {
                    return attribute.Name;
                }
            }

            return stringValue;
        }
    }
}
