using Hayaa.BaseModel;
using Hayaa.BaseModel.Model;
using Hayaa.RemoteConfig.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.RemoteConfigController
{
    [Route("api/[controller]/[action]")]
    //[UserAuthorityFilter]
    public class AppConfigController: Controller
    {
        private IAppConfigService AppConfigService = new AppConfigServer();
        [HttpPost]
        [EnableCors("any")]
        [Desc("GetPager", "获取AppConfig分页列表", "根据appId获取AppConfig分页列表")]
        public TransactionResult<GridPager<AppConfig>> GetPager(int page, int size,int appId)
        {
            TransactionResult<GridPager<AppConfig>> result = new TransactionResult<GridPager<AppConfig>>();
            var serviceResult = AppConfigService.GetPager(new BaseModel.GridPagerPamater<RemoteConfig.Service.AppConfigSearchPamater>()
            {
                Current = page,
                PageSize = size,
                SearchPamater = new RemoteConfig.Service.AppConfigSearchPamater() { AppId=appId }
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
        [Desc("Get", "获取AppConfig", "根据主键获取数据")]
        public TransactionResult<AppConfig> Get(int id)
        {
            TransactionResult<AppConfig> result = new TransactionResult<AppConfig>();
            var serviceResult = AppConfigService.Get(id);
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
        [Desc("Add", "添加AppConfig", "")]
        public TransactionResult<AppConfig> Add(AppConfig info)
        {
            TransactionResult<AppConfig> result = new TransactionResult<AppConfig>();

            var serviceResult = AppConfigService.Create(info);

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
        [Desc("Edit", "更新AppConfig", "根据主键更新数据")]
        public TransactionResult<Boolean> Edit(AppConfig info)
        {
            TransactionResult<Boolean> result = new TransactionResult<Boolean>();
            var serviceResult = AppConfigService.UpdateByID(info);
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
        [Desc("Delete", "删除AppConfig", "根据主键删除数据")]
        public TransactionResult<Boolean> Delete(int id)
        {
            TransactionResult<Boolean> result = new TransactionResult<Boolean>();
            var serviceResult = AppConfigService.DeleteByID(new List<int>() { id });
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
        [Desc("AddComponentConfig", "添加组件配置", "")]
        public TransactionResult<Boolean> AddComponentConfig(int appConfigId, int componentConfigId)
        {
            TransactionResult<Boolean> result = new TransactionResult<Boolean>();
            var serviceResult = AppConfigService.AddComponentConfigForApp(componentConfigId, appConfigId);
            if (serviceResult.ActionResult&&serviceResult.Data)
            {
                result.Data = serviceResult.Data;
            }
            else
            {
                result.Code = 103;
                result.Message = serviceResult.ErrorMsg;
            }
            return result;
        }
        [HttpPost]
        [EnableCors("any")]
        [Desc("RemoveComponentConfig", "移除组件配置", "")]
        public TransactionResult<Boolean> RemoveComponentConfig(int appConfigId, int componentConfigId)
        {
            TransactionResult<Boolean> result = new TransactionResult<Boolean>();
            var serviceResult = AppConfigService.RemoveComponentConfigForApp(new List<int>() { componentConfigId }, appConfigId);
            if (serviceResult.ActionResult && serviceResult.Data)
            {
                result.Data = serviceResult.Data;
            }
            else
            {
                result.Code = 103;
                result.Message = serviceResult.ErrorMsg;
            }
            return result;
        }
        [HttpPost]
        [EnableCors("any")]
        [Desc("Remove10002ComponentConfig", "服务工厂移除组件配置", "")]
        public TransactionResult<Boolean> Remove10002ComponentConfig(int appConfigId)
        {
            TransactionResult<Boolean> result = new TransactionResult<Boolean>();
            var serviceResult = AppConfigService.Remove10002ComponentConfig(appConfigId);
            if (serviceResult.ActionResult && serviceResult.Data)
            {
                result.Data = serviceResult.Data;
            }
            else
            {
                result.Code = 103;
                result.Message = serviceResult.ErrorMsg;
            }
            return result;
        }
    }
}
