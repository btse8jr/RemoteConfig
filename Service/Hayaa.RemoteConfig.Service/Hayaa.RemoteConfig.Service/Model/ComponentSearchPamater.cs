using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.BaseModel;
namespace Hayaa.RemoteService
{
    public class ComponentSearchPamater : SearchPamaterMariadbBase
    {
        public int? ComponentID { set; get; }
        public List<int?> ComponentIDList { set; get; }
        public int? ComponentIDMax { set; get; }
        public int? ComponentIDMin { set; get; }
        public void SetComponentID(int? max, int? min) { this.ComponentIDMax = max; this.ComponentIDMin = min; this.ComponentIDPOT = PamaterOperationType.Between; }
        private PamaterOperationType ComponentIDPOT;
        public void SetComponentID(int? info, PamaterOperationType pot) { this.ComponentID = info; this.ComponentIDPOT = pot; }
        private String getComponentIDSqlForSharp()
        {
            String sql = ""; switch (ComponentIDPOT)
            {
                case PamaterOperationType.Between: sql = "ComponentID between @ComponentIDMin to @ComponentIDMax"; break;
                case PamaterOperationType.StringContains: sql = "ComponentID like '%@ComponentID%'"; break;
                case PamaterOperationType.Equal: sql = "ComponentID=@ComponentID"; break;
                case PamaterOperationType.GreaterEqual: sql = "ComponentID>=@ComponentID"; break;
                case PamaterOperationType.GreaterThan: sql = "ComponentID>@ComponentID"; break;
                case PamaterOperationType.LessEqual: sql = "ComponentID<=@ComponentID"; break;
                case PamaterOperationType.LessThan: sql = "ComponentID<=@ComponentID"; break;
                case PamaterOperationType.In: sql = "ComponentID in(" + String.Join(",", this.ComponentIDList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "ComponentID in('" + String.Join("','", this.ComponentIDList) + "')"; break;
            }
            return sql;
        }
        public String Name { set; get; }
        public List<String> NameList { set; get; }
        private PamaterOperationType NamePOT;
        public void SetName(String info, PamaterOperationType pot) { this.Name = info; this.NamePOT = pot; }
        private String getNameSqlForSharp()
        {
            String sql = ""; switch (NamePOT)
            {
                case PamaterOperationType.Between: sql = "Name between @NameMin to @NameMax"; break;
                case PamaterOperationType.StringContains: sql = "Name like '%@Name%'"; break;
                case PamaterOperationType.Equal: sql = "Name=@Name"; break;
                case PamaterOperationType.GreaterEqual: sql = "Name>=@Name"; break;
                case PamaterOperationType.GreaterThan: sql = "Name>@Name"; break;
                case PamaterOperationType.LessEqual: sql = "Name<=@Name"; break;
                case PamaterOperationType.LessThan: sql = "Name<=@Name"; break;
                case PamaterOperationType.In: sql = "Name in(" + String.Join(",", this.NameList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "Name in('" + String.Join("','", this.NameList) + "')"; break;
            }
            return sql;
        }
        public String Title { set; get; }
        public List<String> TitleList { set; get; }
        private PamaterOperationType TitlePOT;
        public void SetTitle(String info, PamaterOperationType pot) { this.Title = info; this.TitlePOT = pot; }
        private String getTitleSqlForSharp()
        {
            String sql = ""; switch (TitlePOT)
            {
                case PamaterOperationType.Between: sql = "Title between @TitleMin to @TitleMax"; break;
                case PamaterOperationType.StringContains: sql = "Title like '%@Title%'"; break;
                case PamaterOperationType.Equal: sql = "Title=@Title"; break;
                case PamaterOperationType.GreaterEqual: sql = "Title>=@Title"; break;
                case PamaterOperationType.GreaterThan: sql = "Title>@Title"; break;
                case PamaterOperationType.LessEqual: sql = "Title<=@Title"; break;
                case PamaterOperationType.LessThan: sql = "Title<=@Title"; break;
                case PamaterOperationType.In: sql = "Title in(" + String.Join(",", this.TitleList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "Title in('" + String.Join("','", this.TitleList) + "')"; break;
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
        private String getCreateTimeSqlForSharp()
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
        public DateTime? ModifyTime { set; get; }
        public List<DateTime?> ModifyTimeList { set; get; }
        public DateTime? ModifyTimeMax { set; get; }
        public DateTime? ModifyTimeMin { set; get; }
        public void SetModifyTime(DateTime? max, DateTime? min) { this.ModifyTimeMax = max; this.ModifyTimeMin = min; this.ModifyTimePOT = PamaterOperationType.Between; }
        private PamaterOperationType ModifyTimePOT;
        public void SetModifyTime(DateTime? info, PamaterOperationType pot) { this.ModifyTime = info; this.ModifyTimePOT = pot; }
        private String getModifyTimeSqlForSharp()
        {
            String sql = ""; switch (ModifyTimePOT)
            {
                case PamaterOperationType.Between: sql = "ModifyTime between @ModifyTimeMin to @ModifyTimeMax"; break;
                case PamaterOperationType.StringContains: sql = "ModifyTime like '%@ModifyTime%'"; break;
                case PamaterOperationType.Equal: sql = "ModifyTime=@ModifyTime"; break;
                case PamaterOperationType.GreaterEqual: sql = "ModifyTime>=@ModifyTime"; break;
                case PamaterOperationType.GreaterThan: sql = "ModifyTime>@ModifyTime"; break;
                case PamaterOperationType.LessEqual: sql = "ModifyTime<=@ModifyTime"; break;
                case PamaterOperationType.LessThan: sql = "ModifyTime<=@ModifyTime"; break;
                case PamaterOperationType.In: sql = "ModifyTime in(" + String.Join(",", this.ModifyTimeList) + ")"; break;
                case PamaterOperationType.StringIn: sql = "ModifyTime in('" + String.Join("','", this.ModifyTimeList) + "')"; break;
            }
            return sql;
        }
    }
}