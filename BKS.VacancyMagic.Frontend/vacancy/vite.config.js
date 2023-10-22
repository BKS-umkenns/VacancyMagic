import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import { fileURLToPath, URL } from 'node:url'

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
    base: command === 'serve' ? "" : "/test-cloud-frontend/",
    server: {
      host: true,
      port: 4173, // This is the port which we will use in docker
      watch: {
        usePolling: true
      },
      proxy: {
        '/api': {
          target: 'http://localhost:5050/',
          changeOrigin: true,
          rewrite: (path) => path.replace(/^\/api/, ''),
        }
      }
    }
  }
});