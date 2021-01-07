<template>
  <v-card>
    <v-img
      height="180"
      width="100%"
      v-bind:src="'data:image/jpeg;base64,' + image"
    ></v-img>
    <v-card-title class="subheading font-weight-bold">
      {{ name }}
    </v-card-title>
    <v-divider></v-divider>
    <v-list dense>
      <v-list-item>
        <v-list-item-content style="flex:auto!important" :class="{ 'blue--text': sortBy === name }">
         <span> Valor: <b>R$ {{ value.toFixed(2) }}</b> </span>
        </v-list-item-content>
        <v-list-item-content
          class="align-end"
          :class="{ 'blue--text': sortBy === name }"
        >
        </v-list-item-content>
      </v-list-item>
    </v-list>
    <v-card-actions style="justify-content: flex-end!important">
              <v-btn icon
               outlined
              @click="$emit('confirmActionUpdate', getProductObject())"
               color="indigo">
                <v-icon>mdi-pencil</v-icon>
              </v-btn>
              <v-btn icon color="error"
               @click="$emit('confirmActionDelete', id)"
               outlined>
                <v-icon>mdi-delete</v-icon>
              </v-btn>
            </v-card-actions>
  </v-card>
</template>
<script>
export default {
  name: "ProdutoDetalhe",
  data() {
    return {};
  },
  props: ["id","name", "value", "image", "sortBy", "search"],
  created() {},
  methods: {
    getProductObject(){
      return {
        "Id" : this.id,
        "Name" : this.name,
        "Image" : this.image,
        "Value" : this.value
      }
    }
  },
};
</script>
<style>
</style>

