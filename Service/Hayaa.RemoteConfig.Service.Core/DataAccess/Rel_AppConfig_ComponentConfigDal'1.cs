using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.DataAccess;
using Hayaa.BaseModel;
using Hayaa.RemoteConfig.Service.Config;
/// <summary>
///代码效率工具生成，此文件不要修改
/// </summary>
namespace Hayaa.RemoteConfig.Service.Dao
{
    internal partial class Rel_AppConfig_ComponentConfigDal
    {
        internal static Rel_AppConfig_ComponentConfig Get(int appConfigId, int componentConfigId)
        {
            string sql = "select * from Rel_AppConfig_ComponentConfig  where AppConfigId=@AppConfigId and ComponentConfigId=@ComponentConfigId";
            return Get<Rel_AppConfig_ComponentConfig>(con, sql, new { AppConfigId = appConfigId, ComponentConfigId = componentConfigId });
        }
        internal static bool Delete(List<int> ComponentConfigIds,int appConfigId)
        {
            string sql = "delete from  Rel_AppConfig_ComponentConfig where ComponentConfigId in @ids and AppConfigId=@AppConfigId";
            return Excute(con, sql, new { ids = ComponentConfigIds.ToArray(), AppConfigId= appConfigId }) > 0;
        }
        internal static bool Delete(int appConfigId, int componentConfigId)
        {
            string sql = "delete from  Rel_AppConfig_ComponentConfig where AppConfigId=@AppConfigId and ComponentConfigId=@ComponentConfigId";
            return Excute(con, sql, new { AppConfigId = appConfigId, ComponentConfigId= componentConfigId }) > 0;
        }
        internal static bool Delete10002(int appConfigId)
        {
            string sql = "delete racc from  Rel_AppConfig_ComponentConfig racc inner join ComponentConfig cc on racc.ComponentConfigId = cc.ComponentConfigId  and racc.AppConfigId =@AppConfigId and cc.ComponentId = 10002";
            return Excute(con, sql, new { AppConfigId = appConfigId }) > 0;
        }
    }
}