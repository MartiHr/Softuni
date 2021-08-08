using System;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Models
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            var metadata = obj.GetType();

            var properties = metadata
                .GetProperties();

            foreach (PropertyInfo property in properties)
            {
                MyValidationAttribute customAttribute =
                    (MyValidationAttribute)property.GetCustomAttribute(typeof(MyValidationAttribute), false);

                bool isValid = customAttribute.IsValid(property.GetValue(obj));

                if (isValid == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
