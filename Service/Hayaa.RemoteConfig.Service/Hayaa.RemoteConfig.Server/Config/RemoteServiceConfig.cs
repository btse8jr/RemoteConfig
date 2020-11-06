using Hayaa.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.RemoteConfig.Service.Config
{
    /// <summary>
    /// 服务配置类
    /// </summary>
    [Serializable]
    internal class RemoteServiceConfig:BaseData, ConfigContent
    {
       
        public AppSettings AppSettings { set; get; }
        public ConnectionStrings ConnectionStrings { set; get; }
    }
}
