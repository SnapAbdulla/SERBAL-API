namespace Serbal.Utility
{
    public static class OTPGenerator { 
    
        public static int GenerateOTP()
        {
            Random random = new Random();
            int otp = random.Next(100000, 999999);
            return otp;
        }
    }
}
