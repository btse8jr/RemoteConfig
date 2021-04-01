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
    internal partial class ComponentConfigDal : CommonDal
    {
        private static String con = ConfigHelper.Instance.GetConnection(DefineTable.DatabaseName);
        internal static int Add(ComponentConfig info)
        {
            string sql = "insert into ComponentConfig(ComponentId,Content,Version,ComponentConfigTitle,IsDefault) values(@ComponentId,@Content,@Version,@ComponentConfigTitle,@IsDefault);select @@IDENTITY;";
            return InsertWithReturnID<ComponentConfig,int>(con, sql, info);
        }
        internal static int Update(ComponentConfig info)
        {
            string sql = "update ComponentConfig set ComponentId=@ComponentId,Content=@Content,Version=@Version,ComponentConfigTitle=@ComponentConfigTitle,IsDefault=@IsDefault where ComponentConfigId=@ComponentConfigId";
            return Update<ComponentConfig>(con, sql, info);
        }
        internal static bool Delete(List<int> IDs)
        {
            string sql = "delete from  ComponentConfig where ComponentConfigId in @ids ";
            return Excute(con, sql, new { ids = IDs.ToArray() }) > 0;
        }
        internal static ComponentConfig Get(int Id)
        {
            string sql = "select * from ComponentConfig  where ComponentConfigId=@ComponentConfigId";
            return Get<ComponentConfig>(con, sql, new { ComponentConfigId = Id });
        }
        internal static List<ComponentConfig> GetList(ComponentConfigSearchPamater pamater)
        {
            string sql = "select * from ComponentConfig " + pamater.CreateWhereSql();
            return GetList<ComponentConfig>(con, sql, pamater);
        }
        internal static GridPager<ComponentConfig> GetGridPager(GridPagerPamater<ComponentConfigSearchPamater> pamater)
        {
            string sql = "select SQL_CALC_FOUND_ROWS * from ComponentConfig " + pamater.SearchPamater.CreateWhereSql() + " limit @Start,@PageSize;select FOUND_ROWS();";
            pamater.SearchPamater.Start = (pamater.Current - 1) * pamater.PageSize;
            pamater.SearchPamater.PageSize = pamater.PageSize;
            return GetGridPager<ComponentConfig>(con, sql, pamater.PageSize, pamater.Current, pamater.SearchPamater);
        }
    }
}