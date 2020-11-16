using Hayaa.BaseModel;
using Hayaa.ConfigSeed.Standard.Component;
using Hayaa.ConfigSeed.Standard.Model;
using System;

namespace Hayaa.ConfigSeed.Standard
{
    /// <summary>
    /// 宿主引用插件类
    /// 调用InitProgram方法获取远程配置
    /// </summary>
    public class AppSeed
    {
        private static AppSeed _instance = new AppSeed();
       static AppSeed()
        {

        }
        public static AppSeed Instance
        {
            get
            {
                return _instance;
            }
        }
        /// <summary>
        /// 初始化，并获取配置
        /// </summary>
        /// <returns></returns>
        public string InitConfig()
        {
            string result = "";
            try
            {
                //支持分布式配置系统则获取配置
                ProgramDistributedConfig.Instance.InitAppConfig();
                var seedConfig = ProgramDistributedConfig.Instance.GetSeedConfig();

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return result;
        }
        public String Resetonfig()
        {
            string result = "";
            try
            {
                //支持分布式配置系统则获取配置
                ProgramDistributedConfig.Instance.ReAppConfig();
                var seedConfig = ProgramDistributedConfig.Instance.GetSeedConfig();

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return result;
        }
        /// <summary>
        /// 设置App实例运行Id
        /// </summary>
        /// <param name="appInstanceId"></param>
        public static void SetAppInstanceId(int appInstanceId)
        {
            ProgramDistributedConfig.Instance.SetAppInstanceId(appInstanceId);
        }
        /// <summary>
        /// 获取AppId
        /// </summary>
        /// <returns></returns>
        public static FunctionOpenResult<AppLocalConfig> GetAppLocalConfig() 
        {
            var r = new FunctionOpenResult<AppLocalConfig>();
            AppLocalConfig config = ProgramDistributedConfig.Instance.GetSeedConfig();
            if (config != null)
            {
               
                    r.Data = config;
               
            }
            return r;
        }
        /// <summary>
        /// 按照组件ID获取组件配置内容
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="componentID"></param>
        /// <returns></returns>
        public static FunctionResult<T> GetConfig<T>(int componentID) where T : BaseData, new()
        {
            var r = new FunctionResult<T>();
            var config = ProgramDistributedConfig.Instance.GetComponentConfig(componentID);
            if (config != null)
            {
                if (!string.IsNullOrEmpty(config.Content))
                {
                    r.Data =Newtonsoft.Json.JsonConvert.DeserializeObject<T>(config.Content);
                }
            }
            return r;
        }
        public static FunctionOpenResult<T> GetAppRootConfig<T>() 
        {
            var r = new FunctionOpenResult<T>();
            var config = ProgramDistributedConfig.Instance.GetAppConfig();
            if (config != null)
            {
                if (!string.IsNullOrEmpty(config.ConfigContent))
                {
                    r.Data = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(config.ConfigContent);
                }
            }
            return r;
        }
    }
}
