import Vue from "vue";
import Router from "vue-router";
import Login from "./views/Login";
import AppLayout from "./Layouts/AppLayout";
import Produtos from "./views/Produtos";
import store from "./store/store";

Vue.use(Router);

const router = new Router({
  duplicateNavigationPolicy: 'ignore',
  mode: 'history',
  routes: [
    {
      path: "*",
      redirect: "/Login",
      meta: {
        baseLayout: true,
      },
    },
    {
      path: "/",
      redirect: "/Login",
      meta: {
        baseLayout: true,
      },
    },
    {
      path: "/Login",
      name: "Login",
      component: Login,
      meta: {
        baseLayout: true,
      },
    },
    {
      path: "/Produtos",
      name: "Produtos",
      component: Produtos,
      meta: {
        requiresAuth: true,
        baseLayout: false,
      },
    },
    {
      path: "/AppLayout",
      name: "AppLayout",
      component: AppLayout,
      meta: {
        requiresAuth: true,
        baseLayout: false,
      },
    },
   ],
});

router.beforeEach((to, from, next) => {
  const currentUser = (store.state != undefined && store.state.token != null);
  const requiresAuth = to.matched.some((record) => record.meta.requiresAuth);
  if (requiresAuth && !currentUser) next("Login");
  else next();
});


export default router;
