FROM node:lts-alpine

# instala um servidor http simples para servir conteúdo estático
RUN npm install

WORKDIR /app

COPY ./SiteMercado.App/package*.json ./

RUN npm install

COPY ./SiteMercado.App ./

RUN npm run build

RUN rm -rf ./dist/css/index*.css 

EXPOSE 8080

CMD ["npm", "run", "serve_prod"]