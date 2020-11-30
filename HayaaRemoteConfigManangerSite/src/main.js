import Vue from 'vue'
import VueRouter from 'vue-router'
import ElementUI from 'element-ui'
import 'element-ui/lib/theme-chalk/index.css'
import AppFrame from './AppFrame.vue'
import router from './router'

Vue.use(VueRouter)
Vue.use(ElementUI)



new Vue({
    el: '#app',
    router,
    render: h => h(AppFrame)
})
