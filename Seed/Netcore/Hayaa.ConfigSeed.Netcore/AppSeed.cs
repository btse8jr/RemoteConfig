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
    }
}
