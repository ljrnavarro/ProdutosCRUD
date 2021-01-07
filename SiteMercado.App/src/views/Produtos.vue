<template>
  <v-container fluid>
    <v-overlay :value="overlay">
      <v-progress-circular indeterminate size="64"></v-progress-circular>
    </v-overlay>

    <v-data-iterator
      :items="computedItens"
      :items-per-page.sync="itemsPerPage"
      :page="page"
      :search="search"
      :sort-by="sortBy.toLowerCase()"
      :sort-desc="sortDesc"
      hide-default-footer
    >
      <template v-slot:header>
        <v-toolbar dark color="primary" class="mb-1">
          <v-btn
            large
            depressed
            color="blue"
            :value="true"
            @click="openDialogCreate"
          >
            <v-icon>mdi-plus</v-icon>Adicionar
          </v-btn>

          <v-spacer></v-spacer>

          <v-text-field
            v-model="search"
            clearable
            flat
            solo-inverted
            hide-details
            prepend-inner-icon="mdi-magnify"
            label="Search"
          ></v-text-field>
          <template v-if="$vuetify.breakpoint.mdAndUp">
            <v-spacer></v-spacer>
            <v-select
              v-model="sortBy"
              flat
              solo-inverted
              hide-details
              :items="keysSortBy"
              prepend-inner-icon="mdi-magnify"
              label="Sort by"
            ></v-select>

            <v-spacer></v-spacer>
            <v-btn-toggle v-model="sortDesc" mandatory>
              <v-btn large depressed color="blue" :value="false">
                <v-icon>mdi-arrow-up</v-icon>
              </v-btn>
              <v-btn large depressed color="blue" :value="true">
                <v-icon>mdi-arrow-down</v-icon>
              </v-btn>
            </v-btn-toggle>
          </template>
        </v-toolbar>
      </template>

      <template v-slot:default="props">
        <v-row>
          <v-col
            v-for="item in props.items"
            :key="item.name"
            cols="12"
            sm="6"
            md="4"
            lg="3"
          >
            <ProdutoCard
              v-if="!overlay"
              :name="item.name"
              :value="item.value"
              :image="item.image"
              :id="item.id"
              :sortBy="sortBy"
              :search="search"
              @confirmActionDelete="confirmActionDelete"
              @openDialogCreate="openDialogCreate"
              @confirmActionUpdate="confirmActionUpdate"
            />
          </v-col>
        </v-row>
      </template>

      <template v-slot:footer>
        <v-row class="mt-2" align="center" justify="center">
          <span class="grey--text">Items por página</span>
          <v-menu offset-y>
            <template v-slot:activator="{ on, attrs }">
              <v-btn
                dark
                text
                color="primary"
                class="ml-2"
                v-bind="attrs"
                v-on="on"
              >
                {{ itemsPerPage }}
                <v-icon>mdi-chevron-down</v-icon>
              </v-btn>
            </template>
            <v-list>
              <v-list-item
                v-for="(number, index) in itemsPerPageArray"
                :key="index"
                @click="updateItemsPerPage(number)"
              >
                <v-list-item-title>{{ number }}</v-list-item-title>
              </v-list-item>
            </v-list>
          </v-menu>

          <v-spacer></v-spacer>

          <span
            class="mr-4
            grey--text"
          >
            Page {{ page }} of {{ numberOfPages }}
          </span>
          <v-btn
            fab
            dark
            color="blue darken-3"
            class="mr-1"
            @click="formerPage"
          >
            <v-icon>mdi-chevron-left</v-icon>
          </v-btn>
          <v-btn fab dark color="blue darken-3" class="ml-1" @click="nextPage">
            <v-icon>mdi-chevron-right</v-icon>
          </v-btn>
        </v-row>
      </template>
    </v-data-iterator>
    <ProdutoCreateUpdate
      ref="produtoCreateUpdate"
      @submitCreate="submitCreate"
      @submitUpdate="submitUpdate"
    />
  </v-container>
</template>
<script>
import { RepositoryFactory } from "./../Repositories/RepositoryFactory";
import ProdutoCard from "./../components/Produto/ProdutoCard";
import ProdutoCreateUpdate from "./../components/Produto/ProdutoCreateUpdate";
const ProdutoRepository = RepositoryFactory.get("produto");
import axios from "axios";
import store from "../store/store";

export default {
  name: "Produtos",
  components: {
    ProdutoCard,
    ProdutoCreateUpdate,
  },
  data() {
    return {
      loadData: false,
      overlay: false,
      itemsPerPageArray: [4, 8, 12],
      search: "",
      filter: {},
      sortDesc: false,
      page: 1,
      itemsPerPage: 4,
      sortBy: "name",
      keys: ["Name", "Value", "image"],
      keysSortBy: ["Name", "Value"],
      items: [],
    };
  },
  created() {
    this.getAllProducts();
  },
  computed: {
    numberOfPages() {
      return Math.ceil(this.items.length / this.itemsPerPage);
    },
    filteredKeys() {
      return this.keys.filter((key) => key !== "Name");
    },
    computedItens() {
      return this.items;
    },
  },
  methods: {
    async getAllProducts() {
      this.overlay = true;
      const { data } = await ProdutoRepository.get();
      this.items = data;
      this.overlay = false;
    },
    nextPage() {
      if (this.page + 1 <= this.numberOfPages) this.page += 1;
    },
    formerPage() {
      if (this.page - 1 >= 1) this.page -= 1;
    },
    updateItemsPerPage(number) {
      this.itemsPerPage = number;
    },
    confirmActionDelete: function(id) {
      this.$swal({
        text: "Confirma a exclusão do produto?",
        icon: "question",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Sim",
        cancelButtonText: "Não",
      }).then((result) => {
        if (result.value) {
          this.deleteProduct(id);
          (async () => {
            await this.getAllProducts();
          })();
        }
      });
    },
    confirmActionUpdate(product) {
      this.$refs.produtoCreateUpdate.openForm(product, 'update');
    },
    deleteProduct: async function(id) {
      await ProdutoRepository.delete({
        Id: id,
      });
    },
    openDialogCreate() {
      this.$refs.produtoCreateUpdate.openForm(null, 'create');
    },
    createProduct() {},
    submitCreate: async function(product) {
      //O PrototyPO não está funcionando muito bem para Post, usando o método tradicional
      await axios({
        method: "post", //put
        url: "/api/v1/Product",
        headers: {
          "Content-Type": "application/json",
          Authorization: "Bearer " + store.state.token,
        },
        data: product,
      });

      //await ProdutoRepository.create(product);
      await this.getAllProducts();
    },
      submitUpdate: async function(product) {
      //O PrototyPO não está funcionando muito bem para Post, usando o método tradicional
      await axios({
        method: "put", //put
        url: "/api/v1/Product",
        headers: {
          "Content-Type": "application/json",
          Authorization: "Bearer " + store.state.token,
        },
        data: product,
      });

      //await ProdutoRepository.create(product);
      await this.getAllProducts();
    },
  },
};
</script>
