using System;
using System.Net.Mail;

namespace AssociaServices.Utilities
{
    public static class ModelValidation
    {
        public static bool IsValidEmail(this string email)
        {
            try
            {
                var m = new MailAddress(email);
            }
            catch (FormatException)
            {
                return false;
            }
            return true;
        }

        public static bool IsValidDateTime(this string date)
        {
            try
            {
                var d = DateTimeOffset.Parse(date);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static Guid ParseToGuid(this string value)
        {
            try
            {
                return new Guid(value);
            }
            catch (Exception)
            {
                throw new InvalidCastException($"{value} is not a valid Guid");
            }
        }

        public static T ParseEnum<T>(T value, Type enumObj)
        {
            if (Enum.IsDefined(enumObj, value))
            {
                return value;
            }
            else
            {
                throw new InvalidCastException($"{value} is not a valid Type");
            }
        }
    }
}
