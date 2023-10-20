<script>
import NavBar from "./components/NavBar.vue";

export default {
  components: {
    NavBar
  }
}
</script>

<template>
  <div class="page">
    <NavBar/>
    <div>
      <router-view />
    </div>
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
