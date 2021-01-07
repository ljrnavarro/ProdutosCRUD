<template>
  <v-app>
    <component v-bind:is="this.$route.meta.baseLayout ? 'simple-layout' : 'app-layout'"></component>
  </v-app>
</template>

<script>
import AppLayout from "./Layouts/AppLayout";
import SimpleLayout from "./Layouts/BaseLayout";

export default {
  name: "App",
  components: {
    "app-layout": AppLayout,
    "simple-layout": SimpleLayout,
  },
  data: () => ({
    
  }),
  methods: {
  },
 };
</script>
