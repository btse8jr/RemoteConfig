import Vue from 'vue'
import Router from 'vue-router'
import Login from '@/components/Login.vue'
import Main from '@/components/Main.vue'
import Index from '@/pages/Index.vue'
import Message from '@/pages/Message.vue'

import AppConfigEdit from '@/pages/AppConfig/AppConfigEdit.vue'
import AppConfigList from '@/pages/AppConfig/AppConfigList.vue'
import ComponentConfigList from '@/pages/ComponentConfig/ComponentConfigList.vue'
import ComponentConfigEdit from '@/pages/ComponentConfig/ComponentConfigEdit.vue'
import AppComponentConfigList from '@/pages/AppComponentConfig/AppComponentConfigList.vue'
import AppComponentConfigSet from '@/pages/AppComponentConfig/AppComponentConfigSet.vue'

Vue.use(Router)

export default new Router({
  mode: 'history',
  routes: [
    {path: '/login', component: Login},
    {
      path: '/home',
      component: Main,
      children: [
        {path: "index", component: Index},
        {path: "message", component: Message},
        {path: "appconfiglist/:id", component: AppConfigList},
        {path: "appconfigedit/:aid/:id?", component: AppConfigEdit},
        {path: "componentconfiglist/:id", component: ComponentConfigList},
        {path: "componentconfigedit/:cid/:id?", component: ComponentConfigEdit},
        {path: "appcomponentconfiglist/:aid/:id", component: AppComponentConfigList},
        {path: "appcomponentconfigset/:aid/:cid/:afid", component: AppComponentConfigSet}
      ]
    }
  ]
})
