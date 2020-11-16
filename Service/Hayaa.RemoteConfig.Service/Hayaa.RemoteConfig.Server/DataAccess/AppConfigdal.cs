using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.DataAccess;
using Hayaa.BaseModel;
using Hayaa.RemoteConfig.Service.Config;
using Hayaa.RemoteService;

/// <summary>
///代码效率工具生成，此文件不要修改
/// </summary>
namespace Hayaa.RemoteConfig.Service.Dao
{
    internal partial class AppConfigDal : CommonDal
    {
        private static String con = ConfigHelper.Instance.GetConnection(DefineTable.DatabaseName);
        internal static int Add(AppConfig info)
        {
            string sql = "insert into AppConfig(AppId,SolutionID,SolutionName,ConfigContent,Version) values(@AppId,@SolutionID,@SolutionName,@ConfigContent,@Version)";
            return Insert<AppConfig>(con, sql, info);
        }

       

        internal static int Update(AppConfig info)
        {
            string sql = "update AppConfig set SolutionID=@SolutionID,SolutionName=@SolutionName,ConfigContent=@ConfigContent,Version=@Version where AppConfigId=@AppConfigId";
            return Update<AppConfig>(con, sql, info);
        }
        internal static bool Delete(List<int> IDs)
        {
            string sql = "delete from  AppConfig where AppConfigId in @ids";
            return Excute(con, sql, new { ids = IDs.ToArray() }) > 0;
        }
        internal static AppConfig Get(int Id)
        {
            string sql = "select * from AppConfig  where AppConfigId=@AppConfigId";
            return Get<AppConfig>(con, sql, new { AppConfigId = Id });
        }
        internal static List<AppConfig> GetList(AppConfigSearchPamater pamater)
        {
            string sql = "select * from AppConfig " + pamater.CreateWhereSql();
            return GetList<AppConfig>(con, sql, pamater);
        }
        internal static GridPager<AppConfig> GetGridPager(GridPagerPamater<AppConfigSearchPamater> pamater)
        {
            string sql = "select SQL_CALC_FOUND_ROWS * from AppConfig " + pamater.SearchPamater.CreateWhereSql() + " limit @Start,*@PageSize;select FOUND_ROWS();";
            pamater.SearchPamater.Start = (pamater.Current - 1) * pamater.PageSize;
            pamater.SearchPamater.PageSize = pamater.PageSize;
            return GetGridPager<AppConfig>(con, sql, pamater.PageSize, pamater.Current, pamater.SearchPamater);
        }
    }
}