namespace CrudBlazor.Core
{
    public static class Configuration
    {
        // public static string ConnectionString => Environment.GetEnvironmentVariable("CRUDBLAZOR_CONNECTIONSTRING") ?? @"Server=host.docker.internal;Database=crudblazor;Uid=crudblazor;Pwd=crudblazor;";
        public static string ConnectionString => Environment.GetEnvironmentVariable("CRUDBLAZOR_CONNECTIONSTRING") ?? @"Server=localhost;Database=crudblazor;Uid=crudblazor;Pwd=crudblazor;";
    }
}
