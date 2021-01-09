using Hayaa.BaseModel;
using Hayaa.BaseModel.Model;
using Hayaa.RemoteConfig.Service;
using Hayaa.RemoteService;
using Hayaa.ServicePlatform.Client;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.RemoteConfigController
{
    [Route("api/[controller]/[action]")]
    public partial  class ManangerController: Controller
    {
        private AppService appService = new AppServer(); //PlatformServiceFactory.Instance.CreateService<AppService>(AppRoot.GetDefaultAppUser());
        [HttpPost]
        [EnableCors("any")]
        [Desc("GetPager", "获取App分页列表", "")]
        public TransactionResult<GridPager<App>> GetAppPager(int page,int size)
        {
            TransactionResult<GridPager<App>> result = new TransactionResult<GridPager<App>>();
            var serviceResult = appService.GetPager(new BaseModel.GridPagerPamater<RemoteConfig.Service.AppSearchPamater>() {
                 Current=page, PageSize=size, SearchPamater=new RemoteConfig.Service.AppSearchPamater()
            });
            if (serviceResult.ActionResult & serviceResult.HavingData)
            {
                result.Data = serviceResult;
            }
            else
            {
                result.Code = 103;
                result.Message = "暂无数据";
            }
            return result;
        }
        [HttpPost]
        [EnableCors("any")]
        [Desc("Get", "获取App", "根据主键获取数据")]
        public TransactionResult<App> GetApp(int id)
        {
            TransactionResult<App> result = new TransactionResult<App>();
            var serviceResult = appService.Get(id);
            if (serviceResult.ActionResult & serviceResult.HavingData)
            {
                result.Data = serviceResult.Data;
            }
            else
            {
                result.Code = 103;
                result.Message = "暂无数据";
            }
            return result;
        }
        [HttpPost]
        [EnableCors("any")]
        [Desc("AddApp", "添加App", "")]
        public TransactionResult<App> AddApp(App app)
        {
            TransactionResult<App> result = new TransactionResult<App>();
           
                var serviceResult = appService.Create(app);
           
            if (serviceResult.ActionResult & serviceResult.HavingData)
            {
                result.Data = serviceResult.Data;
            }
            else
            {
                result.Code = 103;
                result.Message = "暂无数据";
            }
            return result;
        }
        [HttpPost]
        [EnableCors("any")]
        [Desc("EditApp", "更新App", "根据主键更新数据")]
        public TransactionResult<Boolean> EditApp(App app)
        {
            TransactionResult<Boolean> result = new TransactionResult<Boolean>();
            var serviceResult = appService.UpdateByID(app);
            if (serviceResult.ActionResult)
            {
                result.Data = serviceResult.Data;
            }
            else
            {
                result.Code = 103;
                result.Message = "暂无数据";
            }
            return result;
        }
        [HttpPost]
        [EnableCors("any")]
        [Desc("DeleteApp", "删除App", "根据主键删除数据")]
        public TransactionResult<Boolean> DeleteApp(int appId)
        {
            TransactionResult<Boolean> result = new TransactionResult<Boolean>();
            var serviceResult = appService.DeleteByID(new List<int>() { appId });
            if (serviceResult.ActionResult)
            {
                result.Data = serviceResult.Data;
            }
            else
            {
                result.Code = 103;
                result.Message = "暂无数据";
            }
            return result;
        }
    }
}
