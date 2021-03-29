import axios from "axios";
const AuthMixins = {
methods: {
    loginGetToken: async function(login, password)
    {
       var retorno = await (async () => {
           var retorno;
           await axios.post(process.env.VUE_APP_ROOT_API + "/Auth/Login", {}, {
                auth: {
                  username: login,
                  password: password
                }
              }).then(function (response) {
                  retorno = {status:response.status,
                            data: response.data}
              })
              .catch(function (error) {
                  retorno = {status :error.response.status,
                             data: null}
              });
              return retorno;
       })(); 
       return retorno;
    }
},

}
/*
http.interceptors.response.use(function (response) {
    return response;
  }, function (error) {
    return Promise.reject(error);
  });

http.interceptors.request.use(function (config) {
    const token = store.state.token;
    config.headers.Authorization = `Bearer ${token}`
    return config
}, function (erro) {
    console.log("erro", erro)
    return Promise.reject(erro)
})*/

export default AuthMixins
