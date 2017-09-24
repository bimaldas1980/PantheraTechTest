using System.Configuration;
namespace GameRating.Base
{
    public static class ConfigSetting
    {
        public static string DBConnStr
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            }
        }
    }
}
