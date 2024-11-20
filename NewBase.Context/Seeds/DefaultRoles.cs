 using Microsoft.AspNetCore.Identity;
using NewBase.Core.Enums;
using System.Collections.Generic;

namespace NewBase.Context.Seeds
{
    public static class DefaultRoles
    {
        public static List<IdentityRole> IdentityRoleList()
        {
            List<IdentityRole> identityRoles = new List<IdentityRole>();
            foreach (Roles role in (Roles[])Roles.GetValues(typeof(Roles)))
            {
                identityRoles.Add(new IdentityRole(role.ToString()));
            }

            return identityRoles;
        }
    }
}
