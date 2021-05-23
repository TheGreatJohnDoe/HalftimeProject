using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Web;

namespace RequestsMaster.Utility
{
    public static class ActiveDirectoryUtils
    {
        public static string currentUser()
        {
            return HttpContext.Current.User.Identity.Name;
        }
        public static bool isAdmin(string userid)
        {
            using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
            {
                using (UserPrincipal user = UserPrincipal.FindByIdentity(context, userid))
                {
                    using (PrincipalSearchResult<Principal> groups = user.GetAuthorizationGroups())
                    {
                        return groups.OfType<GroupPrincipal>().Any(g => g.Name.Equals("RequestsMasterAdmins", StringComparison.OrdinalIgnoreCase));
                    }
                }
            }
        }
        public static bool doesUserExists(string userid)
        {
            using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
            {
                using (UserPrincipal user = UserPrincipal.FindByIdentity(context, userid))
                {
                    return user != null;
                }
            }
        }

        public static void createUser(string Name, string GivenName, string Surname, string AccountName, string Password)
        {
            using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
            {
                using (UserPrincipal newuser = new UserPrincipal(context))
                {
                    newuser.Name = Name;
                    newuser.GivenName = GivenName;
                    newuser.Surname = Surname;
                    newuser.SamAccountName = AccountName;
                    newuser.SetPassword(Password);
                    newuser.Save();
                }
            }
        }

        public static void deleteUser(string userid)
        {
            if (doesUserExists(userid))
            {
                using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
                {
                    using (UserPrincipal user = UserPrincipal.FindByIdentity(context, userid))
                    {
                        user.Delete();
                    }
                }
            }
        }

        public static void editUser(string Name, string GivenName, string Surname, string AccountName, string Password)
        {
            using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
            {
                using (UserPrincipal user = UserPrincipal.FindByIdentity(context, AccountName))
                {
                    if (Name != null)
                        user.Name = Name;
                    if (GivenName != null)
                        user.GivenName = GivenName;
                    if (Surname != null)
                        user.Surname = Surname;
                    if (AccountName != null)
                        user.SamAccountName = AccountName;
                    if (Password != null)
                        user.SetPassword(Password);
                    user.Save();
                }
            }
        }
    }
}