import VueRouter from 'vue-router'
import Login from './components/Login'
import Main from './components/Main'
import Index from './pages/Index'
import Message from './pages/Message'
import List from './pages/List'
import Edit from './pages/Edit'
import AppList from './pages/App/AppList'
import AppEdit from './pages/App/AppEdit'
import ComponentList from './pages/Component/ComponentList'
import ComponentEdit from './pages/Component/ComponentEdit'
import AppComponentList from './pages/AppComponent/AppComponentList'
import AppComponentEdit from './pages/AppComponent/AppComponentEdit'
import AppUserList from './pages/AppUser/AppUserList'
import AppUserEdit from './pages/AppUser/AppUserEdit'
import AppConfigEdit from './pages/AppConfig/AppConfigEdit'
import AppConfigList from './pages/AppConfig/AppConfigList'
import ComponentConfigList from './pages/ComponentConfig/ComponentConfigList'
import ComponentConfigEdit from './pages/ComponentConfig/ComponentConfigEdit'
import AppComponentConfigList from './pages/AppComponentConfig/AppComponentConfigList'
import AppCmponentConfigSet from './pages/AppComponentConfig/AppCmponentConfigSet'

const router = new VueRouter({
    mode: 'history',
    routes: [{path: '/login', component: Login},
        {
            path: '/home',
            component: Main,
            children: [
                {path: "index", component: Index},
                {path: "message", component: Message},
                {path: "edit", component: Edit},
                {path: "list", component: List},
                {path: "applist", component: AppList},
                {path: "appedit/:id?", component: AppEdit},
                {path: "componentlist", component: ComponentList,children:[]},
                {path: "componentedit/:id?", component: ComponentEdit},
                {path: "appcomponentlist/:id", component: AppComponentList},
                {path: "appcomponentedit/:cid/:id?", component: AppComponentEdit},
                {path: "appuserlist", component: AppUserList},
                {path: "appuseredit/:id?", component: AppUserEdit},
                {path: "componentconfiglist/:id", component: ComponentConfigList},
                {path: "componentconfigedit/:cid/:id?", component: ComponentConfigEdit},
                {path: "appconfiglist/:id", component: AppConfigList},
                {path: "appconfigedit/:aid/:id?", component: AppConfigEdit},
                {path: "appcomponentconfiglist/:aid/:id", component: AppComponentConfigList},
                {path: "appcomponentconfigset/:aid/:cid/:afid", component: AppCmponentConfigSet},
            ]
        }
    ]
})
export default router