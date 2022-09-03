namespace BeachIsland.Server.Data
{
    public static class DataConstants
    {
        public static class User
        {
            public const int OccupationMaxLength = 30;
            public const int OccupationMinLength = 3;
            public const int NicknameMaxLength = 30;
            public const int NicknameMinLength = 2;
        }
        public static class Partner
        {
            public const int NameMaxLength = 30;
            public const int NameMinLength = 2;
            public const int PhoneNumberMaxLength = 20;
            public const int PhoneNumberMinLength = 6;
        }
    }
}
