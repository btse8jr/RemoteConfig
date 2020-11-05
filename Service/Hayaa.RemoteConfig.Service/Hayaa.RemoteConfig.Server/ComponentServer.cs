﻿using System;
using System.Collections.Generic;
using System.Text;
using Hayaa.BaseModel;
using Hayaa.RemoteService.DataAccess;

namespace Hayaa.RemoteService.Core
{
    public class ComponentServer : ComponentService
    {
        public FunctionResult<Component> Create(Component info)
        {
            var r = new FunctionResult<Component>();
            int id = ComponentDal.Add(info);
            if (id > 0)
            {
                r.Data = info;               
            }
            return r;
        }
        public FunctionOpenResult<bool> UpdateByID(Component info)
        {
            var r = new FunctionOpenResult<bool>();
            r.Data = ComponentDal.Update(info) > 0;
            return r;
        }
        public FunctionOpenResult<bool> DeleteByID(List<int> idList)
        {
            var r = new FunctionOpenResult<bool>();
            r.Data = ComponentDal.Delete(idList);
            return r;
        }

        public GridPager<Component> GetPager(GridPagerPamater<ComponentSearchPamater> searchParam)
        {
            var r = ComponentDal.GetGridPager(searchParam);
            return r;
        }
    }
}
