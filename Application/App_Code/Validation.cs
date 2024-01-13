using System.Text.RegularExpressions;

public class Validation
{
    /** Alpabet **/
    public static string RegexAlphabetic
    {
        get { return @"^[a-zA-Z" + Maintenance.allowed_special_characters_application + "]*$"; }
    }
    public static bool IsValidAlphabetic(string input)
    {
        return Regex.IsMatch(input, @"^[a-zA-Z" + Maintenance.allowed_special_characters_application + "]*$");
    }
    public static string ErrorMessageAlphabetic
    {
        get { return "May contain alphabetic characters and the <kbd>" + Maintenance.allowed_special_characters_application.Replace(@"\", "") + "</kbd> special characters only."; }
    }

    public static string RegexAlphabeticWithSpace
    {
        get { return @"^[a-zA-Z\s" + Maintenance.allowed_special_characters_application + "]*$"; }
    }
    public static bool IsValidAlphabeticWithSpace(string input)
    {
        return Regex.IsMatch(input, @"^[a-zA-Z\s" + Maintenance.allowed_special_characters_application + "]*$");
    }
    public static string ErrorMessageAlphabeticWithSpace
    {
        get { return "May contain alphabetic characters, spaces, and the <kbd>" + Maintenance.allowed_special_characters_application.Replace(@"\", "") + "</kbd> special characters only."; }
    }

    /** Alphanumeric **/
    public static string RegexAlphanumeric
    {
        get { return @"^[a-zA-Z0-9" + Maintenance.allowed_special_characters_application + "]*$"; }
    }
    public static bool IsValidAlphanumeric(string input)
    {
        return Regex.IsMatch(input, @"^[a-zA-Z0-9" + Maintenance.allowed_special_characters_application + "]*$");
    }
    public static string ErrorMessageAlphanumeric
    {
        get { return "May contain alphanumeric characters and the <kbd>" + Maintenance.allowed_special_characters_application.Replace(@"\", "") + "</kbd> special characters only."; }
    }

    public static string RegexAlphanumericWithSpace
    {
        get { return @"^[a-zA-Z0-9\s" + Maintenance.allowed_special_characters_application + "]*$"; }
    }
    public static bool IsValidAlphanumericWithSpace(string input)
    {
        return Regex.IsMatch(input, @"^[a-zA-Z0-9\s" + Maintenance.allowed_special_characters_application + "]*$");
    }
    public static string ErrorMessageAlphanumericWithSpace
    {
        get { return "May contain alphanumeric characters, spaces, and the <kbd>" + Maintenance.allowed_special_characters_application.Replace(@"\", "") + "</kbd> special characters only."; }
    }

    /** Numeric **/
    public static bool IsValidInteger(string input)
    {
        return Regex.IsMatch(input, @"^-?\d+$");
    }

    public static bool IsValidNonNegativeInteger(string input)
    {
        return Regex.IsMatch(input, @"^\d+$");
    }

    public static bool IsValidPositiveInteger(string input)
    {
        return Regex.IsMatch(input, @"^[1-9]\d*$");
    }

    public static bool IsValidDecimal(string input)
    {
        return Regex.IsMatch(input, @"^-?\d*\.{0,1}\d+$");
    }

    public static bool IsValidCommaSeparatedDecimal(string input)
    {
        return Regex.IsMatch(input, @"(\$?[+-]?\d{1,3}(\,\d{3})*%?(\.\d+)?)");
    }

    public static bool IsValidIntegerOrDecimal(string input)
    {
        return Regex.IsMatch(input, @"^[0-9]\d*(\.\d+)?$");
    }

    /** Date and Time **/
    public static bool IsValidDate(string input)
    {
        /* MM/DD/YYYY */
        return Regex.IsMatch(input, @"^\d{2}\/\d{2}\/\d{4}$");
    }

    public static bool IsValidYear(string input)
    {
        return Regex.IsMatch(input, @"^\d{4,4}$");
    }

    public static bool IsValidTime(string input)
    {
        /* HH:MM:SS */
        return Regex.IsMatch(input, @"^([0-1][0-9]|[2][0-3]):([0-5][0-9]):([0-5][0-9])$");
    }

    /** Contact Details **/
    public static bool IsValidEmail(string input)
    {
        return Regex.IsMatch(input, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
    }

    public static bool IsValidTelephoneNumber(string input)
    {
        /* At least 7 digits */
        return Regex.IsMatch(input, @"^(\(?\+?[0-9]*\)?)?[0-9_\- \(\)]{7,}$");
    }

    public static bool IsValidMobileNumber(string input)
    {
        return Regex.IsMatch(input, @"(\+?\d{2}?\s?\d{3}\s?\d{3}\s?\d{4})|([0]\d{3}\s?\d{3}\s?\d{4})");
    }

    public static bool IsValidUrl(string input)
    {
        return Regex.IsMatch(input, @"^((https?|ftp|smtp):\/\/)?(www.)?[a-z0-9]+\.[a-z]+(\/[a-zA-Z0-9#]+\/?)*$");
    }

    public static bool IsValidCompleteUrl(string input)
    {
        return Regex.IsMatch(input, @"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)");
    }

    /** Special **/
    public static bool IsValidPasswordLength(string input)
    {
        return Regex.IsMatch(input, @"^(?:[1-9]|[1-4][0-9]|50)$");
    }

    public static bool IsValidSpecialCharacter(string input)
    {
        return Regex.IsMatch(input, @"[^\w\s]+$");
    }

    public static bool IsValidTin(string input)
    {
        return Regex.IsMatch(input, @"^[0-9]{9,12}$");
    }

    public static bool IsValidEmployeeNumber(string input)
    {
        return Regex.IsMatch(input, @"^[0-9]{4,}$");
    }
}