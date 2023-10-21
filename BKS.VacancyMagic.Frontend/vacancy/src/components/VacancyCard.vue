<template>
  <va-card
    square
    outlined
    :id="vacancy.id"
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

</style>