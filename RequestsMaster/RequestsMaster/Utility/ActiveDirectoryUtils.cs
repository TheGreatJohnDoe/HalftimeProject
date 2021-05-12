using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Web;

namespace RequestsMaster.Utility
{
    public static class ActiveDirectoryUtils
    {
        public static bool isAdmin(string username)
        {
            using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
            using (UserPrincipal user = UserPrincipal.FindByIdentity(context, username))
            using (PrincipalSearchResult<Principal> groups = user.GetAuthorizationGroups())
            {
                return groups.OfType<GroupPrincipal>().Any(g => g.Name.Equals("RequestsMasterAdmins", StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}