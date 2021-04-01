using System;
using System.Collections.Generic;
using Hayaa.BaseModel;
/// <summary>
///代码效率工具生成，此文件不要修改
/// </summary>
namespace Hayaa.RemoteConfig.Service
{
    public class Rel_AppConfig_ComponentConfigSearchPamater : SearchPamaterMariadbBase
    {
        public int? Id { set; get; }
        public List<int?> IdList { set; get; }
        public int? IdMax { set; get; }
        public int? IdMin { set; get; }
        public void SetId(int? max, int? min) { this.IdMax = max; this.IdMin = min; this.IdPOT = PamaterOperationType.Between; }
        private PamaterOperationType IdPOT;
        public void SetId(int? info, PamaterOperationType pot) { this.Id = info; this.IdPOT = pot; }
        private String GetIdSqlForSharp()
        {
            String sql = ""; switch (IdPOT)
            {
                case PamaterOperationType.Between: sql = "Id between @IdMin to @IdMax"; break;
                case PamaterOperationType.StringContains: sql = "Id like '%@Id%'"; break;
                case PamaterOperationType.Equal: sql = "Id=@Id"; break;
                case PamaterOperationType.GreaterEqual: sql = "Id>=@Id"; break;
                case PamaterOperationType.GreaterThan: sql = "Id>@Id"; break;
                case PamaterOperationType.LessEqual: sql = "Id<=@Id"; break;
                case PamaterOperationType.LessThan: sql = "Id<=@Id"; break;
                case PamaterOperationType.In: sql = "Id in(" + String.Join(",", this.IdList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "Id in('" + String.Join("','", this.IdList) + "')"; break;
            }
            return sql;
        }
        public int? AppConfigId { set; get; }
        public List<int?> AppConfigIdList { set; get; }
        public int? AppConfigIdMax { set; get; }
        public int? AppConfigIdMin { set; get; }
        public void SetAppConfigId(int? max, int? min) { this.AppConfigIdMax = max; this.AppConfigIdMin = min; this.AppConfigIdPOT = PamaterOperationType.Between; }
        private PamaterOperationType AppConfigIdPOT;
        public void SetAppConfigId(int? info, PamaterOperationType pot) { this.AppConfigId = info; this.AppConfigIdPOT = pot; }
        private String GetAppConfigIdSqlForSharp()
        {
            String sql = ""; switch (AppConfigIdPOT)
            {
                case PamaterOperationType.Between: sql = "AppConfigId between @AppConfigIdMin to @AppConfigIdMax"; break;
                case PamaterOperationType.StringContains: sql = "AppConfigId like '%@AppConfigId%'"; break;
                case PamaterOperationType.Equal: sql = "AppConfigId=@AppConfigId"; break;
                case PamaterOperationType.GreaterEqual: sql = "AppConfigId>=@AppConfigId"; break;
                case PamaterOperationType.GreaterThan: sql = "AppConfigId>@AppConfigId"; break;
                case PamaterOperationType.LessEqual: sql = "AppConfigId<=@AppConfigId"; break;
                case PamaterOperationType.LessThan: sql = "AppConfigId<=@AppConfigId"; break;
                case PamaterOperationType.In: sql = "AppConfigId in(" + String.Join(",", this.AppConfigIdList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "AppConfigId in('" + String.Join("','", this.AppConfigIdList) + "')"; break;
            }
            return sql;
        }
        public int? AppConfigVersion { set; get; }
        public List<int?> AppConfigVersionList { set; get; }
        public int? AppConfigVersionMax { set; get; }
        public int? AppConfigVersionMin { set; get; }
        public void SetAppConfigVersion(int? max, int? min) { this.AppConfigVersionMax = max; this.AppConfigVersionMin = min; this.AppConfigVersionPOT = PamaterOperationType.Between; }
        private PamaterOperationType AppConfigVersionPOT;
        public void SetAppConfigVersion(int? info, PamaterOperationType pot) { this.AppConfigVersion = info; this.AppConfigVersionPOT = pot; }
        private String GetAppConfigVersionSqlForSharp()
        {
            String sql = ""; switch (AppConfigVersionPOT)
            {
                case PamaterOperationType.Between: sql = "AppConfigVersion between @AppConfigVersionMin to @AppConfigVersionMax"; break;
                case PamaterOperationType.StringContains: sql = "AppConfigVersion like '%@AppConfigVersion%'"; break;
                case PamaterOperationType.Equal: sql = "AppConfigVersion=@AppConfigVersion"; break;
                case PamaterOperationType.GreaterEqual: sql = "AppConfigVersion>=@AppConfigVersion"; break;
                case PamaterOperationType.GreaterThan: sql = "AppConfigVersion>@AppConfigVersion"; break;
                case PamaterOperationType.LessEqual: sql = "AppConfigVersion<=@AppConfigVersion"; break;
                case PamaterOperationType.LessThan: sql = "AppConfigVersion<=@AppConfigVersion"; break;
                case PamaterOperationType.In: sql = "AppConfigVersion in(" + String.Join(",", this.AppConfigVersionList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "AppConfigVersion in('" + String.Join("','", this.AppConfigVersionList) + "')"; break;
            }
            return sql;
        }
        public String SolutionID { set; get; }
        public List<String> SolutionIDList { set; get; }
        private PamaterOperationType SolutionIDPOT;
        public void SetSolutionID(String info, PamaterOperationType pot) { this.SolutionID = info; this.SolutionIDPOT = pot; }
        private String GetSolutionIDSqlForSharp()
        {
            String sql = ""; switch (SolutionIDPOT)
            {
                case PamaterOperationType.Between: sql = "SolutionID between @SolutionIDMin to @SolutionIDMax"; break;
                case PamaterOperationType.StringContains: sql = "SolutionID like '%@SolutionID%'"; break;
                case PamaterOperationType.Equal: sql = "SolutionID=@SolutionID"; break;
                case PamaterOperationType.GreaterEqual: sql = "SolutionID>=@SolutionID"; break;
                case PamaterOperationType.GreaterThan: sql = "SolutionID>@SolutionID"; break;
                case PamaterOperationType.LessEqual: sql = "SolutionID<=@SolutionID"; break;
                case PamaterOperationType.LessThan: sql = "SolutionID<=@SolutionID"; break;
                case PamaterOperationType.In: sql = "SolutionID in(" + String.Join(",", this.SolutionIDList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "SolutionID in('" + String.Join("','", this.SolutionIDList) + "')"; break;
            }
            return sql;
        }
        public int? ComponentConfigId { set; get; }
        public List<int?> ComponentConfigIdList { set; get; }
        public int? ComponentConfigIdMax { set; get; }
        public int? ComponentConfigIdMin { set; get; }
        public void SetComponentConfigId(int? max, int? min) { this.ComponentConfigIdMax = max; this.ComponentConfigIdMin = min; this.ComponentConfigIdPOT = PamaterOperationType.Between; }
        private PamaterOperationType ComponentConfigIdPOT;
        public void SetComponentConfigId(int? info, PamaterOperationType pot) { this.ComponentConfigId = info; this.ComponentConfigIdPOT = pot; }
        private String GetComponentConfigIdSqlForSharp()
        {
            String sql = ""; switch (ComponentConfigIdPOT)
            {
                case PamaterOperationType.Between: sql = "ComponentConfigId between @ComponentConfigIdMin to @ComponentConfigIdMax"; break;
                case PamaterOperationType.StringContains: sql = "ComponentConfigId like '%@ComponentConfigId%'"; break;
                case PamaterOperationType.Equal: sql = "ComponentConfigId=@ComponentConfigId"; break;
                case PamaterOperationType.GreaterEqual: sql = "ComponentConfigId>=@ComponentConfigId"; break;
                case PamaterOperationType.GreaterThan: sql = "ComponentConfigId>@ComponentConfigId"; break;
                case PamaterOperationType.LessEqual: sql = "ComponentConfigId<=@ComponentConfigId"; break;
                case PamaterOperationType.LessThan: sql = "ComponentConfigId<=@ComponentConfigId"; break;
                case PamaterOperationType.In: sql = "ComponentConfigId in(" + String.Join(",", this.ComponentConfigIdList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "ComponentConfigId in('" + String.Join("','", this.ComponentConfigIdList) + "')"; break;
            }
            return sql;
        }
        public int? ComponentConfigVersion { set; get; }
        public List<int?> ComponentConfigVersionList { set; get; }
        public int? ComponentConfigVersionMax { set; get; }
        public int? ComponentConfigVersionMin { set; get; }
        public void SetComponentConfigVersion(int? max, int? min) { this.ComponentConfigVersionMax = max; this.ComponentConfigVersionMin = min; this.ComponentConfigVersionPOT = PamaterOperationType.Between; }
        private PamaterOperationType ComponentConfigVersionPOT;
        public void SetComponentConfigVersion(int? info, PamaterOperationType pot) { this.ComponentConfigVersion = info; this.ComponentConfigVersionPOT = pot; }
        private String GetComponentConfigVersionSqlForSharp()
        {
            String sql = ""; switch (ComponentConfigVersionPOT)
            {
                case PamaterOperationType.Between: sql = "ComponentConfigVersion between @ComponentConfigVersionMin to @ComponentConfigVersionMax"; break;
                case PamaterOperationType.StringContains: sql = "ComponentConfigVersion like '%@ComponentConfigVersion%'"; break;
                case PamaterOperationType.Equal: sql = "ComponentConfigVersion=@ComponentConfigVersion"; break;
                case PamaterOperationType.GreaterEqual: sql = "ComponentConfigVersion>=@ComponentConfigVersion"; break;
                case PamaterOperationType.GreaterThan: sql = "ComponentConfigVersion>@ComponentConfigVersion"; break;
                case PamaterOperationType.LessEqual: sql = "ComponentConfigVersion<=@ComponentConfigVersion"; break;
                case PamaterOperationType.LessThan: sql = "ComponentConfigVersion<=@ComponentConfigVersion"; break;
                case PamaterOperationType.In: sql = "ComponentConfigVersion in(" + String.Join(",", this.ComponentConfigVersionList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "ComponentConfigVersion in('" + String.Join("','", this.ComponentConfigVersionList) + "')"; break;
            }
            return sql;
        }
        public DateTime? CreateTime { set; get; }
        public List<DateTime?> CreateTimeList { set; get; }
        public DateTime? CreateTimeMax { set; get; }
        public DateTime? CreateTimeMin { set; get; }
        public void SetCreateTime(DateTime? max, DateTime? min) { this.CreateTimeMax = max; this.CreateTimeMin = min; this.CreateTimePOT = PamaterOperationType.Between; }
        private PamaterOperationType CreateTimePOT;
        public void SetCreateTime(DateTime? info, PamaterOperationType pot) { this.CreateTime = info; this.CreateTimePOT = pot; }
        private String GetCreateTimeSqlForSharp()
        {
            String sql = ""; switch (CreateTimePOT)
            {
                case PamaterOperationType.Between: sql = "CreateTime between @CreateTimeMin to @CreateTimeMax"; break;
                case PamaterOperationType.StringContains: sql = "CreateTime like '%@CreateTime%'"; break;
                case PamaterOperationType.Equal: sql = "CreateTime=@CreateTime"; break;
                case PamaterOperationType.GreaterEqual: sql = "CreateTime>=@CreateTime"; break;
                case PamaterOperationType.GreaterThan: sql = "CreateTime>@CreateTime"; break;
                case PamaterOperationType.LessEqual: sql = "CreateTime<=@CreateTime"; break;
                case PamaterOperationType.LessThan: sql = "CreateTime<=@CreateTime"; break;
                case PamaterOperationType.In: sql = "CreateTime in(" + String.Join(",", this.CreateTimeList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "CreateTime in('" + String.Join("','", this.CreateTimeList) + "')"; break;
            }
            return sql;
        }
    }
}