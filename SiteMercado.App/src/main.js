import Vue from 'vue'
import App from './App.vue'
import router from './router'
import VueResource from 'vue-resource'
import vuetify from "./plugins/vuetify"
import Vuetify from 'vuetify'
import VueSweetalert2 from 'vue-sweetalert2';
import 'sweetalert2/dist/sweetalert2.min.css';
import "vue2-animate/dist/vue2-animate.min.css";
import Vuex from 'vuex';
import store  from "./store/store"
import 'vuetify/dist/vuetify.css';
import '@fortawesome/fontawesome-free/css/all.css'
import MessageBoxMixins from './../src/mixins/MessageBoxMixins.js'
import VueTheMask from 'vue-the-mask'
import VueCurrencyInput from 'vue-currency-input'

Vue.use(Vuex);
Vue.use(VueResource);
Vue.use(VueSweetalert2);
Vue.use(Vuetify)
Vue.mixin(MessageBoxMixins);
Vue.use(VueTheMask);
Vue.use(VueCurrencyInput)


new Vue({
      icons: {
        iconfont: 'fa',
      },
      store,
      router,
      vuetify,
      //types,
      template: '<App/>',
      render: h => h(App),
    }).$mount('#app');
