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
    internal partial class ComponentDal : CommonDal
    {
        private static String con = ConfigHelper.Instance.GetConnection(DefineTable.DatabaseName);
        internal static int Add(Component info)
        {
            string sql = "insert into Component(ComponentId,Name,Title) values(@ComponentId,@Name,@Title)";
            return Insert<Component>(con, sql, info);
        }
        internal static int Update(Component info)
        {
            string sql = "update Component set Name=@Name,Title=@Title where ComponentId=@ComponentId";
            return Update<Component>(con, sql, info);
        }
        internal static bool Delete(List<int> IDs)
        {
            string sql = "delete from  Component where ComponentId in @ids ";
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
            string sql = "select SQL_CALC_FOUND_ROWS * from Component " + pamater.SearchPamater.CreateWhereSql() + " limit @Start,@PageSize;select FOUND_ROWS();";
            pamater.SearchPamater.Start = (pamater.Current - 1) * pamater.PageSize;
            pamater.SearchPamater.PageSize = pamater.PageSize;
            return GetGridPager<Component>(con, sql, pamater.PageSize, pamater.Current, pamater.SearchPamater);
        }
    }
}