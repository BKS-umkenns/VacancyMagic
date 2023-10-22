import { createStore } from 'vuex'
import User from "./Modules/User";
import Search from "./Modules/Search";
import Reply from "./Modules/Reply";
import Style from "./Modules/Style";

export default createStore({
  state: {
  },
  getters: {

  },
  mutations: {
  },
  actions: {
  },
  modules: {
    User,
    Search,
    Reply,
    Style
  }
})
