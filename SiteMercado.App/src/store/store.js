import Vue from 'vue'
import Vuex from 'vuex'
import createPersistedState from 'vuex-persistedstate'
Vue.use(Vuex)

const state = {
  user: {},
  token: null
}

const mutations = {
   STORE_USER_TOKEN (state, {token, user}) {
     state.token = token;
     state.user = user
   },

   LOGOUT_USER (state){
     state.token = null,
     state.user = {}
   }
}

export default new Vuex.Store({
  state,
  mutations,
  plugins: [createPersistedState()],
})
