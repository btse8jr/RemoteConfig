package Hayaa.ConfigSeed;

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
    public String InitProgram() {
        String result = "";
        try {
            //支持分布式配置系统则获取配置
            ProgramDistributedConfig.Instance().RunInAppStartInit();
            AppLocalConfig seedConfig = ProgramDistributedConfig.Instance().GetSeedConfig();

        } catch (Exception ex) {
            return ex.getMessage();
        }
        return result;
    }

    /// <summary>
    /// 按照组件ID获取组件配置内容
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="componentID"></param>
    /// <returns></returns>
    public static String GetConfig(int componentID) {

        ComponentConfig r = ProgramDistributedConfig.Instance().GetComponentConfig(componentID);
        if (r != null) return r.getContent();
        return null;

    }
}
