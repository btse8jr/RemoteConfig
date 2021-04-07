using Hayaa.BaseModel.Model;
using Hayaa.Common;
using Hayaa.ConfigSeed.Standard.Model;
using Hayaa.ConfigSeed.Standard.Util;
using Hayaa.Netcore.SessionEncryption;
using Hayaa.RemoteConfig.Service;
using Hayaa.RPC.Service.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace Hayaa.ConfigSeed.Standard.Component
{
    class ProgramDistributedConfig
    {
        private AppConfig _appConfig;
        private AppLocalConfig _seedConfig;
        private static ProgramDistributedConfig _instance = new ProgramDistributedConfig();

        internal static ProgramDistributedConfig Instance
        {
            get
            {
                return _instance;
            }
        }
        private HttpRequestHelper _httpRequestHelper = new HttpRequestHelper();

        private ProgramDistributedConfig()
        {
            _appConfig = new AppConfig()
            {
                Components = new List<ComponentConfig>(),
                ConfigContent = "",
                SolutionID = "",
                SolutionName = "本地配置",
                Version = 0,
            };//构造函数默认对象内属性数值，默认为本地模式参数
            try
            {
                _seedConfig = ReadSeedConfig();//防止基础配置不存在或者错误导致程序无法启动
            }
            catch (Exception ex)
            {
                throw new Exception("无法读取App的Seed配置:" + ex.Message);//错误配置下扔出               
            }
        }

        /// <summary>
        /// 本地配置模式下只有一个方案序列化文件
        /// </summary>
        /// <param name="seedConfig"></param>
        private void ReadLocal(AppLocalConfig seedConfig, InitResult result)
        {
            if (string.IsNullOrEmpty(seedConfig.LocalConfigDirectoryPath))//如果没有默认路径不读取
            {
                result.Result = false;
                result.Message = "本地配置文件路径为空";
                return;//构造函数里默认数值
            }
            try
            {
                var temp = JsonHelper.Deserialize<AppConfig>(File.ReadAllText(seedConfig.LocalConfigDirectoryPath + "/" + seedConfig.AppConfigFileName));
                if (temp != null)//使用构造函数里的数值，避免多位置同效代码赋值
                {
                    _appConfig = temp;
                }
            }
            catch (Exception ex)//预期异常：格式错误，错误内容
            {
                throw new Exception("ReadLocal反序列化异常:" + ex.Message);
            }

        }
        /// <summary>
        /// 读取程序的配置
        /// </summary>
        /// <param name="seedConfig"></param>
        /// <returns></returns>
        private AppConfig ReadLocal(AppLocalConfig seedConfig)
        {
            if (string.IsNullOrEmpty(seedConfig.LocalConfigDirectoryPath))//如果没有默认路径和默认文件配置不读取
            {
                return null;//构造函数里默认数值
            }
            try
            {
                var temp = JsonHelper.Deserialize<AppConfig>(File.ReadAllText(seedConfig.LocalConfigDirectoryPath + "/" + seedConfig.AppConfigFileName));
                return temp;
            }
            catch (Exception ex)//预期异常：格式错误，错误内容
            {
                throw new Exception("ReadLocal反序列化异常:" + ex.Message);
            }

        }
        private void ReadRpcRemote(AppLocalConfig seedConfig)
        {
            AppConfig localconfig = null;
            //判断配置文件是否已经存在
            if (File.Exists(seedConfig.LocalConfigDirectoryPath + "/app.json"))
            {
                localconfig = ReadLocal(seedConfig);
            }

            //远程拉取配置文件
            Console.WriteLine("Rpc拉取配置文件:" + seedConfig.SeedServerUrl);
            var remoteConfig = GetRpcRemote(seedConfig.SeedServerUrl, seedConfig.AppConfigSolutionID, seedConfig.SecurityToken, seedConfig.Version.HasValue ? seedConfig.Version.Value : 0, seedConfig.AppID);
            //判断配置文件的新鲜程度
            if (remoteConfig != null)//无法获取远程配置时不更新本地
            {
                if (seedConfig.Version == 0)//永远最新
                {
                    File.Delete(seedConfig.LocalConfigDirectoryPath + "/" + seedConfig.AppConfigFileName);
                    //固化指定目录下制定的文件
                    File.AppendAllText(seedConfig.LocalConfigDirectoryPath + "/" + seedConfig.AppConfigFileName, JsonHelper.SerializeObject(remoteConfig));
                }
                Console.WriteLine("准备写入");
                if ((seedConfig.Version > 0) && (localconfig == null))//本地没有配置文件并且不是永远更新
                {
                    Console.WriteLine("写入：" + seedConfig.LocalConfigDirectoryPath);
                    File.AppendAllText(seedConfig.LocalConfigDirectoryPath + "/" + seedConfig.AppConfigFileName, JsonHelper.SerializeObject(remoteConfig));
                }
            }

        }
        /// <summary>
        /// 远程获取程序配置
        /// </summary>
        /// <param name="seedConfig"></param>
        private void ReadRemote(AppLocalConfig seedConfig)
        {            
            AppConfig localconfig = null;
            //判断配置文件是否已经存在
            if (File.Exists(seedConfig.LocalConfigDirectoryPath + "/app.json"))
            {
                localconfig = ReadLocal(seedConfig);
            }

            //远程拉取配置文件
            Console.WriteLine("远程拉取配置文件:" + seedConfig.SeedServerUrl);
            var remoteConfig = GetRemote(seedConfig.SeedServerUrl, seedConfig.AppConfigSolutionID, seedConfig.SecurityToken, seedConfig.Version.HasValue ? seedConfig.Version.Value : 0, seedConfig.AppID);
            //判断配置文件的新鲜程度
            if (remoteConfig != null)//无法获取远程配置时不更新本地
            {
                if (seedConfig.Version == 0)//永远最新
                {
                    File.Delete(seedConfig.LocalConfigDirectoryPath + "/" + seedConfig.AppConfigFileName);
                    //固化指定目录下制定的文件
                    File.AppendAllText(seedConfig.LocalConfigDirectoryPath + "/" + seedConfig.AppConfigFileName, JsonHelper.SerializeObject(remoteConfig));
                }
                Console.WriteLine("准备写入");
                if ((seedConfig.Version > 0) && (localconfig == null))//本地没有配置文件并且不是永远更新
                {
                    Console.WriteLine("写入：" + seedConfig.LocalConfigDirectoryPath);
                    File.AppendAllText(seedConfig.LocalConfigDirectoryPath + "/" + seedConfig.AppConfigFileName, JsonHelper.SerializeObject(remoteConfig));
                }
            }

        }
        private void ReReadRemote(AppLocalConfig seedConfig)
        {


            AppConfig localconfig = null;

            //远程拉取配置文件
            Console.WriteLine("远程拉取配置文件:"+ seedConfig.SeedServerUrl);
            var remoteConfig = GetRemote(seedConfig.SeedServerUrl, seedConfig.AppConfigSolutionID, seedConfig.SecurityToken, seedConfig.Version.HasValue ? seedConfig.Version.Value : 0, seedConfig.AppID);
            //判断配置文件的新鲜程度
            if (remoteConfig != null)//无法获取远程配置时不更新本地
            {
                if (seedConfig.Version == 0)//永远最新
                {
                    File.Delete(seedConfig.LocalConfigDirectoryPath + "/" + seedConfig.AppConfigFileName);
                    //固化指定目录下制定的文件
                    File.AppendAllText(seedConfig.LocalConfigDirectoryPath + "/" + seedConfig.AppConfigFileName, JsonHelper.SerializeObject(remoteConfig));
                }
                Console.WriteLine("准备写入");
                if ((seedConfig.Version > 0) && (localconfig == null))//本地没有配置文件并且不是永远更新
                {
                    Console.WriteLine("写入："+ seedConfig.LocalConfigDirectoryPath);
                    File.AppendAllText(seedConfig.LocalConfigDirectoryPath + "/" + seedConfig.AppConfigFileName, JsonHelper.SerializeObject(remoteConfig));
                }
            }

        }
        /// <summary>
        /// 获取远程配置内容
        /// </summary>
        /// <param name="url">远程配置服务地址</param>
        /// <param name="solutionID">app配置方案ID</param>
        /// <param name="token">app的安全令牌</param>
        /// <returns></returns>
        private AppConfig GetRemote(string url, Guid solutionID, string token, int version, int appId)
        {
            SessionEncryption se = new SessionEncryption();
            var dic = new Dictionary<string, string>();
            dic.Add("sid", solutionID.ToString());
            dic.Add("v", version.ToString());
            dic.Add("apt", se.Encrypt(token));
            dic.Add("appid", appId.ToString());
            string str = "";
            AppConfig result = null;
            Console.WriteLine("请求地址:" + url+";sid:"+ solutionID.ToString());
            str = _httpRequestHelper.Transaction(url, dic);
            //str = HttpUtility.UrlDecode(str);
            //str = str;//解密TODO，等待安全算法实现后替换
            Console.WriteLine("发送配置内容:"+str);
            try
            {
                var response = JsonHelper.Deserialize<TransactionResult<AppConfig>>(str);
                if (response.Code == 0)
                {
                    result = response.Data;
                }                
            }
            catch(Exception ex)
            {
                throw new Exception("远程结果:"+ str +"--异常:"+ ex.Message);
            }
            if (result == null)
            {
                throw new Exception("获取远程配置错误,远程结果:" + str);
            }

            return result;
        }
        private AppConfig GetRpcRemote(string url, Guid solutionID, string token, int version, int appId)
        {
            SessionEncryption se = new SessionEncryption();          
            AppConfig result = null;
            Console.WriteLine("请求地址:" + url + ";sid:" + solutionID.ToString());
            IRemoteConfigService remoteConfigService =RpcServiceFactory.CreateService<IRemoteConfigService>(typeof(IRemoteConfigService).FullName); 
            try
            {
                String guid = solutionID.ToString();
                var response = remoteConfigService.SendConfig(guid, version);
                if (response.ActionResult&&response.HavingData)
                {
                    result = response.Data;
                }
                else
                {
                    throw new Exception("无法获取远程配置错误:"+ response.ErrorMsg);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("远程结果异常:" + ex.Message);
            }
            if (result == null)
            {
                throw new Exception("获取远程配置错误");
            }

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private AppLocalConfig ReadSeedConfig()
        {
            AppLocalConfig r = new AppLocalConfig()
            {
                Remote = true,
                LocalConfigDirectoryPath = "~/Config",
                Version = 0
            };
            try
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;//获取根目录路径
                r = JsonHelper.Deserialize<AppLocalConfig>(File.ReadAllText(baseDirectory + "/appconfig.json", Encoding.UTF8));//读取根目录下的配置文件
                if (r.VirtualPath)//web系统相对部署根目录获取绝对路径
                {
                    r.LocalConfigDirectoryPath = baseDirectory + r.LocalConfigDirectoryPath.Replace("~/", "");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("无法读取根目录配置:"+ex.Message);
            }

            return r;
        }
        public void SetAppInstanceId(int appInstanceId)
        {
            try
            {
                _seedConfig.AppInstanceID = appInstanceId;
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;//获取根目录路径
                String strConfig = JsonHelper.SerializeObject(_seedConfig);
                File.WriteAllText((baseDirectory + "/appconfig.json"), strConfig, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public AppConfig GetAppConfig()
        {
            return ReadLocal(_seedConfig);
        }
        public bool IsEmpty()
        {
            if (_appConfig.SolutionID.Equals(Guid.Empty))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 在程序第一次运行时运行此方法获取配置
        /// </summary>
        /// <returns></returns>
        public InitResult InitAppConfig()
        {
            var r = new InitResult() { Result = true };
            if (_seedConfig.Remote)//判断是否读取远程配置模式
            {
                Console.WriteLine("获取远程");
                if (_seedConfig.RemoteType == 1)
                    ReadRemote(_seedConfig);//读取远程配置
                else
                    ReadRpcRemote(_seedConfig);
            }
            Console.WriteLine("读取本地");
            ReadLocal(_seedConfig, r);//读取本地配置 
            return r;
        }
        public InitResult ReAppConfig()
        {
            var r = new InitResult() { Result = true };
            if (_seedConfig.Remote)//判断是否读取远程配置模式
            {
                ReReadRemote(_seedConfig);//读取远程配置
            }
            ReadLocal(_seedConfig, r);//读取本地配置 
            return r;
        }
        public ComponentConfig GetComponentConfig(int componetID)
        {
            //构造函数完成无null初始化设置
            return _appConfig.Components.Find(c => c.ComponentId == componetID);
        }
        public AppLocalConfig GetSeedConfig()
        {
            return _seedConfig;
        }

    }
    internal class InitResult
    {
        public bool Result { set; get; }
        public string Message { set; get; }
    }
}
