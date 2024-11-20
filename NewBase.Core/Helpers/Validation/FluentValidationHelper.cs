using NewBase.Core.Enums;
using NewBase.Core.Helpers.Localization;
using System.ComponentModel;
using System.Linq;

namespace NewBase.Core.Helpers.Validation
{
    public static class FluentValidationHelper
    {
        public static string Message<T>(Language lang, string localizationPath, string propName, ValidationTypesEnum type, params object[] inputs)
        {
            var propDescription = GetDisplayName<T>(propName, lang);
            var messageInputs = AppendToParams(propDescription, inputs);
            return LocalizerHelper.LocalizeValidation(type.ToString(), lang, localizationPath, messageInputs);
        }

        public static string GetDisplayName<T>(string propName, Language lang)
        {
            if (lang == Language.En)
                return propName;

            var propertyAttribute = typeof(T).GetMember(propName)[0].GetCustomAttributes(typeof(DisplayNameAttribute), inherit: false);

            if (!propertyAttribute.Any())
                return propName;

            var descriptionAttribute = propertyAttribute[0] as DisplayNameAttribute;

            return descriptionAttribute.DisplayName;
        }

        public static T[] AppendToParams<T>(T first, params T[] items)
        {
            T[] result = new T[items.Length + 1];

            result[0] = first;

            items.CopyTo(result, 1);

            return result;
        }
    }
}
