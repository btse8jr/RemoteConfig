using Hayaa.BaseModel.Model;
using Hayaa.RemoteConfig.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Hayaa.RemoteConfigController
{
    [Route("api/[controller]/[action]")]
    public class ConfigController : Controller
    {
        private IRemoteConfigService service = new RemoteConfigServer();
        [HttpPost]
        [Desc("SendConfig", "获取远程配置服务", "")]
        public TransactionResult<AppConfig> SendConfig(String sid, int v)
        {
            TransactionResult<AppConfig> result = new TransactionResult<AppConfig>();
            //var serviceResult = service.SendConfig(sid, v);
            //if (serviceResult.ActionResult & serviceResult.HavingData)
            //{
            //    result.Data = serviceResult.Data;
            //}
            return result;
        }
        [HttpPost]
        [EnableCors("any")]
        [Desc("SendJsAppConfig", "获取js配置服务", "")]
        public TransactionResult<AppConfig> SendJsAppConfig(String sid, int v)
        {
            TransactionResult<AppConfig> result = new TransactionResult<AppConfig>();
            var serviceResult = service.SendJsAppConfig(sid, v);
            if (serviceResult.ActionResult & serviceResult.HavingData)
            {
                result.Data = serviceResult.Data;
            }
            return result;
        }
    }
}
