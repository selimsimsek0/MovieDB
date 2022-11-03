namespace MovieDB.Business.Providers.MovieDBApi
{
    public static class Parameters
    {
        public static string ApiKeyValue => "3d4c4533c7955e2e01a80687039d777a";
        public static string ApiKeyKey => "api_key";

        public static string RegionKey => "region";
        public static string RegionValue => "TR";

        public static string PageKey => "page";

        public static string languageKey => "language";
        public static string LanguageValue => "tr-TR";

        public static string QueryKey = "query";
        public static string QueryValue(string value) => value.Replace(' ', '+');

    }

}
