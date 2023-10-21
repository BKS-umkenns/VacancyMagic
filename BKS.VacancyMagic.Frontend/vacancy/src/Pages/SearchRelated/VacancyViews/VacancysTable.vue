<template>
  <div>
    <va-collapse
        v-model="value"
        class="min-w-96"
        :header="vac.title"
        solid
        v-for="vac in vacancies"
    >
      <template #header="{ value, attrs, iconAttrs, text }">
        <div
            v-bind="attrs"
            class="collapse-header w-full flex border-[var(--va-background-border)] border-2 p-2 bg-[var(--va-background-element)]"
        >
          <va-icon
              name="va-arrow-down"
              :class="value ? '' : 'rotate-[-90deg]'"
              v-bind="iconAttrs"
          />

          <div class="ml-2">
            {{ text }}
          </div>
        </div>
      </template>

      <template #body>
        <div class="p-2 border-[var(--va-background-border)] border-2 border-t-0">
          Lorem ipsum dolor sit amet, consectetur adipisci
        </div>
      </template>
    </va-collapse>
  </div>
</template>

<script>
import {mapGetters} from "vuex";

export default {
  computed: {
    ...mapGetters('Search',[
        'vacancies'
    ]),
  }
}
</script>

<style scoped>
.collapse-header {
  display: flex;
  flex-direction: row;
  gap: 1rem;
  align-items: center;
  cursor: pointer;
}
</style>