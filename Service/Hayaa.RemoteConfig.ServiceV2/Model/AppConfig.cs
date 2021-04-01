using Hayaa.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.RemoteConfig.Service
{
    /// <summary>
    /// 宿主程序配置方案
    /// </summary>
    [Serializable]
    public class AppConfig : BaseData
    {
        /// <summary>
        /// 配置数据ID
        /// </summary>	
        public int AppConfigId
        {
            get;
            set;
        }
        /// <summary>
        /// AppId
        /// </summary>
        public int AppId { set; get; }
        /// <summary>
        /// 解决方案ID
        /// </summary>	
        public String SolutionID
        {
            get;
            set;
        }
        /// <summary>
        /// 解决方案名称
        /// </summary>	
        public string SolutionName
        {
            get;
            set;
        }
        /// <summary>
        /// App级别配置内容
        /// </summary>	
        public string ConfigContent
        {
            get;
            set;
        }

        /// <summary>
        /// 程序配置方案版本 
        /// </summary>
        public int Version
        {
            get;
            set;
        }
        /// <summary>
        /// 程序组件配置内容
        /// </summary>
        public List<ComponentConfig> Components { get; set; }


    }
}
