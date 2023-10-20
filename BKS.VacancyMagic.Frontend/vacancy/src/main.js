import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import router from "./router/router";
import store from "./store/store";
import {createVuestic,createIconsConfig} from "vuestic-ui";

createApp(App).use(router).use(store).use(createVuestic({
    config: {
        icons: createIconsConfig({
            aliases: [
                {
                    name: "bell",
                    color: "#FFD43A",
                    to: "fa4-bell",
                },
                {
                    name: "ru",
                    to: "flag-icon-ru small",
                },
            ],
            fonts: [
                {
                    name: "fa4-{iconName}",
                    resolve: ({ iconName }) => ({ class: `fa fa-${iconName}` }),
                },
                {
                    name: "flag-icon-{countryCode} {flagSize}",
                    resolve: ({ countryCode, flagSize }) => ({
                        class: `flag-icon flag-icon-${countryCode} flag-icon-${flagSize}`,
                    }),
                },
            ],
        })
    }
})).mount('#app')
