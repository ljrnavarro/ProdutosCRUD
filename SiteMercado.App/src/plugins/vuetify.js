import 'material-design-icons-iconfont/dist/material-design-icons.css'; // Ensure you are using css-loader
import Vue from 'vue';
import Vuetify from 'vuetify/lib';
import '@mdi/font/css/materialdesignicons.css'

Vue.use(Vuetify)

export default new Vuetify({
  icons: {
    iconfont: 'md',
  },
  Data: () => ({
    drawer: null
  })
})

