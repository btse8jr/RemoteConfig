
using Hayaa.BaseModel;
using Hayaa.RemoteConfig.Service.Dao;
using System.Collections.Generic;

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
        public FunctionOpenResult<bool> AddComponentConfigForApp(int componentConfigId, int appConfigId)
        {
            var r = new FunctionOpenResult<bool>();
            var data = Rel_AppConfig_ComponentConfigDal.Get(appConfigId, componentConfigId);
            if (data != null)
            {
                r.Data = false;
                r.ErrorMsg = "此数据已存在";
                return r;
            }
            var appConfig = AppConfigDal.Get(appConfigId);
            var componentConfig = ComponentConfigDal.Get(componentConfigId);
            if (componentConfig == null)
            {
                r.Data = false;
                r.ErrorMsg = "此组件配置不存在";
                return r;
            }
            if ((appConfig != null) && (componentConfig != null))
            {
                r.Data = Rel_AppConfig_ComponentConfigDal.Add(new Rel_AppConfig_ComponentConfig()
                {
                    AppConfigId = appConfig.AppConfigId,
                    AppConfigVersion = appConfig.Version,
                    ComponentConfigId = componentConfig.ComponentConfigId,
                    ComponentConfigVersion = componentConfig.Version,
                    SolutionID = appConfig.SolutionID
                }) > 0;
            }
            return r;
        }

        public FunctionOpenResult<bool> RemoveComponentConfigForApp(List<int> componentConfigIds, int appConfigId)
        {
            var r = new FunctionOpenResult<bool>();
            r.Data = Rel_AppConfig_ComponentConfigDal.Delete(componentConfigIds, appConfigId);
            return r;
        }
    }
}