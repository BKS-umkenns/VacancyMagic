import { createRouter, createWebHistory } from "vue-router";
import Landing from "../Pages/Landing.vue";
import Auth from "../Pages/Auth.vue";
import Search from "../Pages/Search.vue";
import Cabinet from "../Pages/Cabinet.vue";
import Replys from "../Pages/Replys.vue";

const routes = [
  { path: '/', component: Landing }, // Welcome page - Landing
  { path: '/search', component: Search }, // Search page - 4 steps
  { path: '/cabinet', component: Cabinet },  // Cabinet page
  { path: '/reply', component: Replys },  // Replays history page
  { path: '/auth', component: Auth },// Login/Register Page

]

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes,
});

export default router;
