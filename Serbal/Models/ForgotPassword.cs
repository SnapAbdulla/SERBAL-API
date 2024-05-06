namespace Serbal.Models
{
    public class ForgotPassword
    {
        public int otp { get; set; }
        public string UserName { get; set; }
        public string enterPassword { get; set; }
        public string reenterPassword { get; set; }
    }
}
