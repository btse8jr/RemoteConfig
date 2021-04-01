using Hayaa.RemoteConfig.Client;
using Hayaa.RPC.Common.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.RemoteConfig.Server.Config
{
    /// <summary>
    /// 服务配置类
    /// </summary>
    [Serializable]
    internal class RemoteServiceConfig: ConfigContent
    {
       
        public AppSettings AppSettings { set; get; }
        public ConnectionStrings ConnectionStrings { set; get; }
        public RPCConfig ServiceConfig { set; get; }
    }
}
