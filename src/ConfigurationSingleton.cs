namespace Interview
{
    public class ConfigurationSingleton
    {
        private static ConfigurationSingleton _instance;

        protected ConfigurationSingleton()
        {
            // Pretend this is OK, let's just do something to give it some URL
            EmployeeServiceEndpoint = "http://google.com";
        }

        public static ConfigurationSingleton Instance
        {
            get
            {
                if (_instance == null) _instance = new ConfigurationSingleton();
                return _instance;
            }
        }


        public string EmployeeServiceEndpoint { get; set; }
    }
}
