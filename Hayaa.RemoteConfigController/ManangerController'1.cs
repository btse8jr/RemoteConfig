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
