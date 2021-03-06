using Hayaa.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.RemoteService
{
    /// <summary>
    /// 程序组件配置方案
    /// </summary>
    [Serializable]
    public class ComponentConfig : BaseData
    {      
        /// <summary>
        /// 组件配置ID
        /// </summary>	

        public int ComponentConfigId
        {
            get;
            set;
        }
        /// <summary>
        /// 组件ID
        /// </summary>		

        public int ComponentId
        {
            get;
            set;
        }
        /// <summary>
        /// 组件配置内容
        /// </summary>		

        public string Content
        {
            get;
            set;
        }
        /// <summary>
        /// 配置内容版本
        /// </summary>	

        public int Version
        {
            get;
            set;
        }
        /// <summary>
        /// 配置标题
        /// </summary>

        public string ComponentConfigTitle { get; set; }
        /// <summary>
        /// 是否App的组件默认配置
        /// </summary>
        public bool IsDefault { set; get; }
    }
}
