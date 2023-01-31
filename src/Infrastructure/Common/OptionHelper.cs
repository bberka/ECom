namespace ECom.Infrastructure.Common
{
    public static class OptionHelper
    {
        public static readonly EasCache<Option> Option = new(GetOption, 1);
        private static Option GetOption()
        {
            return EComDbContext.New().Options.FirstOrDefault() ?? throw new Exception("Option table is empty");
        }
        public static bool IsOpen()
        {
            return Option.Get().IsOpen;
        }
        public static string GetJwtSecret()
        {
            return Option.Get().JwtSecret;
        }
        public static string GetJwtSecret_Admin()
        {
            return Option.Get().JwtSecret_Admin;
        }
    }
}
