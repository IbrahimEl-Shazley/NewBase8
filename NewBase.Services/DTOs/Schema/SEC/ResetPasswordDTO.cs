namespace NewBase.Services.DTOs.Schema.SEC
{
    public class ResetPasswordDTO
    {
        public string Phone { get; set; }
        public string Otp { get; set; }
        public string Password { get; set; }
    }
}
