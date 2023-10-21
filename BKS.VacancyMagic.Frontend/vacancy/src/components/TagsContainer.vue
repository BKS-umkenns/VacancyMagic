<template>
  <div class="tags-container">
    <va-chip
      v-for="tag in tags"
      :color="tag.color"
      :key="tag.id"
    >
      {{tag.name}}{{tag.value.length !== 0 ? ':' : '' }} {{tag.value}}
    </va-chip>
  </div>
</template>

<script>
export default {
  name: "TagsContainer",
  props: {
    tags: Array,
  },
}
</script>


<style scoped>
.tags-container {
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
  gap: 0.5rem;
}
</style>