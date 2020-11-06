using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.DataAccess;
using Hayaa.BaseModel;
using Hayaa.RemoteConfig.Service.Config;
using Hayaa.RemoteService;


namespace Hayaa.RemoteConfig.Service.Dao
{
    internal partial class ComponentConfigDal 
    {
       
        internal static List<ComponentConfig> GetList(int appConfigId,int version)
        {
            string sql = "select cc.* from ComponentConfig as cc inner join Rel_AppConfig_ComponentConfig raccc on cc.ComponentConfigId=raccc.ComponentConfigId and cc.Version=ComponentConfigVersion  where raccc.AppConfigId=@AppConfigId and raccc.AppConfigVersion=@Version";
            return GetList<ComponentConfig>(con, sql, new{ AppConfigId=appConfigId, Version= version });
        }
        
    }
}