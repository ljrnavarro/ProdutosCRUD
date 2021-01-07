<template>
  <v-app id="inspire">
    <NavigationDrawer
      ref="NavigationDrawer"
      v-bind:drawer="drawer"
    ></NavigationDrawer>

    <AppBar ref="AppBar" v-on:changeDrawer="changeDrawer" v-on:sair="sair">
    </AppBar>

    <RouterViews></RouterViews>

    <v-footer color="indigo" app>
      <span class="white--text">&copy; 2019</span>
    </v-footer>
  </v-app>
</template>

<script>
import NavigationDrawer from "../components/BasePage/NavigationDrawer";
import RouterViews from "../components/BasePage/RouterViews";
import AppBar from "../components/BasePage/AppBar";

export default {
  name: "app",
  components: {
    NavigationDrawer,
    RouterViews,
    AppBar,
  },
  props: {
    source: String,
  },
  data: () => ({
    drawer: true,
  }),
  methods: {
    changeDrawer() {
      this.drawer = !this.drawer;
    },
    sair() {
      this.$refs.NavigationDrawer.confirmActionSair();
    },
  },
  mounted() {
    this.$router.push("/Produtos",() => {});
    //this.appBarClickEvent();
  },
  beforeCreate() {},
};
</script>
<style scoped>
.wadjust {
  padding: 0px 0px 36px 300px !important;
}
</style>
