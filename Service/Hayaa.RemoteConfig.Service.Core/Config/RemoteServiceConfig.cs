using Hayaa.RemoteConfig.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.RemoteConfig.Service.Config
{
    /// <summary>
    /// 服务配置类
    /// </summary>
    [Serializable]
    internal class RemoteServiceConfig: ConfigContent
    {
       
        public AppSettings AppSettings { set; get; }
        public ConnectionStrings ConnectionStrings { set; get; }
    }
}
