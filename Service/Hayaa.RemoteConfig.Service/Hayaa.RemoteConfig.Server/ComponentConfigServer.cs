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
    public partial class ComponentConfigServer : ComponentConfigService
    {
        public FunctionResult<ComponentConfig> Create(ComponentConfig info)
        {
            var r = new FunctionResult<ComponentConfig>(); int id = ComponentConfigDal.Add(info); if (id > 0) { r.Data = info; r.Data.ComponentConfigId = id; }
            return r;
        }
        public FunctionOpenResult<bool> UpdateByID(ComponentConfig info) { var r = new FunctionOpenResult<bool>(); r.Data = ComponentConfigDal.Update(info) > 0; return r; }
        public FunctionOpenResult<bool> DeleteByID(List<int> idList) {
            var r = new FunctionOpenResult<bool>(); r.Data = ComponentConfigDal.Delete(idList); return r;
        }
        public FunctionResult<ComponentConfig> Get(int Id) { var r = new FunctionResult<ComponentConfig>(); r.Data = ComponentConfigDal.Get(Id); return r; }
        public FunctionListResult<ComponentConfig> GetList(ComponentConfigSearchPamater pamater) { var r = new FunctionListResult<ComponentConfig>(); r.Data = ComponentConfigDal.GetList(pamater); return r; }
        public GridPager<ComponentConfig> GetPager(GridPagerPamater<ComponentConfigSearchPamater> searchParam) { var r = ComponentConfigDal.GetGridPager(searchParam); return r; }


    }
}