using System.Configuration;

namespace KeepCalm_KeepTrack.Database
{
    public static class ConfigurationHelper
    {
        public static string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
