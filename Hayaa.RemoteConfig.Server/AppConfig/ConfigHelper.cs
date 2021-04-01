using Hayaa.RemoteConfig.Client;

namespace Hayaa.RemoteConfig.Server.Config
{
    internal class ConfigHelper: ConfigTool<RemoteServiceConfig, RemoteServiceRootConfig>
    {
        private static ConfigHelper _instance = new ConfigHelper();
        private ConfigHelper() : base(DefineTable.ComponetID)
        {

        }

        internal static ConfigHelper Instance { get => _instance; }
    }
}
