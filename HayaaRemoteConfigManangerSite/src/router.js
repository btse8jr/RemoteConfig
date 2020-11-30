import VueRouter from 'vue-router'
import Login from './components/Login.vue'
import Main from './components/Main.vue'
import Index from './pages/Index.vue'
import Message from './pages/Message.vue'
import List from './pages/List.vue'
import Edit from './pages/Edit.vue'
import AppList from './pages/App/AppList.vue'
import AppEdit from './pages/App/AppEdit.vue'
import ComponentList from './pages/Component/ComponentList.vue'
import ComponentEdit from './pages/Component/ComponentEdit.vue'
import AppComponentList from './pages/AppComponent/AppComponentList.vue'
import AppComponentEdit from './pages/AppComponent/AppComponentEdit.vue'
import AppUserList from './pages/AppUser/AppUserList.vue'
import AppUserEdit from './pages/AppUser/AppUserEdit.vue'
import AppConfigEdit from './pages/AppConfig/AppConfigEdit.vue'
import AppConfigList from './pages/AppConfig/AppConfigList.vue'
import ComponentConfigList from './pages/ComponentConfig/ComponentConfigList.vue'
import ComponentConfigEdit from './pages/ComponentConfig/ComponentConfigEdit.vue'
import AppComponentConfigList from './pages/AppComponentConfig/AppComponentConfigList.vue'
import AppCmponentConfigSet from './pages/AppComponentConfig/AppCmponentConfigSet.vue'

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