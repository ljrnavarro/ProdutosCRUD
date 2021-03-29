module.exports = {
  pages: {
    index: {
      entry: 'src/main.js'
    }
  },
 devServer: {
    proxy: {
        '^/api': {
            target: 'http://localhost:5000/',
            ws: true,
            changeOrigin: true,
            pathRewrite: {   
              '^/api': 'http://localhost:5000/api' 
            },    
        }
    }
},
  configureWebpack: {
    devtool: 'source-map',
  },
  "transpileDependencies": [
    "vuetify"
  ]
}
