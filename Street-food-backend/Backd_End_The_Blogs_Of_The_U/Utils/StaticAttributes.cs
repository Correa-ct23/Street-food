namespace Backd_End_The_Blogs_Of_The_U.Utils
{
    public class StaticAttributes
    {
        public static object GetMySqlAttributes(ConfigurationManager config)
        {
            string? host = Environment.GetEnvironmentVariable("host");
            string? port = Environment.GetEnvironmentVariable("port");
            string? db = Environment.GetEnvironmentVariable("db");
            string? dbUser = Environment.GetEnvironmentVariable("dbUser");
            string? dbPassword = Environment.GetEnvironmentVariable("dbPassword");

            if (host == null || port == null || db == null || dbUser == null || dbPassword == null)
            {
                return config.GetSection("MySqlSettings");
            }
            var myConfiguration = new Dictionary<string, string>
            {
                {"host", host},
                {"port", port},
                {"db", db},
                {"dbUser", dbUser},
                {"dbPassword", dbPassword}
            };
            var configuration = new ConfigurationBuilder().AddInMemoryCollection(myConfiguration).Build();
            return configuration;
        }
        public static object GetSmtpAttributes(ConfigurationManager config)
        {
            string? smtpHost = Environment.GetEnvironmentVariable("smtpHost");
            string? smtpPort = Environment.GetEnvironmentVariable("smtpPort");
            string? smtpEmail = Environment.GetEnvironmentVariable("smtpEmail");
            string? smtpPassword = Environment.GetEnvironmentVariable("smtpPassword");
            string? smtpName = Environment.GetEnvironmentVariable("SenderName");


            if (smtpHost == null || smtpPort == null || smtpEmail == null || smtpPassword == null)
            {
                return config.GetSection("SmtpSettings");
            }

            var smtpConfig = new Dictionary<string, string>
            {
                {"Host", smtpHost},
                {"Port", smtpPort},
                {"SenderEmail", smtpEmail},
                {"SenderPassword", smtpPassword},
                {"SenderName", smtpName}

             };

            return new ConfigurationBuilder().AddInMemoryCollection(smtpConfig).Build();
        }


    }
}
