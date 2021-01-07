import Repository from "./Repository";

const resource = "/Product";
export default {
  get() {
    return Repository.get(`${resource}`);
  },

  getProduto(Id) {
    return Repository.get(`${resource}/${Id}`);
  },

  create(payload) {
    return Repository.post(`${resource}`, payload );
  },

  update(payload) {
    return Repository.put(`${resource}`, payload);
  },

  delete(payload) {
    return Repository.delete(`${resource}`, {data: payload});
  }
};
