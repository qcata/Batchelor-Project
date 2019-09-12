import Vue from 'vue'
import './plugins/vuetify'
import App from './App.vue'
import VueAxios from 'vue-axios'
import axios from 'axios'
import router from './utils/router'
import VueScheduler from 'v-calendar-scheduler'
import 'v-calendar-scheduler/lib/main.css'
import 'fullpage.js/vendors/scrolloverflow'
import VueFullPage from 'vue-fullpage.js'
import VueCardPayment from 'vue-card-payment'
import 'vue-card-payment/dist/vue-card-payment.css'
import VueCardFormat from 'vue-credit-card-validation';
import VueSession from 'vue-session'

 




Vue.config.productionTip = false
Vue.use(VueAxios,axios);
Vue.use(VueScheduler, { availableViews:[],
                        initialView: 'week',
                        showTodayButton: false,
                        timeRange: [10,22]
                      });
Vue.use(VueFullPage);
Vue.use(VueCardPayment);
Vue.use(VueCardFormat);
Vue.use(VueSession)

new Vue({
  router,
  render: h => h(App),
}).$mount('#app')
