using System.Text;

namespace CacheAside.Application.Providers
{
    public static class PhoneNumberProvider
    {
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
