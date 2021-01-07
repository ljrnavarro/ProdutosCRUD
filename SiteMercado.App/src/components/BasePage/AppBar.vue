<template>
 <v-layout class="www">
       <v-app-bar class="ssssssssssss"
      color="blue darken-3"
      dark
      id="app-bar"
      :clipped-left="$vuetify.breakpoint.lgAndUp"
      app
    >
      <v-app-bar-nav-icon
        ref="myAppBar"
        @click.stop="changeDrawer()"
      ></v-app-bar-nav-icon>
      <div class="d-flex align-center">
        <v-img
          alt="Logo"
          class="shrink mr-2"
          contain
          src="../../images/sitemercado2.png"
          transition="scale-transition"
          width="200"
        />
      </div>
      <v-toolbar-title style="width: 300px" class="ml-0 pl-4">
       
      </v-toolbar-title>
      <v-spacer></v-spacer>
      <v-tooltip bottom>
        <template v-slot:activator="{ on }">
          <v-btn icon large v-on="on" @click="sair()">
            <v-icon>lock_open</v-icon>
          </v-btn>
        </template>
        <span>Descontectar...</span>
      </v-tooltip>
    </v-app-bar>
 </v-layout>
</template>

<script>

export default {
    props: {
    source: String,
  },
  data: () => ({ }),
  methods: {
    changeDrawer() {
        this.$emit('changeDrawer');
    },
    sair() {
      this.$emit('sair');
    },
  },
}
</script>
<style scoped>
.wadjust {
  padding: 0px 0px 36px 300px !important;
}
.layout {
    display: -webkit-box;
    display: -ms-flexbox;
    display: flex;
    -webkit-box-flex: 1;
    -ms-flex: 1 1 auto;
    flex: 0 0 auto !important;
    -ms-flex-wrap: nowrap;
    flex-wrap: nowrap;
    min-width: 0;
}
</style>