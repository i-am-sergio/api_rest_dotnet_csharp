namespace rest_dotnet_csharp.connections
{
    class ConnectionDB
    {
        private string? connectionString = string.Empty;

        public ConnectionDB()
        {
            var constructor = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string? value = constructor.GetSection("ConnectionStrings:MySqlConnection").Value;
            this.connectionString = value;
        }

        public string? getConnectionString()
        {
            return this.connectionString;
        }
    }
}