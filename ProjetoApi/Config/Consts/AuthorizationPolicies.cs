namespace Api.Consts
{
    public static class AuthorizationPolicies
    {
        public const string RequiresOperator = "ONLY_USER_OPERATOR_TYPE";
        public const string AllowNonOperator = "ALLOW_NON_OPERATORS";
        public const string RequiresEmployee = "ONLY_USER_EMPLOYEE_TYPE";
        public const string AllowNonEmployee = "ALLOW_NON_EMPLOYEES";
        public const string RequiresManager = "ONLY_USER_MANAGER_TYPE";
        public const string AllowNonManager = "ALLOW_NON_MANAGERS";
        public const string RequiresSystem = "ONLY_USER_SYSTEM_TYPE";
    }
}
