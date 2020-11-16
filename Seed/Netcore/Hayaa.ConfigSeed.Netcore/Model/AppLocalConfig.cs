using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.ConfigSeed.Standard.Model
{
    /// <summary>
    /// 种子服务配置
    /// </summary>
    [Serializable]
    public class AppLocalConfig
    {
        /// <summary>
        /// 种子服务地址
        /// </summary>
        public string SeedServerUrl { set; get; }
        /// <summary>
        /// 本地模式下配置目录存储路径
        /// </summary>
        public string LocalConfigDirectoryPath { set; get; }
        /// <summary>
        /// 存储路径是否相对路径目录
        /// 需要以~作为开始符
        /// </summary>
        public bool IsVirtualPath { set; get; }

        /// <summary>
        /// 安全令牌
        /// </summary>
        public string SecurityToken { get; set; }
        /// <summary>
        /// 承载服务程序ID
        /// </summary>
        public int AppID { set; get; }
        /// <summary>
        /// 程序运行实例Id
        /// </summary>
        public int AppInstanceID { set; get; }
        /// <summary>
        /// 程序配置方案ID
        /// 一个APP可以有多个配置方案        
        /// </summary>
        public Guid AppConfigSolutionID
        {
            get;
            set;
        }
        /// <summary>
        /// 程序配置方案版本
        /// 一个配置方案可以有多个版本
        /// 不设置表示表示获取最新
        /// </summary>
        public int? Version
        {
            get;
            set;
        }
        /// <summary>
        /// 配置模式是否远程化
        /// </summary>
        public bool IsRemote
        {
            get;
            set;
        }
        /// <summary>
        /// 程序配置文件名
        /// </summary>
        public string AppConfigFileName
        {
            get;
            set;
        }
    }
}
