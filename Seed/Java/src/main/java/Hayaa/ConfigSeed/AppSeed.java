package Hayaa.ConfigSeed;

import hayaa.basemodel.model.BaseData;
import hayaa.basemodel.model.FunctionOpenResult;
import hayaa.basemodel.model.FunctionResult;
import hayaa.common.JsonHelper;
import hayaa.common.StringUtil;

import static javafx.scene.input.KeyCode.T;

public class AppSeed {
    private static AppSeed _instance = new AppSeed();

    public static AppSeed Instance() {

        return _instance;

    }

    /// <summary>
    /// 初始化，并获取配置
    /// </summary>
    /// <returns></returns>
    public String InitConfig() {
        String result = "";
        try {
            //支持分布式配置系统则获取配置
            System.out.println("读取设置");
            ProgramDistributedConfig.Instance().initAppStartInit();
            AppLocalConfig seedConfig = ProgramDistributedConfig.Instance().GetSeedConfig();

        } catch (Exception ex) {
            return ex.getMessage();
        }
        return result;
    }

    public String Resetonfig() {
        String result = "";
        try {
            //支持分布式配置系统则获取配置
            ProgramDistributedConfig.Instance().ReAppConfig();
            AppLocalConfig seedConfig = ProgramDistributedConfig.Instance().GetSeedConfig();

        } catch (Exception ex) {
            return ex.getMessage();
        }
        return result;
    }

    public static void SetAppInstanceId(int appInstanceId) {
        ProgramDistributedConfig.Instance().SetAppInstanceId(appInstanceId);
    }

    public static FunctionOpenResult<AppLocalConfig> GetAppLocalConfig() {
        FunctionOpenResult<AppLocalConfig> r = new FunctionOpenResult<>();
        AppLocalConfig config = ProgramDistributedConfig.Instance().GetSeedConfig();
        if (config != null) {
            r.setData(config);
        }
        return r;
    }
    public static <T> FunctionOpenResult<T> GetConfig(int componentID, Class<T> valueType)
    {
        FunctionOpenResult<T> r = new FunctionOpenResult<T>();
        ComponentConfig config = ProgramDistributedConfig.Instance().GetComponentConfig(componentID);
        if (config != null)
        {
            if (!StringUtil.IsNullOrEmpty(config.getContent()))
            {
                r.setData(JsonHelper.DeserializeObject(config.getContent(),valueType));
            }
        }
        return r;
    }
    public static <T> FunctionOpenResult<T> GetAppRootConfig(Class<T> valueType)
    {
        FunctionOpenResult<T> r = new FunctionOpenResult<>();
        AppConfig config = ProgramDistributedConfig.Instance().getAppConfig();
        if (config != null)
        {
            if (!StringUtil.IsNullOrEmpty(config.getConfigContent()))
            {
                r.setData(JsonHelper.DeserializeObject(config.getConfigContent(),valueType));
            }
        }
        return r;
    }
}
