package Hayaa.ConfigSeed;

import hayaa.basemodel.model.AppSettings;
import hayaa.basemodel.model.ConfigContent;
import hayaa.basemodel.model.ConnectionStrings;
import hayaa.basemodel.model.FunctionOpenResult;

import java.util.Optional;

public class ConfigTool<T extends ConfigContent, APPROOT> {
    private T g_config;
    private APPROOT g_appRootConfig;
    public ConfigTool(int componentID,Class<T> componentConfigType,Class<APPROOT> appRootConfigType)
    {
        FunctionOpenResult<T> Config = AppSeed.GetConfig(componentID,componentConfigType);
        if (Config.isActionResult())
        {
            g_config = Config.getData();
        }
        FunctionOpenResult<APPROOT> appRootConfig = AppSeed.GetAppRootConfig(appRootConfigType);
        if (Config.isActionResult())
        {
            g_appRootConfig = appRootConfig.getData();
        }
    }
    public T GetComponentConfig()
    {
        return g_config;
    }
    public APPROOT GetAppRootConfig()
    {
        return g_appRootConfig;
    }
    public String GetConnection(String name)
    {

        return GetCon(name);
    }
    private String GetCon(String name)
    {
        ConfigContent baseConfig = (ConfigContent)g_config;
        Optional<ConnectionStrings.ConnectionInfo> con = baseConfig.getConnectionStrings().Settings.stream()
                .filter(c->c.getName().equals(name)).findFirst();
        return con.get().getConnection();
    }
    public String GetAppsetting(String key, String defaultVal)
    {
        return GetAppset(key, defaultVal);
    }
    private String GetAppset(String key, String defaultVal)
    {
        ConfigContent baseConfig = (ConfigContent)g_config;
        Optional<AppSettings.AppSetInfo> con = baseConfig.getAppSettings().Settings.stream()
                .filter(c->c.getKey().equals(key)).findFirst();
        if (con != null) return con.get().getValue();
        return defaultVal;
    }
}
