import ProdutoRepository from "./ProdutoRepository";

const repositories = {
  produto:  ProdutoRepository,
  // other repositories ...
};

export const RepositoryFactory = {
  get: name => repositories[name]
};
