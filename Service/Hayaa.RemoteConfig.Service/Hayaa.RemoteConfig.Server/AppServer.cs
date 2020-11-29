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
    public partial class AppServer : AppService
    {
        public FunctionResult<App> Create(App info)
        {
            var r = new FunctionResult<App>(); int id = AppDal.Add(info); if (id > 0) { r.Data = info; r.Data.AppId = id; }
            return r;
        }
        public FunctionOpenResult<bool> UpdateByID(App info) { var r = new FunctionOpenResult<bool>(); r.Data = AppDal.Update(info) > 0; return r; }
        public FunctionOpenResult<bool> DeleteByID(List<int> idList) { var r = new FunctionOpenResult<bool>(); r.Data = AppDal.Delete(idList); return r; }
        public FunctionResult<App> Get(int Id) { var r = new FunctionResult<App>(); r.Data = AppDal.Get(Id); return r; }
        public FunctionListResult<App> GetList(AppSearchPamater pamater) { var r = new FunctionListResult<App>(); r.Data = AppDal.GetList(pamater); return r; }
        public GridPager<App> GetPager(GridPagerPamater<AppSearchPamater> searchParam) { var r = AppDal.GetGridPager(searchParam); return r; }

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
                r.Data = Rel_AppConfig_ComponentConfigDal.Add(new Rel_AppConfig_ComponentConfig() {
                     AppConfigId=appConfig.AppConfigId,
                      AppConfigVersion=appConfig.Version,
                       ComponentConfigId=componentConfig.ComponentConfigId,
                        ComponentConfigVersion=componentConfig.Version,
                         SolutionID=appConfig.SolutionID
                })>0;               
            }
            return r;
        }

        public FunctionOpenResult<bool> RemoveComponentConfigForApp(List<int> componentConfigIds, int appConfigId)
        {
            var r = new FunctionOpenResult<bool>();
           r.Data= Rel_AppConfig_ComponentConfigDal.Delete(componentConfigIds, appConfigId);
            return r;
        }
    }
}