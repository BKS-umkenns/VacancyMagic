import { createRouter, createWebHistory } from "vue-router";
import Home from "../Pages/Home.vue";
import Auth from "../Pages/Auth.vue";

const routes = [
  { path: '/', component: Home }, // Welcome page - Landing
    // Search page - 4 steps
    // Cabinet page
    // Replays history page
  { path: '/auth', component: Auth },// Login/Register Page

]

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes,
});

export default router;
