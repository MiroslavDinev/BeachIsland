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

        public static class Island
        {
            public const int NameMaxLength = 30;
            public const int NameMinLength = 2;
            public const int LocationMaxLength = 50;
            public const int LocationMinLength = 2;
            public const int DescriptionMaxLength = 3000;
            public const int DescriptionMinLength = 10;
        }

        public static class ContactMessage
        {
            public const int MessageMaxLength = 1000;
            public const int MessageMinLength = 10;
        }

        public static class ContactSubject
        {
            public const int SubjectMaxLength = 30;
            public const int SubjectMinLength = 3;
        }
    }
}
