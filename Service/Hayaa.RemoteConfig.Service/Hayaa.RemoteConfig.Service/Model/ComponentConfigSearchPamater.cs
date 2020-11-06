using System;
using System.Collections.Generic;
using Hayaa.BaseModel;
/// <summary>
///代码效率工具生成，此文件不要修改
/// </summary>
namespace Hayaa.RemoteConfig.Service{public class ComponentConfigSearchPamater:SearchPamaterMariadbBase {public int? ComponentConfig{set;get;}
public List<int?> ComponentConfigList{set;get;}
public int? ComponentConfigMax{set;get;}
public int? ComponentConfigMin{set;get;}
public void SetComponentConfig(int? max,int? min){ this.ComponentConfigMax=max;this.ComponentConfigMin=min;this.ComponentConfigPOT=PamaterOperationType.Between;}
private PamaterOperationType ComponentConfigPOT;
public void SetComponentConfig(int? info,PamaterOperationType pot){ this.ComponentConfig=info;this.ComponentConfigPOT=pot;}
private String GetComponentConfigSqlForSharp(){String sql = "";switch (ComponentConfigPOT){
case PamaterOperationType.Between:sql = "ComponentConfig between @ComponentConfigMin to @ComponentConfigMax";break;
case PamaterOperationType.StringContains:sql = "ComponentConfig like '%@ComponentConfig%'";break;
case PamaterOperationType.Equal:sql = "ComponentConfig=@ComponentConfig";break;
case PamaterOperationType.GreaterEqual:sql = "ComponentConfig>=@ComponentConfig";break;
case PamaterOperationType.GreaterThan:sql = "ComponentConfig>@ComponentConfig";break;
case PamaterOperationType.LessEqual:sql = "ComponentConfig<=@ComponentConfig";break;
case PamaterOperationType.LessThan:sql = "ComponentConfig<=@ComponentConfig";break;
case PamaterOperationType.In:sql = "ComponentConfig in(" + String.Join(",", this.ComponentConfigList) + ")";break;
case PamaterOperationType.StringIn:sql = "ComponentConfig in('" + String.Join("','", this.ComponentConfigList)+"')";break;
}
return sql;}
public int? ComponentId{set;get;}
public List<int?> ComponentIdList{set;get;}
public int? ComponentIdMax{set;get;}
public int? ComponentIdMin{set;get;}
public void SetComponentId(int? max,int? min){ this.ComponentIdMax=max;this.ComponentIdMin=min;this.ComponentIdPOT=PamaterOperationType.Between;}
private PamaterOperationType ComponentIdPOT;
public void SetComponentId(int? info,PamaterOperationType pot){ this.ComponentId=info;this.ComponentIdPOT=pot;}
private String GetComponentIdSqlForSharp(){String sql = "";switch (ComponentIdPOT){
case PamaterOperationType.Between:sql = "ComponentId between @ComponentIdMin to @ComponentIdMax";break;
case PamaterOperationType.StringContains:sql = "ComponentId like '%@ComponentId%'";break;
case PamaterOperationType.Equal:sql = "ComponentId=@ComponentId";break;
case PamaterOperationType.GreaterEqual:sql = "ComponentId>=@ComponentId";break;
case PamaterOperationType.GreaterThan:sql = "ComponentId>@ComponentId";break;
case PamaterOperationType.LessEqual:sql = "ComponentId<=@ComponentId";break;
case PamaterOperationType.LessThan:sql = "ComponentId<=@ComponentId";break;
case PamaterOperationType.In:sql = "ComponentId in(" + String.Join(",", this.ComponentIdList) + ")";break;
case PamaterOperationType.StringIn:sql = "ComponentId in('" + String.Join("','", this.ComponentIdList)+"')";break;
}
return sql;}
public String Content{set;get;}
public List<String> ContentList{set;get;}
private PamaterOperationType ContentPOT;
public void SetContent(String info,PamaterOperationType pot){ this.Content=info;this.ContentPOT=pot;}
private String GetContentSqlForSharp(){String sql = "";switch (ContentPOT){
case PamaterOperationType.Between:sql = "Content between @ContentMin to @ContentMax";break;
case PamaterOperationType.StringContains:sql = "Content like '%@Content%'";break;
case PamaterOperationType.Equal:sql = "Content=@Content";break;
case PamaterOperationType.GreaterEqual:sql = "Content>=@Content";break;
case PamaterOperationType.GreaterThan:sql = "Content>@Content";break;
case PamaterOperationType.LessEqual:sql = "Content<=@Content";break;
case PamaterOperationType.LessThan:sql = "Content<=@Content";break;
case PamaterOperationType.In:sql = "Content in(" + String.Join(",", this.ContentList) + ")";break;
case PamaterOperationType.StringIn:sql = "Content in('" + String.Join("','", this.ContentList)+"')";break;
}
return sql;}
public int? Version{set;get;}
public List<int?> VersionList{set;get;}
public int? VersionMax{set;get;}
public int? VersionMin{set;get;}
public void SetVersion(int? max,int? min){ this.VersionMax=max;this.VersionMin=min;this.VersionPOT=PamaterOperationType.Between;}
private PamaterOperationType VersionPOT;
public void SetVersion(int? info,PamaterOperationType pot){ this.Version=info;this.VersionPOT=pot;}
private String GetVersionSqlForSharp(){String sql = "";switch (VersionPOT){
case PamaterOperationType.Between:sql = "Version between @VersionMin to @VersionMax";break;
case PamaterOperationType.StringContains:sql = "Version like '%@Version%'";break;
case PamaterOperationType.Equal:sql = "Version=@Version";break;
case PamaterOperationType.GreaterEqual:sql = "Version>=@Version";break;
case PamaterOperationType.GreaterThan:sql = "Version>@Version";break;
case PamaterOperationType.LessEqual:sql = "Version<=@Version";break;
case PamaterOperationType.LessThan:sql = "Version<=@Version";break;
case PamaterOperationType.In:sql = "Version in(" + String.Join(",", this.VersionList) + ")";break;
case PamaterOperationType.StringIn:sql = "Version in('" + String.Join("','", this.VersionList)+"')";break;
}
return sql;}
public String ComponentConfigTitle{set;get;}
public List<String> ComponentConfigTitleList{set;get;}
private PamaterOperationType ComponentConfigTitlePOT;
public void SetComponentConfigTitle(String info,PamaterOperationType pot){ this.ComponentConfigTitle=info;this.ComponentConfigTitlePOT=pot;}
private String GetComponentConfigTitleSqlForSharp(){String sql = "";switch (ComponentConfigTitlePOT){
case PamaterOperationType.Between:sql = "ComponentConfigTitle between @ComponentConfigTitleMin to @ComponentConfigTitleMax";break;
case PamaterOperationType.StringContains:sql = "ComponentConfigTitle like '%@ComponentConfigTitle%'";break;
case PamaterOperationType.Equal:sql = "ComponentConfigTitle=@ComponentConfigTitle";break;
case PamaterOperationType.GreaterEqual:sql = "ComponentConfigTitle>=@ComponentConfigTitle";break;
case PamaterOperationType.GreaterThan:sql = "ComponentConfigTitle>@ComponentConfigTitle";break;
case PamaterOperationType.LessEqual:sql = "ComponentConfigTitle<=@ComponentConfigTitle";break;
case PamaterOperationType.LessThan:sql = "ComponentConfigTitle<=@ComponentConfigTitle";break;
case PamaterOperationType.In:sql = "ComponentConfigTitle in(" + String.Join(",", this.ComponentConfigTitleList) + ")";break;
case PamaterOperationType.StringIn:sql = "ComponentConfigTitle in('" + String.Join("','", this.ComponentConfigTitleList)+"')";break;
}
return sql;}
public bool? IsDefault{set;get;}
public List<bool?> IsDefaultList{set;get;}
public bool? IsDefaultMax{set;get;}
public bool? IsDefaultMin{set;get;}
public void SetIsDefault(bool? max,bool? min){ this.IsDefaultMax=max;this.IsDefaultMin=min;this.IsDefaultPOT=PamaterOperationType.Between;}
private PamaterOperationType IsDefaultPOT;
public void SetIsDefault(bool? info,PamaterOperationType pot){ this.IsDefault=info;this.IsDefaultPOT=pot;}
private String GetIsDefaultSqlForSharp(){String sql = "";switch (IsDefaultPOT){
case PamaterOperationType.Between:sql = "IsDefault between @IsDefaultMin to @IsDefaultMax";break;
case PamaterOperationType.StringContains:sql = "IsDefault like '%@IsDefault%'";break;
case PamaterOperationType.Equal:sql = "IsDefault=@IsDefault";break;
case PamaterOperationType.GreaterEqual:sql = "IsDefault>=@IsDefault";break;
case PamaterOperationType.GreaterThan:sql = "IsDefault>@IsDefault";break;
case PamaterOperationType.LessEqual:sql = "IsDefault<=@IsDefault";break;
case PamaterOperationType.LessThan:sql = "IsDefault<=@IsDefault";break;
case PamaterOperationType.In:sql = "IsDefault in(" + String.Join(",", this.IsDefaultList) + ")";break;
case PamaterOperationType.StringIn:sql = "IsDefault in('" + String.Join("','", this.IsDefaultList)+"')";break;
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