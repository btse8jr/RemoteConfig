package Hayaa.ConfigSeed;



import com.fasterxml.jackson.core.type.TypeReference;
import hayaa.basemodel.model.TransactionResult;
import hayaa.common.*;

import java.util.*;
import java.util.concurrent.atomic.AtomicReference;

class ProgramDistributedConfig {
    private AppConfig _appConfig;
    private AppLocalConfig _seedConfig;
    private static ProgramDistributedConfig _instance = new ProgramDistributedConfig();

    public static ProgramDistributedConfig Instance() {

        return _instance;

    }


    private ProgramDistributedConfig() {
        _appConfig = new AppConfig();
        try {
            _seedConfig = ReadSeedConfig();//防止基础配置不存在或者错误导致程序无法启动
        } catch (Exception ex) {
            _seedConfig = new AppLocalConfig();//错误配置下给予最小化配置
            _seedConfig.setRemote(false);
        }
    }

    /// <summary>
    /// 本地配置模式下只有一个方案序列化文件
    /// </summary>
    /// <param name="seedConfig"></param>
    private void ReadLocal(AppLocalConfig seedConfig, InitResult result) throws Exception {
        if (StringUtil.IsNullOrEmpty(seedConfig.getLocalConfigDirectoryPath()))//如果没有默认路径不读取
        {
            result.setResult(false);
            result.setMessage("本地配置文件路径为空");
            return;//构造函数里默认数值
        }
        try {
            AppConfig temp = JsonHelper.DeserializeObject(FileHelper.ReadAllText(seedConfig.getLocalConfigDirectoryPath() + "/"
                    + seedConfig.getAppConfigFileName()), AppConfig.class);
            if (temp != null)//使用构造函数里的数值，避免多位置同效代码赋值
            {
                _appConfig = temp;
            }
        } catch (Exception ex)//预期异常：格式错误，错误内容
        {
            throw new Exception("ReadLocal反序列化异常:" + ex.getMessage());
        }

    }

    private AppConfig ReadLocal(AppLocalConfig seedConfig) {
        if (StringUtil.IsNullOrEmpty(seedConfig.getLocalConfigDirectoryPath()))//如果没有默认路径不读取
        {
            return null;//构造函数里默认数值
        }
        try {
            AppConfig temp = JsonHelper.DeserializeObject(FileHelper.ReadAllText(seedConfig.getLocalConfigDirectoryPath() + "/"
                    + seedConfig.getAppConfigFileName()), AppConfig.class);
            return temp;
        } catch (Exception ex)//预期异常：格式错误，错误内容
        {


        }
        return null;
    }

    /// <summary>
    /// 远程获取程序配置
    /// </summary>
    /// <param name="seedConfig"></param>
    private void ReadRemote(AppLocalConfig seedConfig) throws Exception {
        AppConfig localconfig = null;
        //判断配置文件是否已经存在
        if (FileHelper.Exists(seedConfig.getLocalConfigDirectoryPath() + "/app.json")) {
            localconfig = ReadLocal(seedConfig);
        }

        //远程拉取配置文件
        AppConfig remoteConfig = GetRemote(seedConfig.getSeedServerUrl(), seedConfig.getAppConfigSolutionID(),
                seedConfig.getSecurityToken(), seedConfig.getVersion(), seedConfig.getAppInstanceID());
        //判断配置文件的新鲜程度
        if (remoteConfig != null)//无法获取远程配置时不更新本地
        {
            if (seedConfig.getVersion() == 0)//永远最新
            {
                FileHelper.Delete(seedConfig.getLocalConfigDirectoryPath() + "/" + seedConfig.getAppConfigFileName());
                //固化指定目录下制定的文件
                FileHelper.AppendAllText(seedConfig.getLocalConfigDirectoryPath() + "/" + seedConfig.getAppConfigFileName(),
                        JacksonJsonHelper.SerializeObject(remoteConfig));
            }
            if ((seedConfig.getVersion() > 0) && (localconfig == null))//本地没有配置文件并且不是永远更新
            {
                FileHelper.AppendAllText(seedConfig.getLocalConfigDirectoryPath() + "/" + seedConfig.getAppConfigFileName(),
                        JacksonJsonHelper.SerializeObject(remoteConfig));
            }
        }

    }

    /// <summary>
    /// 获取远程配置内容
    /// </summary>
    /// <param name="url">远程配置服务地址</param>
    /// <param name="solutionID">app配置方案ID</param>
    /// <param name="token">app的安全令牌</param>
    /// <returns></returns>
    private AppConfig GetRemote(String url, String solutionID, String token, Integer version, Integer appIntanceId) throws Exception {
        Map<String, String> dic = new HashMap<String, String>();
        dic.put("sid", solutionID);
        dic.put("v", version.toString());
        dic.put("apt", token);
        dic.put("aid", appIntanceId.toString());
        String str = null;
        AppConfig result = null;
        str = HttpHelper.Transaction(url, dic, "post");
        // str = HttpUtility.UrlDecode(str);
        //str = str;//解密TODO，等待安全算法实现后替换
        TransactionResult<AppConfig> response =JsonHelper.DeserializeComplexObject(str,new TypeReference<TransactionResult<AppConfig>>() {
        });
        if (response.getCode() == 0) {
            result = response.getData();
        } else {
            throw new Exception("获取远程配置服务发生错误:" + response.getMessage());
        }
        return result;
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    private AppLocalConfig ReadSeedConfig() {
        AppLocalConfig r = new AppLocalConfig();
        Properties props = System.getProperties();
        String baseDirectory =null;
        try {
             baseDirectory = props.getProperty("user.dir");
            String jsonStr=FileHelper.ReadAllText(baseDirectory + "/appconfig.json");
            r = JsonHelper.DeserializeObject(jsonStr, AppLocalConfig.class);
        } catch (Exception ex) {
            r = new AppLocalConfig();
            r.setVirtualPath(false);
        }
//        if (r.getVirtualPath()) {
            r.setLocalConfigDirectoryPath(baseDirectory +"\\"+ r.getLocalConfigDirectoryPath());
//        }
        return r;
    }

    public AppConfig GetLocalConfig() {
        return ReadLocal(_seedConfig);
    }


    /// <summary>
    /// 在程序第一次运行时运行此方法获取配置
    /// </summary>
    /// <returns></returns>
    public InitResult initAppStartInit() throws Exception {
        InitResult r = new InitResult();
        r.setResult(true);
        if (_seedConfig.getRemote())//判断是否读取远程配置模式
        {
            ReadRemote(_seedConfig);//读取远程配置
        }
        ReadLocal(_seedConfig, r);//读取本地配置
        return r;
    }

    public ComponentConfig GetComponentConfig(int componetID) {
        AtomicReference<ComponentConfig> r = null;
        //构造函数完成无null初始化设置
        _appConfig.getComponents().forEach(c -> {
            if (c.getComponentConfigId() == componetID) {
                r.set(c);
            }
        });
        return r.get();
    }

    public AppLocalConfig GetSeedConfig() {
        return _seedConfig;
    }

    public InitResult ReAppConfig() throws Exception {
        InitResult r = new InitResult();
        r.setResult(true);
        if (_seedConfig.getRemote())//判断是否读取远程配置模式
        {
            ReReadRemote(_seedConfig);//读取远程配置
        }
        ReadLocal(_seedConfig, r);//读取本地配置
        return r;
    }

    private void ReReadRemote(AppLocalConfig seedConfig) throws Exception {
        AppConfig localconfig = null;
        //远程拉取配置文件
        AppConfig remoteConfig = GetRemote(seedConfig.getSeedServerUrl(), seedConfig.getAppConfigSolutionID(), seedConfig.getSecurityToken(),
                seedConfig.getVersion(), seedConfig.getAppInstanceID());
        //判断配置文件的新鲜程度
        if (remoteConfig != null)//无法获取远程配置时不更新本地
        {
            if (seedConfig.getVersion() == 0)//永远最新
            {
                FileHelper.Delete(seedConfig.getLocalConfigDirectoryPath() + "/" + seedConfig.getAppConfigFileName());
                //固化指定目录下制定的文件
                FileHelper.AppendAllText(seedConfig.getLocalConfigDirectoryPath() + "/" + seedConfig.getAppConfigFileName(),
                        JsonHelper.SerializeObject(remoteConfig));
            }
            if ((seedConfig.getVersion() > 0) && (localconfig == null))//本地没有配置文件并且不是永远更新
            {
                FileHelper.AppendAllText(seedConfig.getLocalConfigDirectoryPath() + "/" + seedConfig.getAppConfigFileName(),
                        JsonHelper.SerializeObject(remoteConfig));
            }
        }
    }

    public void SetAppInstanceId(int appInstanceId) {
        Properties props = System.getProperties();
        try
        {
            _seedConfig.setAppInstanceID(appInstanceId);
            String baseDirectory = props.getProperty("user.dir");//获取根目录路径
            String strConfig =JsonHelper.SerializeObject(_seedConfig);
            FileHelper.AppendAllText((baseDirectory + "/appconfig.json"), strConfig);
        }
        catch (Exception ex)
        {

        }
    }

    public AppConfig getAppConfig() {
        return ReadLocal(_seedConfig);
    }
}
