using Hayaa.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.RemoteConfig.Service
{
   public interface RemoteConfigService
    {
        /// <summary>
        /// 发送制定的App(宿主程序)配置方案内容
        /// </summary>
        /// <param name="solutionID">方案ID</param>
        /// <param name="version">方案版本</param>
        /// <returns>包括组件配置列表的app配置方案数据实体</returns>
        FunctionResult<AppConfig> SendConfig(String solutionID, int version);
        /// <summary>
        /// 发送js程序的配置内容
        /// </summary>
        /// <param name="solutionID">方案ID</param>
        /// <param name="version">方案版本</param>
        /// <returns></returns>
        FunctionResult<AppConfig> SendJsAppConfig(String solutionID, int version);
    }
}
