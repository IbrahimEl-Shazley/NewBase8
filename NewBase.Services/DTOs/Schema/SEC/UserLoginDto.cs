namespace NewBase.Services.DTOs.Schema.SEC
{
    public class UserLoginDto
    {
        public string PhoneOrMail { get; set; }
        //public string Username { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
