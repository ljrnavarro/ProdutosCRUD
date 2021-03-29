# Crud de Produtos
   
-----------------------------------------------
## Ferramentas e instruções ##
 - Visual Studio Code ou Visual Studio para rodar o projeto .Net (.Net 5.0)
 - SQL Server
 - Postman
 
 * A Infraestrutura foi construida via migrations caso queiram basta executar os comandos que EF cria as tabelas

## Utilizando no docker ##
 - Esta aplicação está dockerizada:
 - 1. Imagem do SQL Server + entrypoint de criação e carga inicial de dados
 - 2. Imagem do .Net Core
 - 3. Imagem do App em Vuejs
 
 comando para subir a aplicação: docker-compose up --build.

# Proposta de Solução

### Arquitetura e padrões
  - Usando os conceitos de DDD
  - Segregação em entidades, Handles (Ação), Queries(obtenção) e Commands
  - Padroniozação usando contratos
  - Testes de unidade na camada de domínio 
  - Testes de unidade na camada de infraestrutura 
  - Tests de unidade na camada API 
  - SOLID e Clean 
  - Camada de domínio independente bem como de infraestrutura (Single Responsability Principle, desacoplamento e possibilidade de testar em separado)
  - Injeção de dependência
  - Conceitos de Testes e padronização de Retorno de Commands (Fail testes first)
  - EF core com Code-Firs e mapeamento de criação de tabelas
  - Banco de dados EntityFramework em memória e SQL Server
  - Autenticação JWT
  - Documentação da API via Swagger
  - Fluent API e Migrations
  - Front End feito em Vue.js + Biblioteca Vuetify.
