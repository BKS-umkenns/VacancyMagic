<template>
  <va-card
    :id="service.id"
    class="card"
    :style="{ boxShadow: `-10px -10px 2px ${service.color}` }"
  >
    <va-card-content class="content">
        <va-image
          class="service-logo"
          fit="contain"
          :src="service.logoUrl"
        />
      <div class="title" role="heading">
        {{service.name}}
      </div>
      <div class="function" v-for="func in service.functions">
        <p :class="func.implemented ? '' : 'soon'">{{ func.name }}</p>
        <va-image
          v-if="func.implemented"
          class="checkedIcon"
          fit="contain"
          src="/checked.png"
        />
        <span v-else>Скоро</span>
      </div>
    </va-card-content>
  </va-card>
</template>

<script>
import TagsContainer from "./TagsContainer.vue";

export default {
  name: "ServiceCard",
  components: {TagsContainer},
  props: {
    service: {},
  },
}
</script>

<style scoped>
.card {
    //height: 250px;
}
.content {
  display: flex;
  flex-direction: column;
  gap: 0.5rem;
}
.title {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  gap: 1rem;
  margin-bottom: 1rem;

  align-items: center;

  font-size: 1.25rem;
}
.service-logo {
  width: 2.5rem;
  height: 2.5rem;
}
.checkedIcon {
  width: 1rem;
  height: 1rem;
}
.function {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  gap: 1rem;

  line-height: 1rem;
  font-size: 1rem;
}
.soon {
  color: #adb3b9;
}
</style>