using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.DataAccess;
using Hayaa.BaseModel;
using Hayaa.RemoteService.Core.Config;
namespace Hayaa.RemoteService.DataAccess
{
    public class AppDal : CommonDal
    {
        private static String con = ConfigHelper.Instance.GetConnection(DefineTable.RemoteDatabaseName);
        internal static int Add(App info)
        {
            string sql = "insert into App(Title,Name,CreateTime) values(@Title,@Name,@CreateTime);select @@IDENTITY;";
            return InsertWithReturnID<App,int>(con, sql, info);
        }
        internal static int Update(App info)
        {
            string sql = "update App set Title=@Title,Name=@Name where AppId=@AppId";
            return Insert<App>(con, sql, info);
        }
        internal static bool Delete(List<int> IDs)
        {
            string sql = "delete from  App where AppId in(@ids)";
            return Excute(con, sql, new { ids = IDs.ToArray() }) > 0;
        }
        internal static App Get(int Id)
        {
            string sql = "select * from App  where AppId=@AppId";
            return Get<App>(con, sql, new { AppId = Id });
        }
        internal static List<App> GetList(AppSearchPamater pamater)
        {
            string sql = "select * from App " + pamater.CreateWhereSql();
            return GetList<App>(con, sql, pamater);
        }
        internal static GridPager<App> GetGridPager(GridPagerPamater<AppSearchPamater> pamater)
        {
            string sql = "select SQL_CALC_FOUND_ROWS * from App " + pamater.SearchPamater.CreateWhereSql() + " limit @Start,@PageSize;select FOUND_ROWS();";
            pamater.SearchPamater.Start = (pamater.Current-1)* pamater.PageSize;
            pamater.SearchPamater.PageSize = pamater.PageSize;
            return GetGridPager<App>(con, sql, pamater.PageSize, pamater.Current, pamater.SearchPamater);
        }
    }
}