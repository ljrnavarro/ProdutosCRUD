export default {
  data: () => ({
    messageType: {
      ERROR: 'error',
      SUCCESS: 'success',
      WARNING: 'warning',
      INFO: 'info',
      QUESTION: 'question'
    }
  }),
  methods: {
    showMessage: function (types, title, message, router) {
      this.$swal({
        icon: types,
        title: title,
        text: message,
        showClass: {
          popup: "animated fadeInDown",
        },
        hideClass: {
          popup: "animated fadeOutUp",
        },
        onClose: () => {
          if (router != null)
           this.$router.push(router);
        },
      });
    },
  }
}
