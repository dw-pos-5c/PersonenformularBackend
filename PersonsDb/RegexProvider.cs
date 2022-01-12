using System.Text.RegularExpressions;

namespace PersonsDb
{
    public static class RegexProvider
    {
        public const string firstname = @"^[A-Z]\w{2,}$";
        public const string lastname = @"^[A-Z]\w{2,}$";
        public const string date = @"^\d\d\.\d\d\.\d{4}$";
        public const string tel = @"^\+\d\d \(\d+\) \d{4,}$";
        public const string address = @"^(?<postal>[A-Z]{1,2}-\d{4})\s+(?<city>.+?),\s+(?<street>.+)$";
    }
}
