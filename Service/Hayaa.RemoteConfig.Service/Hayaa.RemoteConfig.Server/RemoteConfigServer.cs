using System;
using System.Collections.Generic;
using Hayaa.BaseModel;
using Hayaa.RemoteConfig.Service.Dao;
using Hayaa.RemoteService;

namespace Hayaa.RemoteConfig.Service
{
    public class RemoteConfigServer : RemoteConfigService
    {
        public FunctionResult<AppConfig> SendConfig(Guid solutionID, int version)
        {
            var r = new FunctionResult<AppConfig>();
            var appConfig = AppConfigDal.Get(solutionID, version);
            if (appConfig != null)
            {
                List<ComponentConfig> list = ComponentConfigDal.GetList(appConfig.AppConfigId, appConfig.Version);
                appConfig.Components = list;
                r.Data = appConfig;
            }
            else
            {
                r.ErrorMsg = "无获取app的配置数据";
                r.Data = null;
            }
            return r;
        }

        public FunctionResult<AppConfig> SendJsAppConfig(Guid solutionID, int version)
        {
            var r = new FunctionResult<AppConfig>();
            var appConfig = AppConfigDal.Get(solutionID, version);
            if (appConfig != null)
            {              
                r.Data = appConfig;
            }
            else
            {
                r.ErrorMsg = "无获取app的配置数据";
                r.Data = null;
            }
            return r;
        }
    }
}
