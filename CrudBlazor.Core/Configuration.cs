namespace CrudBlazor.Core
{
    public static class Configuration
    {
        public static string ConnectionString => Environment.GetEnvironmentVariable("CRUDBLAZOR_CONNECTIONSTRING") ?? @"Server=localhost;Database=crudblazor;Uid=crudblazor;Pwd=crudblazor;";
        public static string JwtPrivateKey => Environment.GetEnvironmentVariable("CRUDBLAZOR_JWTPRIVATEKEY") ?? new string('0', 64);
    }
}
