using Hayaa.BaseModel;
using Hayaa.BaseModel.Service;
using Hayaa.RemoteConfig.Service;
using System;

namespace Hayaa.RemoteService
{
    /// <summary>
    /// App(宿主程序)组件配置服务
    /// </summary>
    public interface ComponentConfigService : IBaseService<ComponentConfig, ComponentConfigSearchPamater>
    {
        FunctionListResult<ComponentConfig> GetComponentConfigList(int appConfigId, int version);       
      
    }
}
