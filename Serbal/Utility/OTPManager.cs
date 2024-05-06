namespace Serbal.Utility
{
    public static class OTPManager
    {
        private static Dictionary<string, int> otpDictionary = new Dictionary<string, int>();

        public static int GenerateOTP(string userName)
        {
            var otp = OTPGenerator.GenerateOTP();
            otpDictionary[userName] = otp;
            return otp;
        }

        public static bool ValidateOTP(string userName, int otp)
        {
            if (otpDictionary.TryGetValue(userName, out int storedOTP))
            {
                if (storedOTP == otp)
                {
                    otpDictionary.Remove(userName);
                    return true;
                }
            }
            return false;
        }
    }
}
