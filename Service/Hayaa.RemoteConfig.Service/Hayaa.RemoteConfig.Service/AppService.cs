using Hayaa.BaseModel;
using Hayaa.BaseModel.Service;
using Hayaa.RemoteConfig.Service;
using System;
using System.Collections.Generic;

namespace Hayaa.RemoteService
{
    /// <summary>
    /// App(宿主程序)配置服务
    /// </summary>
    public interface AppService : IBaseService<App, AppSearchPamater>
    {
        /// <summary>
        /// 程序添加组件配置
        /// </summary>
        /// <param name="componentConfigId">准备添加的组件配置Id</param>
        /// <param name="appConfigId">程序配置Id</param>
        /// <returns></returns>
        FunctionOpenResult<bool> AddComponentConfigForApp(int componentConfigId, int appConfigId);
        /// <summary>
        /// 程序移除组件配置
        /// </summary>
        /// <param name="componentConfigIds">准备移除的组件配置Id</param>
        /// <param name="appConfigId">程序配置Id</param>
        /// <returns></returns>
        FunctionOpenResult<bool> RemoveComponentConfigForApp(List<int> componentConfigIds, int appConfigId);
    }
}
