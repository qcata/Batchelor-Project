import Vue from 'vue'
import './plugins/vuetify'
import App from './App.vue'
import VueAxios from 'vue-axios'
import axios from 'axios'
import router from './utils/router'


Vue.config.productionTip = false
Vue.use(VueAxios,axios);

new Vue({
  router,
  render: h => h(App),
}).$mount('#app')
