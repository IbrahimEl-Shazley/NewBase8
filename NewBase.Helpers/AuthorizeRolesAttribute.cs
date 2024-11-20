namespace NewBase.Helpers
{
    public class AuthorizeRolesAttribute : Microsoft.AspNetCore.Authorization.AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params NewBase.Core.Enums.Roles[] roles) : base()
        {
            Roles = string.Join(",", roles);
        }
    }
}
