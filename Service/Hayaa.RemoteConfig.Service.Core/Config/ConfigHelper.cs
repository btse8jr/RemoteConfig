using Hayaa.RemoteConfig.Client;

namespace Hayaa.RemoteConfig.Service.Config
{
    internal class ConfigHelper: ConfigTool<RemoteServiceConfig, RemoteServiceRootConfig>
    {
        private static ConfigHelper _instance = new ConfigHelper();
        private ConfigHelper() : base(DefineTable.RemoteServiceComponetID)
        {

        }

        internal static ConfigHelper Instance { get => _instance; }
    }
}
