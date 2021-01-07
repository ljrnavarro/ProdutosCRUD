<template>
  <v-row justify="center">
    <v-dialog v-model="showDialog" persistent max-width="600px">
      <v-card>
        <v-toolbar color="primary" dark>Dados do Produto</v-toolbar>
        <v-card-text>
          <v-container>
            <v-form ref="form" v-model="valid" lazy-validation>
              <v-row>
                <v-col cols="12">
                  <v-text-field
                    label="Nome do Produto"
                    v-model="name"
                    :rules="[(v) => !!v || 'Nome é Obrigatório']"
                    required
                  ></v-text-field>
                </v-col>
                <v-col cols="12">
                  <v-text-field
                    v-model="value"
                    label="Valor"
                    :rules="[(v) => !!v || 'Valor é Obrigatório']"
                  >
                  </v-text-field>
                </v-col>
                <v-col cols="12">
                  <v-file-input
                    @change="uploadFile()"
                    v-model="file"
                    counter
                    label="Imagem"
                    prepend-icon="mdi-paperclip"
                    accept="image/*"
                    :show-size="1000"
                    :rules="ruleFiles"
                  >
                    <template v-slot:selection="{ index, text }">
                      <v-chip
                        v-if="index < 2"
                        color="deep-purple accent-4"
                        dark
                        label
                        small
                      >
                        {{ text }}
                      </v-chip>

                      <span
                        v-else-if="index === 2"
                        class="overline grey--text text--darken-3 mx-2"
                      >
                        +{{ file.length - 2 }} File(s)
                      </span>
                    </template>
                  </v-file-input>
                </v-col>
              </v-row>
            </v-form>
          </v-container>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="error" small @click="closeForm">
            <v-icon left>mdi-close-circle</v-icon>
            Fechar
          </v-btn>
          <v-btn color="primary" small @click="submitForm()">
            <v-icon left>mdi-check-circle</v-icon>
            Confirmar
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-row>
</template>
<script>
export default {
  data: () => ({
    showDialog: false,
    name: null,
    value: null,
    image: null,
    file: null,
    valid: true,
    mode: "create",
    id: null,
    ruleFiles: []
  }),
  methods: {
    ruleFileCheck()
    {
      if (this.mode == 'create')
       return [(v) => !!v  || 'Imagem é Obrigatória'] 
      else
       return []
    },
    submitForm() {
      if (this.$refs.form.validate()) {
        if (this.mode == "create")
          this.$emit("submitCreate", this.getProduct());
        else this.$emit("submitUpdate", this.getProduct());

        this.closeForm();
      } else return;
    },
    closeForm() {
      this.showDialog = false;
      this.$refs.form.reset();
      this.$refs.form.resetValidation();
    },
    openForm(product, mode) {
      if (product != null) {
        this.name = product.Name;
        this.value = product.Value;
        this.id = product.Id;
        this.image = product.Image;
      }
      this.mode = mode;
      this.showDialog = true;
      this.ruleFiles = this.mode == 'create' ? [(v) => !!v  || 'Imagem é Obrigatória'] : []
    },
    getProduct() {
      var product = {
        Id: this.id,
        Name: this.name,
        Value: parseFloat(this.value).toFixed(2),
        Image: this.image,
      };
      return product;
    },
    getBase64(file) {
      return new Promise((resolve, reject) => {
        const reader = new FileReader();
        reader.readAsDataURL(file);
        reader.onload = () => resolve(reader.result);
        reader.onerror = (error) => reject(error);
      });
    },
    async uploadFile() {
      if (this.file) {
        this.getBase64(this.file).then(
          (data) =>
            (this.image = data
              .toString()
              .replace("data:image/jpeg;base64,", ""))
        );
      }
    },
  },
};
</script>
