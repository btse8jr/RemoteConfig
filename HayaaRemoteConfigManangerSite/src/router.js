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
                {path: "componentlist", component: ComponentList},
                {path: "componentedit/:id?", component: ComponentEdit},
                {path: "appcomponentlist", component: AppComponentList},
                {path: "appcomponentedit/:id?", component: AppComponentEdit}
            ]
        }
    ]
})
export default router