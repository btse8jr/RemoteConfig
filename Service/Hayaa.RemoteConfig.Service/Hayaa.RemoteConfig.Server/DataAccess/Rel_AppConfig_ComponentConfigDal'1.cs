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
      
        internal static bool Delete(List<int> ComponentConfigIds,int appConfigId)
        {
            string sql = "delete from  Rel_AppConfig_ComponentConfig where Rel_AppConfig_ComponentConfigId in(@ids) and AppConfigId=@AppConfigId";
            return Excute(con, sql, new { ids = ComponentConfigIds.ToArray(), AppConfigId= appConfigId }) > 0;
        }
    }
}