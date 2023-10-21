import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import router from "./router/router";
import store from "./store/store";
import {createVuestic} from "vuestic-ui";

createApp(App).use(router).use(store).use(createVuestic()).mount('#app')
