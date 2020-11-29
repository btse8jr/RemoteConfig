using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.DataAccess;
using Hayaa.BaseModel;
using Hayaa.RemoteConfig.Service.Dao;
using Hayaa.RemoteConfig.Service.Config;
using Hayaa.RemoteService;

namespace Hayaa.RemoteConfig.Service
{
    public partial class AppConfigServer 
    {
        public FunctionOpenResult<bool> Remove10002ComponentConfig(int appConfigId)
        {
            var r = new FunctionOpenResult<bool>();
            r.Data = Rel_AppConfig_ComponentConfigDal.Delete10002(appConfigId);
            return r;
        }
    }
}