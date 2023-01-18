namespace User.Domain.Roles
{
    public struct UserRoles
    {
        public const string ADMIN = "ADMIN";
        public const string PUBLIC = "PUBLIC";

        public const string ALL_ROLES = ADMIN + "," + PUBLIC;
    }
}
