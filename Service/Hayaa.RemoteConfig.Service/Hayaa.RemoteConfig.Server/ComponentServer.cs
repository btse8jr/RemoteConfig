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
    public partial class ComponentServer : ComponentService
    {
        public FunctionResult<Component> Create(Component info)
        {
            var r = new FunctionResult<Component>(); int id = ComponentDal.Add(info); if (id > 0) { r.Data = info; r.Data.ComponentId = id; }
            return r;
        }
        public FunctionOpenResult<bool> UpdateByID(Component info) { var r = new FunctionOpenResult<bool>(); r.Data = ComponentDal.Update(info) > 0; return r; }
        public FunctionOpenResult<bool> DeleteByID(List<int> idList) { var r = new FunctionOpenResult<bool>(); r.Data = ComponentDal.Delete(idList); return r; }
        public FunctionResult<Component> Get(int Id) { var r = new FunctionResult<Component>(); r.Data = ComponentDal.Get(Id); return r; }
        public FunctionListResult<Component> GetList(ComponentSearchPamater pamater) { var r = new FunctionListResult<Component>(); r.Data = ComponentDal.GetList(pamater); return r; }
        public GridPager<Component> GetPager(GridPagerPamater<ComponentSearchPamater> searchParam) { var r = ComponentDal.GetGridPager(searchParam); return r; }
    }
}