import { fileURLToPath, URL } from 'node:url'

import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'

// https://vitejs.dev/config/
export default defineConfig(({ command }) => {
  return {
    plugins: [
      vue(),
    ],
    resolve: {
      alias: {
        '@': fileURLToPath(new URL('./src', import.meta.url))
      }
    },
    base: '',
    server: {
      host: true,
      port: 4173, // This is the port which we will use in docker
      watch: {
        usePolling: true
      },
      proxy: {
        '/api': {
          target: 'http://localhost:5041',
          changeOrigin: true,
          rewrite: (path) => path,
        }
      }
    }
  }
});