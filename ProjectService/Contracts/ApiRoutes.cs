namespace ProjectService.Contracts
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class DocumentRoute
        {
            public const string Document = "/document";
            public const string BaseDocument = Base + Document;
            public const string GetProductInfo = BaseDocument + "/getProductInfo";
            public const string GetTestInfo = BaseDocument + "/getTestInfo";
        }
    }
}
