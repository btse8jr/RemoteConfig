using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.DataAccess;
using Hayaa.BaseModel;
using Hayaa.RemoteConfig.Service.Dao;
using Hayaa.RemoteConfig.Service.Config;
using Hayaa.RemoteService;
/// <summary>
///代码效率工具生成，此文件不要修改
/// </summary>
namespace Hayaa.RemoteConfig.Service
{
    public partial class AppConfigServer : AppConfigService
    {
        public FunctionResult<AppConfig> Create(AppConfig info)
        {
            var r = new FunctionResult<AppConfig>(); int id = AppConfigDal.Add(info); if (id > 0) { r.Data = info; r.Data.AppConfigId = id; }
            return r;
        }
        public FunctionOpenResult<bool> UpdateByID(AppConfig info) { var r = new FunctionOpenResult<bool>(); r.Data = AppConfigDal.Update(info) > 0; return r; }
        public FunctionOpenResult<bool> DeleteByID(List<int> idList) { var r = new FunctionOpenResult<bool>(); r.Data = AppConfigDal.Delete(idList); return r; }
        public FunctionResult<AppConfig> Get(int Id) { var r = new FunctionResult<AppConfig>(); r.Data = AppConfigDal.Get(Id); return r; }
        public FunctionListResult<AppConfig> GetList(AppConfigSearchPamater pamater) { var r = new FunctionListResult<AppConfig>(); r.Data = AppConfigDal.GetList(pamater); return r; }
        public GridPager<AppConfig> GetPager(GridPagerPamater<AppConfigSearchPamater> searchParam) { var r = AppConfigDal.GetGridPager(searchParam); return r; }

      
    }
}