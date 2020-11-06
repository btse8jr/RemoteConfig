using Hayaa.BaseModel.Service;
using Hayaa.RemoteConfig.Service;
using System;

namespace Hayaa.RemoteService
{
    /// <summary>
    /// App(宿主程序)配置服务
    /// </summary>
    public interface AppConfigService : IBaseService<AppConfig, AppConfigSearchPamater>
    {

    }
}
