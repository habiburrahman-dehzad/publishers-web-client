namespace Publishers.API.Client.MembershipService.App_Start
{
    using AspNet.Identity.MongoDB;
    using Publishers.API.Client.MembershipService.Identity;

    public class EnsureAuthIndexes
    {
        public static void Exist()
        {
            var context = ApplicationIdentityContext.Create();
            IndexChecks.EnsureUniqueIndexOnUserName(context.Users);
            IndexChecks.EnsureUniqueIndexOnRoleName(context.Roles);
        }
    }
}
