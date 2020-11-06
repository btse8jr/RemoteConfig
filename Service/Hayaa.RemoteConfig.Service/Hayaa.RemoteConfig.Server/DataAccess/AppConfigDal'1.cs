using Hayaa.RemoteService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.RemoteConfig.Service.Dao
{
    internal partial  class AppConfigDal
    {
        
        internal static AppConfig Get(Guid solutionID, int version)
        {
            String sql = "select * from AppConfig where SolutionID=@SolutionID and Version=@Version";
           
            return Get<AppConfig>(con, sql, new { SolutionID = solutionID, Version = version });
        }
    }
}
