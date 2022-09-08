using System.Text;
using System.Text.RegularExpressions;

namespace CacheAside.Application.Providers
{
    public static class PhoneNumberProvider
    {
        private const string CLEAN_PHONENUMBER_PATTERN = "\\s|-|\\(|\\)";
        private const string GROUP_DDI = "ddi";
        private const string GROUP_NUMBER = "number";
        private const string GROUP_ENTIRE_NUMBER = "entireNumber";
        private const string NATIONAL_PHONENUMBER_PATTERN = @"^(?<ddi>\+?55)?(?<number>\d{10,11})$";
        private const char PLUS_CHAR = '+';
        public const string ERROR_INVALID_NUMBER_FORMAT = "this number {0} doesn't meet the minimum requirements for processing";

        public static string Add9Digit(this string phone)
        {
            if (phone.Length == 13)
                return phone;

            return phone.Substring(0, 4) + "9" + phone.Substring(4, 8);
        }

        public static string GetRandom(bool hasNineDigit = true)
        {
            Random rand = new Random();
            StringBuilder telNo = new StringBuilder(12);
            telNo = telNo.Append(getDDI());
            telNo = telNo.Append(getDDD(rand));
            telNo = telNo.Append(getFirstDigits(rand, hasNineDigit));
            telNo = telNo.Append(getLastDigits(rand));
            return telNo.ToString();
        }

        private static string getDDI(Random? rand = null)
        {
            return "55";
        }

        private static string getDDD(Random? rand = null)
        {
            const int INI_RANGE = 11;
            const int END_RANGE = 99;
            if (rand == null)
                rand = new Random();
            return rand.Next(INI_RANGE, END_RANGE).ToString();
        }

        private static string getFirstDigits(Random? rand = null, bool NineDigit = true)
        {
            const int INI_RANGE = 7001;
            const int END_RANGE = 9999;
            if (rand == null)
                rand = new Random();
            if (NineDigit)
                return "9" + rand.Next(INI_RANGE, END_RANGE).ToString();

            return rand.Next(INI_RANGE, END_RANGE).ToString();
        }

        private static string getLastDigits(Random? rand = null)
        {
            const int INI_RANGE = 0;
            const int END_RANGE = 9999;
            if (rand == null)
                rand = new Random();
            return rand.Next(INI_RANGE, END_RANGE).ToString().PadLeft(4,'0');
        }

       

    }
}
