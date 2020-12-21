import VueRouter from 'vue-router'
import Login from './components/Login.vue'
import Main from './components/Main.vue'
import Index from './pages/Index.vue'
import Message from './pages/Message.vue'
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
import AppComponentConfigSet from './pages/AppComponentConfig/AppComponentConfigSet.vue'
import CodeSolutionList from './pages/CodeSolution/CodeSolutionList.vue'
import CodeSolutionEdit from './pages/CodeSolution/CodeSolutionEdit.vue'
import CodeTemplateList from './pages/CodeTemplate/CodeTemplateList.vue'
import CodeTemplateEdit from './pages/CodeTemplate/CodeTemplateEdit.vue'

const router = new VueRouter({
    mode: 'history',
    routes: [{path: '/login', component: Login},
        {
            path: '/home',
            component: Main,
            children: [
                {path: "index", component: Index},
                {path: "message", component: Message},
                {path: "applist", component: AppList},
                {path: "appedit/:id?", component: AppEdit},
                {path: "componentlist", component: ComponentList},
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
                {path: "appcomponentconfigset/:aid/:cid/:afid", component: AppComponentConfigSet},
                {path: "codesolutionlist", component: CodeSolutionList},
                {path: "codesolutionedit/:id", component: CodeSolutionEdit},
                {path: "codetemplatelist/:id", component: CodeTemplateList},
                {path: "codetemplateedit/:sid/:id", component: CodeTemplateEdit}
            ]
        }
    ]
})
export default router