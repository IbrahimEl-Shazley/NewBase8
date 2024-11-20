using NewBase.Core.Models.DTO;
using System.Collections.Generic;

namespace NewBase.Services.DTOs.Schema.SEC
{
    public class UserProfileDto : DTO<string>
    {
        public int UserTypeId { get; set; }

        public string IdentityId { get; set; }
        public string Email { get; set; }

        public bool IsActivated { get; set; }
        public bool IsProfileCompleted { get; set; }
        public bool IsBlocked { get; set; }

        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {FatherName} {GrandFatherName} {LastName}";

        public List<UserProfileMobileDTO> UserMobiles { get; set; }

        public List<string> Permissions { get; set; }
    }

    public class UserProfileMobileDTO
    {
        public long DialCodeId { get; set; }

        public string Number { get; set; }

        public bool IsMain { get; set; }
    }
}
