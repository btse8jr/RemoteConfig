using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.DataAccess;
using Hayaa.BaseModel;
using Hayaa.RemoteService.Core.Config;
namespace Hayaa.RemoteService.DataAccess
{
    public class ComponentDal : CommonDal
    {
        private static String con = ConfigHelper.Instance.GetConnection("Component");
        internal static int Add(Component info)
        {
            string sql = "insert into Component(ComponentID,Name,Title,CreateTime) values(@ComponentID,@Name,@Title,@CreateTime)";
            return Insert<Component>(con, sql, info);
        }
        internal static int Update(Component info)
        {
            string sql = "update Component set ComponentID=@ComponentID,Name=@Name,Title=@Title,ModifyTime=@ModifyTime where ComponentId=@ComponentId";
            return Insert<Component>(con, sql, info);
        }
        internal static bool Delete(List<int> IDs)
        {
            string sql = "delete from  Component where ComponentId in(@ids)";
            return Excute(con, sql, new { ids = IDs.ToArray() }) > 0;
        }
        internal static Component Get(int Id)
        {
            string sql = "select * from Component  where ComponentId=@ComponentId";
            return Get<Component>(con, sql, new { ComponentId = Id });
        }
        internal static List<Component> GetList(ComponentSearchPamater pamater)
        {
            string sql = "select * from Component " + pamater.CreateWhereSql();
            return GetList<Component>(con, sql, pamater);
        }
        internal static GridPager<Component> GetGridPager(GridPagerPamater<ComponentSearchPamater> pamater)
        {
            string sql = "select SQL_CALC_FOUND_ROWS * from Component " + pamater.SearchPamater.CreateWhereSql() + " limit (@pageIndex-1)*@pageSize,@pageIndex*@pageSize;select FOUND_ROWS();";
            return GetGridPager<Component>(con, sql, pamater.PageSize, pamater.Current, pamater.SearchPamater);
        }
    }
}