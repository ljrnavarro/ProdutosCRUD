module.exports = {
 devServer: {
    proxy: {
        '^/api': {
            target: 'https://localhost:5001/',
            ws: true,
            changeOrigin: false,
            pathRewrite: {   
              '^/api': 'https://localhost:5000/api' 
            },    
        }
    }
},
  configureWebpack: {
    devtool: 'source-map'
  },
  "transpileDependencies": [
    "vuetify"
  ]
}
