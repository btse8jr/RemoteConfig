using Hayaa.BaseModel.Model;
using Hayaa.RemoteService;
using Hayaa.Security.Client;
using Hayaa.ServicePlatform.Client;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Hayaa.RemoteConfigController
{
    [Route("api/[controller]")]
    public class ConfigController : Controller
    {
        private RemoteConfigService service = PlatformServiceFactory.Instance.CreateService<RemoteConfigService>(AppRoot.GetDefaultAppUser());
        [HttpPost]
        [AppInstanceBaseAuthorityFilter]
        public TransactionResult<AppConfig> SendConfig(Guid sid, int v)
        {
            TransactionResult<AppConfig> result = new TransactionResult<AppConfig>();
            var serviceResult = service.SendConfig(sid, v);
            if (serviceResult.ActionResult & serviceResult.HavingData)
            {
                result.Data = serviceResult.Data;
            }
            return result;
        }
    }
}
