<template>
  <va-card
    square
    outlined
    :id="vacancy.id"
    class="card"
  >
    <va-card-title>{{vacancy.title}}</va-card-title>
    <va-card-content>
      {{vacancy.id}}
    </va-card-content>
  </va-card>
</template>

<script>
export default {
  props: {
    vacancy: {},
  },
}
</script>

<style scoped>
.card {
  height: 50vh;
  width: 80%;
}
</style>