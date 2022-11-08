namespace Interview
{
    public class ConfigurationSingleton
    {
        private static ConfigurationSingleton _instance;

        protected ConfigurationSingleton()
        {
            // Read everything from file and initialize properties
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
