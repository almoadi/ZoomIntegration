namespace ZoomIntegration.Helpers
{
    public class ConfigKey
    {
        public static string GetKey(string key)
        {
            var json = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, false);
            var config = json.Build();
            return config[key];
        }
    }
}
