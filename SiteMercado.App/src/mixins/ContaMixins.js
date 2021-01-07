import firebase from "firebase";

const ContaMixins = {
    methods: {
        showDialogRetrievePasswd: function() {
            this.loadingRetrievePasswd = true;
            this.$swal({
              title: "Recuperação de Senha",
              text: "Confirma a solicitação de recuperação de senha de acesso?",
              icon: "question",
              showCancelButton: true,
              confirmButtonColor: "#3085d6",
              cancelButtonColor: "#d33",
              confirmButtonText: "Sim",
              cancelButtonText: "Cancelar",
            }).then((result) => {
              if (result.value) {
                this.retrievePasswd(this);
              }
            });
          },
          retrievePasswd: function(Vue) {
            if (Vue.email == "" || Vue.email == undefined) {
              Vue.$swal({
                icon: "error",
                title: "Oops...",
                text: "Email necessário",
                showClass: {
                  popup: "animated fadeInDown",
                },
                hideClass: {
                  popup: "animated fadeOutUp",
                },
              });
              Vue.loadingRetrievePasswd = false;
              return;
            } else {
              var auth = firebase.auth();
              firebase.auth().useDeviceLanguage();
              var emailAddress = Vue.email;
              auth
                .sendPasswordResetEmail(emailAddress)
                .then(function() {
                  Vue.$swal({
                    icon: "success",
                    title: "Email enviado",
                    text:
                      "Verifique sua caixa de email com instruções para recuperação de seu acesso.",
                    showClass: {
                      popup: "animated fadeInDown",
                    },
                    hideClass: {
                      popup: "animated fadeOutUp",
                    },
                    onAfterClose: () => {
                        Vue.$router.replace("/Login");
                        Vue.loadingRetrievePasswd = false;
                      }
                  });
                })
                .catch(function(erro) {
                  console.log("err", erro);
                  Vue.$swal({
                    icon: "error",
                    title: "Email não enviado",
                    text: "Entre em contato com o suporte do sistema." + `(${erro})`,
                    showClass: {
                      popup: "animated fadeInDown",
                    },
                    hideClass: {
                      popup: "animated fadeOutUp",
                    },
                  });
                  Vue.loadingRetrievePasswd = false;
                });
            }
          }
    },
}

export default ContaMixins