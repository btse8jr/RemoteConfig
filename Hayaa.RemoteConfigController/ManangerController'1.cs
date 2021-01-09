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
    
    public partial  class ManangerController
    {
        private ComponentService componentService = new ComponentServer(); //PlatformServiceFactory.Instance.CreateService<AppService>(AppRoot.GetDefaultAppUser());
        [HttpPost]
        [EnableCors("any")]
        [Desc("GetPager", "获取Component分页列表", "")]
        public TransactionResult<GridPager<Component>> GetComponentPager(int page,int size)
        {
            TransactionResult<GridPager<Component>> result = new TransactionResult<GridPager<Component>>();
            var serviceResult = componentService.GetPager(new BaseModel.GridPagerPamater<RemoteConfig.Service.ComponentSearchPamater>() {
                 Current=page, PageSize=size, SearchPamater=new RemoteConfig.Service.ComponentSearchPamater()
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
        [Desc("Get", "获取Component", "根据主键获取数据")]
        public TransactionResult<Component> GetComponent(int id)
        {
            TransactionResult<Component> result = new TransactionResult<Component>();
            var serviceResult = componentService.Get(id);
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
        [Desc("AddComponent", "添加Component", "")]
        public TransactionResult<Component> AddComponent(Component info)
        {
            TransactionResult<Component> result = new TransactionResult<Component>();
           
                var serviceResult = componentService.Create(info);
           
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
        [Desc("EditComponent", "更新Component", "根据主键更新数据")]
        public TransactionResult<Boolean> EditComponent(Component info)
        {
            TransactionResult<Boolean> result = new TransactionResult<Boolean>();
            var serviceResult = componentService.UpdateByID(info);
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
        [Desc("DeleteComponent", "删除Component", "根据主键删除数据")]
        public TransactionResult<Boolean> DeleteComponent(int id)
        {
            TransactionResult<Boolean> result = new TransactionResult<Boolean>();
            var serviceResult = componentService.DeleteByID(new List<int>() { id });
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
