<template>
  <v-app id="inspire" class="loginForm">
    <v-main>
      <v-container class="fill-height" fluid>
        <v-row align="center" justify="center">
          <v-col cols="12" sm="8" md="4">
            <v-card class="elevation-5">
              <v-toolbar color="primary" dark flat>
                <v-toolbar-title>Efetue o Login</v-toolbar-title>
                <v-spacer></v-spacer>
              </v-toolbar>
              <v-card-text ref="card">
                <v-form class="login" ref="form">
                  <v-text-field
                    @animationstart="checkAnimation"
                    v-model="user"
                    outlined
                    label="Usuário"
                    name="user"
                    ref="user"
                    id="idUser"
                    prepend-icon="person"
                    type="text"
                    :placeholder="autofilled ? ' ' : ''"
                  ></v-text-field>
                  <input
                    type="password"
                    name="senha"
                    id="password_fake"
                    class="hidden"
                    autocomplete="off"
                    style="display: none;"
                  />
                  <v-text-field
                    @animationstart="checkAnimation"
                    :append-icon="showPassword ? 'mdi-eye' : 'mdi-eye-off'"
                    v-model="senha"
                    label="Senha"
                    name="senha"
                    ref="senha"
                    outlined
                    prepend-icon="lock"
                    @click:append="showPassword = !showPassword"
                    :type="showPassword ? 'text' : 'password'"
                    :placeholder="autofilled ? ' ' : ''"
                  >
                  </v-text-field>
                </v-form>
              </v-card-text>
              <v-card-actions class="login_card_actions">
                  <v-btn
                    small
                    color="primary"
                    :loading="loadingLogin"
                    @click="login"
                  >
                    <v-icon left dark>mdi-login-variant</v-icon>
                    Login
                  </v-btn>
              </v-card-actions>
            </v-card>
          </v-col>
        </v-row>
      </v-container>
    </v-main>
  </v-app>
</template>

<script>
import "vue2-animate/dist/vue2-animate.min.css";
import ContaMixins from "../mixins/ContaMixins";
import AuthMixins from "../mixins/AuthMixins";
//import 'sweetalert2/src/SweetAlert/';

export default {
  name: "login",
  mixins: [ContaMixins, AuthMixins],
  data() {
    return {
      showPassword: false,
      user: "",
      senha: "",
      loadingLogin: false,
      loadingNovaConta: false,
      loadingRetrievePasswd: false,
      loader: null,
      autofilled: false,
    };
  },
  props: {
    source: String,
  },
  mounted() {
    this.$nextTick(function() {});
  },
  methods: {
    checkAnimation(e) {
      if (e.animationName == "onAutoFillStart") {
        this.autofilled = true;
      } else if (e.animationName == "onAutoFillCancel") {
        this.autofilled = false;
      }
    },
    fetchToken: async function(token) {
      this.$store.commit("STORE_USER_TOKEN", {
        user: this.user,
        token: token,
      });
    },
    login: async function() {
      this.loadingLogin = true;
      var retorno = await this.loginGetToken(this.user, this.senha);
      if (retorno.status === 200) {
        await this.fetchToken(retorno.data.token);
        this.showMessage(
          this.messageType.SUCCESS,
          "Login efetuado com sucesso!",
          "Seja bem vindo " + this.email,
          "/AppLayout"
        );
        this.loadingLogin = false;
      } else {
        this.loadingLogin = false;
        this.showMessage(
          this.messageType.ERROR,
          "Oops...Aconteceu algum problema!",
          "Não foi possível efetivar seu login. Verifique usuário/senha",
          null
        );
      }
    },
  },
};
</script>

<style>
[v-cloak] {
  display: none !important;
}

.login {
  margin-top: 40px;
}
input {
  margin: 10px 0;
  width: 20%;
  padding: 15px;
}

.login_card_actions{
 flex-direction: row-reverse !important;
}

button {
  font-family: "Roboto", sans-serif;
  text-transform: uppercase;
  outline: 0;
  background: #4caf50;
  border: 0;
  padding: 15px;
  color: #ffffff;
  font-size: 14px;
  -webkit-transition: all 0.3 ease;
  transition: all 0.3 ease;
  cursor: pointer;
}
p {
  margin-top: 40px;
  font-size: 13px;
}
p a {
  text-decoration: underline;
  cursor: pointer;
}
.custom-loader {
  animation: loader 1s infinite;
  display: flex;
}
.fill-height {
  padding-bottom: 250px !important;
}

.loginForm :-webkit-autofill {
  animation-name: onAutoFillStart;
}

.loginForm :not(:-webkit-autofill) {
  animation-name: onAutoFillCancel;
}

@keyframes onAutoFillStart {
  from {
  }
  to {
  }
}

@keyframes onAutoFillCancel {
  from {
  }
  to {
  }
}
</style>
