using System;

namespace DLLValidation
{
    public class clsValidation
    {
        public static bool ValidateEmpty(string str)
        {
            if (String.IsNullOrEmpty(str))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool ValidateLength(string str, int minlen, int maxlen)
        {
            if (str.Length > minlen && str.Length < maxlen)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool ValidateNumeric(string str)
        {
            try
            {
                Convert.ToInt32(str);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ValidateNumLength(string str, int len, int maxlen)
        {

            return true;
        }
        public class clsValidation1
        {
            public static bool ValidateEmpty(string str)
            {
                if (String.IsNullOrEmpty(str))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
