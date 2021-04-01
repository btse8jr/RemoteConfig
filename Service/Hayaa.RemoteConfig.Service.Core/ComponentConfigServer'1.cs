using Hayaa.BaseModel;
using Hayaa.RemoteConfig.Service.Dao;


namespace Hayaa.RemoteConfig.Service
{
    public partial class ComponentConfigServer
    {
           
        public FunctionListResult<ComponentConfig> GetComponentConfigList(int appConfigId, int version)
        {
            var r = new FunctionListResult<ComponentConfig>();
            r.Data = ComponentConfigDal.GetList(appConfigId, version);
            return r; 
        }
    }
}