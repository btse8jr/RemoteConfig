using System;
using System.Collections.Generic;
using Hayaa.BaseModel;
/// <summary>
///代码效率工具生成，此文件不要修改
/// </summary>
namespace Hayaa.RemoteConfig.Service{public class ComponentSearchPamater:SearchPamaterMariadbBase {public int? ComponentID{set;get;}
public List<int?> ComponentIDList{set;get;}
public int? ComponentIDMax{set;get;}
public int? ComponentIDMin{set;get;}
public void SetComponentID(int? max,int? min){ this.ComponentIDMax=max;this.ComponentIDMin=min;this.ComponentIDPOT=PamaterOperationType.Between;}
private PamaterOperationType ComponentIDPOT;
public void SetComponentID(int? info,PamaterOperationType pot){ this.ComponentID=info;this.ComponentIDPOT=pot;}
private String GetComponentIDSqlForSharp(){String sql = "";switch (ComponentIDPOT){
case PamaterOperationType.Between:sql = "ComponentID between @ComponentIDMin to @ComponentIDMax";break;
case PamaterOperationType.StringContains:sql = "ComponentID like '%@ComponentID%'";break;
case PamaterOperationType.Equal:sql = "ComponentID=@ComponentID";break;
case PamaterOperationType.GreaterEqual:sql = "ComponentID>=@ComponentID";break;
case PamaterOperationType.GreaterThan:sql = "ComponentID>@ComponentID";break;
case PamaterOperationType.LessEqual:sql = "ComponentID<=@ComponentID";break;
case PamaterOperationType.LessThan:sql = "ComponentID<=@ComponentID";break;
case PamaterOperationType.In:sql = "ComponentID in(" + String.Join(",", this.ComponentIDList) + ")";break;
case PamaterOperationType.StringIn:sql = "ComponentID in('" + String.Join("','", this.ComponentIDList)+"')";break;
}
return sql;}
public String Name{set;get;}
public List<String> NameList{set;get;}
private PamaterOperationType NamePOT;
public void SetName(String info,PamaterOperationType pot){ this.Name=info;this.NamePOT=pot;}
private String GetNameSqlForSharp(){String sql = "";switch (NamePOT){
case PamaterOperationType.Between:sql = "Name between @NameMin to @NameMax";break;
case PamaterOperationType.StringContains:sql = "Name like '%@Name%'";break;
case PamaterOperationType.Equal:sql = "Name=@Name";break;
case PamaterOperationType.GreaterEqual:sql = "Name>=@Name";break;
case PamaterOperationType.GreaterThan:sql = "Name>@Name";break;
case PamaterOperationType.LessEqual:sql = "Name<=@Name";break;
case PamaterOperationType.LessThan:sql = "Name<=@Name";break;
case PamaterOperationType.In:sql = "Name in(" + String.Join(",", this.NameList) + ")";break;
case PamaterOperationType.StringIn:sql = "Name in('" + String.Join("','", this.NameList)+"')";break;
}
return sql;}
public String Title{set;get;}
public List<String> TitleList{set;get;}
private PamaterOperationType TitlePOT;
public void SetTitle(String info,PamaterOperationType pot){ this.Title=info;this.TitlePOT=pot;}
private String GetTitleSqlForSharp(){String sql = "";switch (TitlePOT){
case PamaterOperationType.Between:sql = "Title between @TitleMin to @TitleMax";break;
case PamaterOperationType.StringContains:sql = "Title like '%@Title%'";break;
case PamaterOperationType.Equal:sql = "Title=@Title";break;
case PamaterOperationType.GreaterEqual:sql = "Title>=@Title";break;
case PamaterOperationType.GreaterThan:sql = "Title>@Title";break;
case PamaterOperationType.LessEqual:sql = "Title<=@Title";break;
case PamaterOperationType.LessThan:sql = "Title<=@Title";break;
case PamaterOperationType.In:sql = "Title in(" + String.Join(",", this.TitleList) + ")";break;
case PamaterOperationType.StringIn:sql = "Title in('" + String.Join("','", this.TitleList)+"')";break;
}
return sql;}
public DateTime? CreateTime{set;get;}
public List<DateTime?> CreateTimeList{set;get;}
public DateTime? CreateTimeMax{set;get;}
public DateTime? CreateTimeMin{set;get;}
public void SetCreateTime(DateTime? max,DateTime? min){ this.CreateTimeMax=max;this.CreateTimeMin=min;this.CreateTimePOT=PamaterOperationType.Between;}
private PamaterOperationType CreateTimePOT;
public void SetCreateTime(DateTime? info,PamaterOperationType pot){ this.CreateTime=info;this.CreateTimePOT=pot;}
private String GetCreateTimeSqlForSharp(){String sql = "";switch (CreateTimePOT){
case PamaterOperationType.Between:sql = "CreateTime between @CreateTimeMin to @CreateTimeMax";break;
case PamaterOperationType.StringContains:sql = "CreateTime like '%@CreateTime%'";break;
case PamaterOperationType.Equal:sql = "CreateTime=@CreateTime";break;
case PamaterOperationType.GreaterEqual:sql = "CreateTime>=@CreateTime";break;
case PamaterOperationType.GreaterThan:sql = "CreateTime>@CreateTime";break;
case PamaterOperationType.LessEqual:sql = "CreateTime<=@CreateTime";break;
case PamaterOperationType.LessThan:sql = "CreateTime<=@CreateTime";break;
case PamaterOperationType.In:sql = "CreateTime in(" + String.Join(",", this.CreateTimeList) + ")";break;
case PamaterOperationType.StringIn:sql = "CreateTime in('" + String.Join("','", this.CreateTimeList)+"')";break;
}
return sql;}
public DateTime? UpdateTime{set;get;}
public List<DateTime?> UpdateTimeList{set;get;}
public DateTime? UpdateTimeMax{set;get;}
public DateTime? UpdateTimeMin{set;get;}
public void SetUpdateTime(DateTime? max,DateTime? min){ this.UpdateTimeMax=max;this.UpdateTimeMin=min;this.UpdateTimePOT=PamaterOperationType.Between;}
private PamaterOperationType UpdateTimePOT;
public void SetUpdateTime(DateTime? info,PamaterOperationType pot){ this.UpdateTime=info;this.UpdateTimePOT=pot;}
private String GetUpdateTimeSqlForSharp(){String sql = "";switch (UpdateTimePOT){
case PamaterOperationType.Between:sql = "UpdateTime between @UpdateTimeMin to @UpdateTimeMax";break;
case PamaterOperationType.StringContains:sql = "UpdateTime like '%@UpdateTime%'";break;
case PamaterOperationType.Equal:sql = "UpdateTime=@UpdateTime";break;
case PamaterOperationType.GreaterEqual:sql = "UpdateTime>=@UpdateTime";break;
case PamaterOperationType.GreaterThan:sql = "UpdateTime>@UpdateTime";break;
case PamaterOperationType.LessEqual:sql = "UpdateTime<=@UpdateTime";break;
case PamaterOperationType.LessThan:sql = "UpdateTime<=@UpdateTime";break;
case PamaterOperationType.In:sql = "UpdateTime in(" + String.Join(",", this.UpdateTimeList) + ")";break;
case PamaterOperationType.StringIn:sql = "UpdateTime in('" + String.Join("','", this.UpdateTimeList)+"')";break;
}
return sql;}
}}