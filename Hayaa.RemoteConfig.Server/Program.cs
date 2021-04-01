using Hayaa.RemoteConfig.Client;
using Hayaa.RemoteConfig.Server.Config;
using Hayaa.RPC.Service.Server;
using System;

namespace Hayaa.RemoteConfig.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            AppSeed.Instance.InitConfig();
            RpcServer rpcServer = new RpcServer();
            var rpcServerConfig = ConfigHelper.Instance.GetComponentConfig();
            if ((rpcServerConfig == null) || (rpcServerConfig.ServiceConfig == null))
            {
                Console.WriteLine("RPC服务端未配置");
            }
            else
                rpcServer.Run(rpcServerConfig.ServiceConfig);
        }
    }
}
