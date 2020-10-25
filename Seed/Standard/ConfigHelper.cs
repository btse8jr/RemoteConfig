using Hayaa.ConfigSeed.Standard.Component;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.ConfigSeed.Standard
{
    /// <summary>
    /// 组件配置获取基础类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ConfigHelper<T> where T : class
    {
        public static T GetConfig(int componentID)
        {
            var config = ProgramDistributedConfig.Instance.GetComponentConfig(componentID);
            if (config != null)
            {
                if (string.IsNullOrEmpty(config.Content))
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(config.Content);
                }
            }
            return default(T);
        }
    }
}
