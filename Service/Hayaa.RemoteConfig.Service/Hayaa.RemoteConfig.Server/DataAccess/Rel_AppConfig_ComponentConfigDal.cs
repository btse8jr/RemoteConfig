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
    internal partial class Rel_AppConfig_ComponentConfigDal : CommonDal
    {
        private static String con = ConfigHelper.Instance.GetConnection(DefineTable.DatabaseName);
        internal static int Add(Rel_AppConfig_ComponentConfig info)
        {
            string sql = "insert into Rel_AppConfig_ComponentConfig(Id,AppConfigId,AppConfigVersion,SolutionID,ComponentConfigId,ComponentConfigVersion) values(@Id,@AppConfigId,@AppConfigVersion,@SolutionID,@ComponentConfigId,@ComponentConfigVersion)";
            return Insert<Rel_AppConfig_ComponentConfig>(con, sql, info);
        }
        internal static int Update(Rel_AppConfig_ComponentConfig info)
        {
            string sql = "update Rel_AppConfig_ComponentConfig set Id=@Id,AppConfigId=@AppConfigId,AppConfigVersion=@AppConfigVersion,SolutionID=@SolutionID,ComponentConfigId=@ComponentConfigId,ComponentConfigVersion=@ComponentConfigVersion where Rel_AppConfig_ComponentConfigId=@Rel_AppConfig_ComponentConfigId";
            return Insert<Rel_AppConfig_ComponentConfig>(con, sql, info);
        }
        internal static bool Delete(List<int> IDs)
        {
            string sql = "delete from  Rel_AppConfig_ComponentConfig where Rel_AppConfig_ComponentConfigId in @ids ";
            return Excute(con, sql, new { ids = IDs.ToArray() }) > 0;
        }
        internal static Rel_AppConfig_ComponentConfig Get(int Id)
        {
            string sql = "select * from Rel_AppConfig_ComponentConfig  where Rel_AppConfig_ComponentConfigId=@Rel_AppConfig_ComponentConfigId";
            return Get<Rel_AppConfig_ComponentConfig>(con, sql, new { Rel_AppConfig_ComponentConfigId = Id });
        }
        internal static List<Rel_AppConfig_ComponentConfig> GetList(Rel_AppConfig_ComponentConfigSearchPamater pamater)
        {
            string sql = "select * from Rel_AppConfig_ComponentConfig " + pamater.CreateWhereSql();
            return GetList<Rel_AppConfig_ComponentConfig>(con, sql, pamater);
        }
        internal static GridPager<Rel_AppConfig_ComponentConfig> GetGridPager(GridPagerPamater<Rel_AppConfig_ComponentConfigSearchPamater> pamater)
        {
            string sql = "select SQL_CALC_FOUND_ROWS * from Rel_AppConfig_ComponentConfig " + pamater.SearchPamater.CreateWhereSql() + " limit @Start,*@PageSize;select FOUND_ROWS();";
            pamater.SearchPamater.Start = (pamater.Current - 1) * pamater.PageSize;
            pamater.SearchPamater.PageSize = pamater.PageSize;
            return GetGridPager<Rel_AppConfig_ComponentConfig>(con, sql, pamater.PageSize, pamater.Current, pamater.SearchPamater);
        }
    }
}