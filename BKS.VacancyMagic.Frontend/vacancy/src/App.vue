<script>
import axios from "axios";
import store from "./store/store";

axios.interceptors.request.use(
    function(successfulReq) {
      successfulReq.headers.Authorization = `Bearer ${store.getters["User/getToken"]}`;
      return successfulReq;
    },
    function(error) {
      return Promise.reject(error);
    }
);

export default {
}
</script>

<template>
  <div class="page">
    <router-view />
  </div>
</template>

<style scoped>
.page {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: start;
}
</style>
