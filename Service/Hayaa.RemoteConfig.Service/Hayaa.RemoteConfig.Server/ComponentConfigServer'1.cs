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
    public partial class ComponentConfigServer
    {
           
        public FunctionListResult<ComponentConfig> GetComponentConfigList(int appConfigId, int version)
        {
            var r = new FunctionListResult<ComponentConfig>();
            r.Data = ComponentConfigDal.GetList(appConfigId, version);
            return r; 
        }
    }
}