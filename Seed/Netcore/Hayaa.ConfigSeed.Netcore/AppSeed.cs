using Hayaa.BaseModel;
using Hayaa.ConfigSeed.Standard.Component;
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
        public string InitProgram()
        {
            string result = "";
            try
            {
                //支持分布式配置系统则获取配置
                ProgramDistributedConfig.Instance.RunInAppStartInit();
                var seedConfig = ProgramDistributedConfig.Instance.GetSeedConfig();

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return result;
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
    }
}
